using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Falcon.Web.Core.Helpers;
using Falcon.Web.Core.Log;
using Vino.Server.Services.MainServices.System.Email.Models;
using Vino.Server.Data.Framework;
using Vino.Server.Services.Database;
using Vino.Server.Services.Framework;
using Vino.Server.Services.Settings;
using Falcon.Web.Mvc.PageList;

namespace Vino.Server.Services.MainServices.System.Email
{
	public class EmailService
	{
		private readonly ILogger _logger;
		private readonly DataContext _dataContext;
		private readonly SettingService _settingService;
		public EmailService(ILogger logger,
			DataContext dataContext,
			SettingService settingService)
		{
			_dataContext = dataContext;
			_settingService = settingService;
			_logger = logger;
		}

		#region Tags

		const string TAG_USER_PW = "{@*password}";
		//const string TAG_USER_NAME = "{@*userName}";
		const string TAG_USER_EMAIL = "{@*userMail}";
		const string TAG_USER_NAME = "{@*userName}";
		const string TAG_DISPLAY_NAME = "{@*displayName}";
		#endregion
		public async Task SendWelcomeEmail(string email,string username, string password,string displayName=null)
		{
			try
			{
				var settings = _settingService.LoadSetting<EmailSettings>();
				var emailAcc = settings.SystemEmailAccount;
				var st = settings.EmailWelcomeTemplate;
				//st = st.Replace(TAG_USER_PW, password);
				st = st.Replace(TAG_USER_EMAIL, email);
				st = st.Replace(TAG_USER_NAME, username??email);
				
				await EnQueueEmail(emailAcc.Email, emailAcc.DisplayName, email, displayName, settings.EmailWelcomeTitle, st);
			}
			catch (Exception err)
			{
				_logger.Error(err.ToString());
			}
		}
		public async Task SendResetPasswordEmail(string displayName, string userName, string email, string password)
		{
			try
			{
				var settings = _settingService.LoadSetting<EmailSettings>();
				var emailAcc = settings.SystemEmailAccount;
				var st = settings.EmailResetPasswordTemplate;
				st = st.Replace(TAG_USER_PW, password);
				st = st.Replace(TAG_USER_NAME, userName);
				st = st.Replace(TAG_DISPLAY_NAME, displayName);
				await EnQueueEmail(emailAcc.Email, emailAcc.DisplayName, email, displayName, settings.EmailWelcomeTitle, st);
			}
			catch (Exception err)
			{
				_logger.Error(err.ToString());
			}
		}
		public async Task<List<QueueEmailModel>> SearchQueuedEmails(string fromEmail,
			string toEmail, DateTime? createdFrom, DateTime? createdTo,
			bool loadNotSentItemsOnly, int maxSendTries,
			bool loadNewest, int pageIndex, int pageSize, int total)
		{
			fromEmail = (fromEmail ?? string.Empty).Trim();
			toEmail = (toEmail ?? string.Empty).Trim();

			var query =_dataContext.QueuedEmails.AsNoTracking().Where(w=>!w.Deleted);
			if (!string.IsNullOrEmpty(fromEmail))
				query = query.Where(qe => qe.From.Contains(fromEmail));
			if (!string.IsNullOrEmpty(toEmail))
				query = query.Where(qe => qe.To.Contains(toEmail));
			if (createdFrom.HasValue)
				query = query.Where(qe => qe.CreatedOnUtc >= createdFrom);
			if (createdTo.HasValue)
				query = query.Where(qe => qe.CreatedOnUtc <= createdTo);
			if (loadNotSentItemsOnly)
				query = query.Where(qe => !qe.SentOn.HasValue);
			query = query.Where(qe => qe.SentTries < maxSendTries);
			query = query.OrderByDescending(qe => qe.Priority);
			query = loadNewest ?
				((IOrderedQueryable<QueuedEmail>)query).ThenByDescending(qe => qe.CreatedOnUtc) :
				((IOrderedQueryable<QueuedEmail>)query).ThenBy(qe => qe.CreatedOnUtc);

			var queuedEmails = await query.Skip(pageIndex*pageSize).Take(pageSize).ToListAsync();
			//var queuedEmails = new PageList<QueuedEmail>(query, pageIndex, pageSize);
			return queuedEmails.MapTo<QueueEmailModel>();
		}
		/// <summary>
		/// Them email vao hang doi
		/// </summary>
		/// <param name="fromEmailAddress"></param>
		/// <param name="fromName"></param>
		/// <param name="toEmailAddress"></param>
		/// <param name="toName"></param>
		/// <param name="subject"></param>
		/// <param name="body"></param>
		/// <param name="cc"></param>
		/// <param name="bcc"></param>
		/// <param name="attachmentFilePath"></param>
		/// <param name="attachmentFileName"></param>
		/// <returns></returns>
		public async Task<int> EnQueueEmail(string fromEmailAddress,string fromName, string toEmailAddress, string toName, string subject,string body,
			string cc=null,string bcc=null, string attachmentFilePath = null, string attachmentFileName = null)
		{
			var email = new QueuedEmail
			{
				Priority = 5,
				From = fromEmailAddress,
				FromName = fromName,
				To = toEmailAddress,
				ToName = toName,
				Bcc = bcc,
				CC = cc,
				Subject = subject,
				Body = body,
				AttachmentFilePath = attachmentFilePath,
				AttachmentFileName = attachmentFileName,
				CreatedOnUtc = DateTime.UtcNow,
			};
			_dataContext.QueuedEmails.Add(email);
			await _dataContext.SaveChangesAsync();
			return email.Id;
		}
		public async Task UpdateQueuedEmail(QueueEmailModel queuedEmail)
		{
			if (queuedEmail == null)
				throw new ArgumentNullException(nameof(queuedEmail));

			var queuedEmailDirty = await _dataContext.QueuedEmails.FindAsync(queuedEmail.Id);
			if(queuedEmailDirty==null) return;
			queuedEmailDirty.From = queuedEmail.From;
			queuedEmailDirty.FromName = queuedEmail.FromName;
			queuedEmailDirty.To = queuedEmail.To;
			queuedEmailDirty.ToName = queuedEmail.ToName;
			queuedEmailDirty.Subject = queuedEmail.Subject;
			queuedEmailDirty.Body = queuedEmail.Body;
			queuedEmailDirty.AttachmentFileName = queuedEmail.AttachmentFileName;
			queuedEmailDirty.AttachmentFilePath = queuedEmail.AttachmentFilePath;
			queuedEmailDirty.CC = queuedEmail.CC;
			queuedEmailDirty.Bcc = queuedEmail.Bcc;
			queuedEmailDirty.Priority = queuedEmail.Priority;
			queuedEmailDirty.SentOn = queuedEmail.SentOn;
			queuedEmailDirty.SentTries = queuedEmail.SentTries;

			await _dataContext.SaveChangesAsync();
		}


		/// <summary>
		/// Gui email
		/// </summary>
		/// <param name="subject"></param>
		/// <param name="body"></param>
		/// <param name="fromAddress"></param>
		/// <param name="fromName"></param>
		/// <param name="toAddress"></param>
		/// <param name="toName"></param>
		/// <param name="bcc"></param>
		/// <param name="cc"></param>
		/// <param name="attachmentFilePath"></param>
		/// <param name="attachmentFileName"></param>
		/// <returns></returns>
		public bool SendEmail(string subject, string body,
			string fromAddress, string fromName, string toAddress, string toName,
			IEnumerable<string> bcc = null, IEnumerable<string> cc = null,
			string attachmentFilePath = null, string attachmentFileName = null)
		{
			bool result;
			try
			{
				var message = new MailMessage {From = new MailAddress(fromAddress, fromName)};
				message.To.Add(toAddress);
				if (null != bcc)
				{
					foreach (var address in bcc.Where(bccValue => !string.IsNullOrWhiteSpace(bccValue)))
					{
						message.Bcc.Add(address.Trim());
					}
				}
				if (null != cc)
				{
					foreach (var address in cc.Where(ccValue => !string.IsNullOrWhiteSpace(ccValue)))
					{
						message.CC.Add(address.Trim());
					}
				}
				message.Subject = subject;
				message.Body = body;
				message.IsBodyHtml = true;
				var acc = _settingService.LoadSetting<EmailSettings>().SystemEmailAccount;
				using (var smtpClient = new SmtpClient())
				{
					smtpClient.UseDefaultCredentials = acc.UseDefaultCredentials;
					smtpClient.Host = acc.Host;
					smtpClient.Port = acc.Port;
					smtpClient.EnableSsl = acc.EnableSsl;
					smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
					smtpClient.Credentials = acc.UseDefaultCredentials ? CredentialCache.DefaultNetworkCredentials : new NetworkCredential(acc.Username, acc.Password);
					smtpClient.Send(message);
				}
				result = true;
			}
			catch (Exception exc)
			{
				_logger.Error($"Can not send email out {exc.Message}");
				result = false;
			}
			return result;
		}
	}
}
