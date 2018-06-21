using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Web.Core.Helpers;
using Falcon.Web.Core.Message;
using Vino.Server.Services.Database;
using Vino.Server.Services.MainServices.Message.Models;
using Vino.Shared.Constants.Common;
using Vino.Shared.Dto.Common;

namespace Vino.Server.Services.MainServices.Message
{
    public class EmailAccountService
    {
        private readonly DataContext _dataContext;

        public EmailAccountService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Inserts an email account
        /// </summary>
        /// <param name="model">Email account model</param>
        public async Task<CrudResult> InsertEmailAccount(EmailAccountModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            var emailAccount = model.MapTo<EmailAccount>();

            emailAccount.Email = CommonHelper.EnsureNotNull(emailAccount.Email);
            emailAccount.DisplayName = CommonHelper.EnsureNotNull(emailAccount.DisplayName);
            emailAccount.Host = CommonHelper.EnsureNotNull(emailAccount.Host);
            emailAccount.Username = CommonHelper.EnsureNotNull(emailAccount.Username);
            
            emailAccount.Password = CommonHelper.EnsureNotNull(model.Password);

            emailAccount.EnableSsl = model.EnableSsl;
            emailAccount.UseDefaultCredentials = model.UseDefaultCredentials;

            emailAccount.Email = emailAccount.Email.Trim();
            emailAccount.DisplayName = emailAccount.DisplayName.Trim();
            emailAccount.Host = emailAccount.Host.Trim();
            emailAccount.Username = emailAccount.Username.Trim();
            emailAccount.Password = emailAccount.Password.Trim();

            emailAccount.Email = CommonHelper.EnsureMaximumLength(emailAccount.Email, 255);
            emailAccount.DisplayName = CommonHelper.EnsureMaximumLength(emailAccount.DisplayName, 255);
            emailAccount.Host = CommonHelper.EnsureMaximumLength(emailAccount.Host, 255);
            emailAccount.Username = CommonHelper.EnsureMaximumLength(emailAccount.Username, 255);
            emailAccount.Password = CommonHelper.EnsureMaximumLength(emailAccount.Password, 255);
            _dataContext.EmailAccounts.Add(emailAccount);
            await _dataContext.SaveChangesAsync();
            return new CrudResult() { IsOk = true, ReturnId = emailAccount.Id };
        }

        /// <summary>
        /// Updates an email account
        /// </summary>
        /// <param name="model">Email account model</param>
        public async Task<CrudResult> UpdateEmailAccount(EmailAccountModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            var emailAccount = _dataContext.EmailAccounts.Find(model.Id);
            if (emailAccount == null || emailAccount.Deleted)
                return new CrudResult()
                {
                    ErrorCode = CommonErrorStatus.KeyNotFound,
                };
            emailAccount.Email = CommonHelper.EnsureNotNull(model.Email);
            emailAccount.DisplayName = CommonHelper.EnsureNotNull(model.DisplayName);
            emailAccount.Host = CommonHelper.EnsureNotNull(model.Host);
            emailAccount.Username = CommonHelper.EnsureNotNull(model.Username);
            emailAccount.Password = CommonHelper.EnsureNotNull(model.Password);
            emailAccount.EnableSsl = model.EnableSsl;
            emailAccount.UseDefaultCredentials = model.UseDefaultCredentials;
            emailAccount.Port = model.Port;

            emailAccount.Email = emailAccount.Email.Trim();
            emailAccount.DisplayName = emailAccount.DisplayName.Trim();
            emailAccount.Host = emailAccount.Host.Trim();
            emailAccount.Username = emailAccount.Username.Trim();
            emailAccount.Password = emailAccount.Password.Trim();

            emailAccount.Email = CommonHelper.EnsureMaximumLength(emailAccount.Email, 255);
            emailAccount.DisplayName = CommonHelper.EnsureMaximumLength(emailAccount.DisplayName, 255);
            emailAccount.Host = CommonHelper.EnsureMaximumLength(emailAccount.Host, 255);
            emailAccount.Username = CommonHelper.EnsureMaximumLength(emailAccount.Username, 255);
            emailAccount.Password = CommonHelper.EnsureMaximumLength(emailAccount.Password, 255);

            await _dataContext.SaveChangesAsync();
            return new CrudResult(){ IsOk = true , ReturnId = emailAccount.Id};
        }

        /// <summary>
        /// Deletes an email account
        /// </summary>
        /// <param name="emailAccountId">Email account</param>
        public async Task<CrudResult> DeleteEmailAccount(int emailAccountId)
        {
            var emailAccount = _dataContext.EmailAccounts.Find(emailAccountId);
            if (emailAccount == null || emailAccount.Deleted)
                return new CrudResult()
                {
                    ErrorCode = CommonErrorStatus.KeyNotFound,
                };
            if ((await GetAllEmailAccounts()).Count == 1)
                return new CrudResult()
                {
                    ErrorCode = CommonErrorStatus.CommonError,
                    ErrorDescription = "Bạn không thể xóa email này"
                };

            emailAccount.Deleted = true;
            await _dataContext.SaveChangesAsync();
            return new CrudResult()
            {
                IsOk = true,
                ReturnId = emailAccount.Id
            };
        }

        /// <summary>
        /// Gets an email account by identifier
        /// </summary>
        /// <param name="emailAccountId">The email account identifier</param>
        /// <returns>Email account</returns>
        public EmailAccount GetEmailAccountById(int emailAccountId)
        {
            if (emailAccountId == 0)
                return null;
            var emailAccount = _dataContext.EmailAccounts.Find(emailAccountId);
            if (emailAccount == null || emailAccount.Deleted)
                return null;
            return emailAccount;
        }

        /// <summary>
        /// Gets all email accounts
        /// </summary>
        /// <returns>Email accounts list</returns>
        public async Task<IList<EmailAccount>> GetAllEmailAccounts()
        {
            var emailAccount = await _dataContext.EmailAccounts.AsNoTracking().Where(d => !d.Deleted).OrderByDescending(d => d.Id).ToListAsync();
            return emailAccount;
        }
    }
}
