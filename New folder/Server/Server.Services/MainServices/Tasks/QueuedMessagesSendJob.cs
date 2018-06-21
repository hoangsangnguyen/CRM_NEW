using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using Falcon.Web.Core.Infrastructure;
using Falcon.Web.Core.Log;
using FluentScheduler;
using SimpleInjector.Lifestyles;
using Vino.Server.Services.Infrastructure;
using Vino.Server.Services.MainServices.System.Email;

namespace Vino.Server.Services.MainServices.Tasks
{
	public class QueuedMessagesSendJob : IJob, IRegisteredObject
	{
		private readonly object _lock = new object();
		private bool _shuttingDown;

		public QueuedMessagesSendJob()
		{
			// Register this job with the hosting environment.
			// Allows for a more graceful stop of the job, in the case of IIS shutting down.
			HostingEnvironment.RegisterObject(this);
		}
		public void Execute()
		{
			lock (_lock)
			{
				if (_shuttingDown)
					return;
				Task.Run(async () =>
				{
					using (AsyncScopedLifestyle.BeginScope(SimpleContainer.Container))
					{
						var service = EngineContext.Current.Resolve<EmailService>();
						if (service == null) return;
						const int maxTries = 5;
						var total = 0;
						var queuedEmails = await service.SearchQueuedEmails(null, null, null, null,
							true, maxTries, false, 0, 500, total);
						foreach (var queuedEmail in queuedEmails)
						{
							var bcc = string.IsNullOrWhiteSpace(queuedEmail.Bcc)
								? null
								: queuedEmail.Bcc.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
							var cc = string.IsNullOrWhiteSpace(queuedEmail.CC)
								? null
								: queuedEmail.CC.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
							try
							{
								var result = service.SendEmail(
									queuedEmail.Subject,
									queuedEmail.Body,
									queuedEmail.From,
									queuedEmail.FromName,
									queuedEmail.To,
									queuedEmail.ToName,
									bcc,
									cc,
									queuedEmail.AttachmentFilePath,
									queuedEmail.AttachmentFileName);
								if (result)
									queuedEmail.SentOn = DateTime.Now;
							}
							catch (Exception exc)
							{
								var logger = EngineContext.Current.Resolve<ILogger>();
								logger.Error($"Error sending e-mail. {exc.Message}");
							}
							finally
							{
								queuedEmail.SentTries = queuedEmail.SentTries + 1;
								await service.UpdateQueuedEmail(queuedEmail);
							}


						}
					}
				});
			}
		}
		public void Stop(bool immediate)
		{
			// Locking here will wait for the lock in Execute to be released until this code can continue.
			lock (_lock)
			{
				_shuttingDown = true;
			}

			HostingEnvironment.UnregisterObject(this);
		}
	}
}
