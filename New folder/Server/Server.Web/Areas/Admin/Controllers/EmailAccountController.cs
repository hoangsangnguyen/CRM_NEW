using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;
using Falcon.Web.Core.Helpers;
using Falcon.Web.Mvc.Kendoui;
using Vino.Server.Data.Common;
using Vino.Server.Services.Framework;
using Vino.Server.Services.MainServices.Message;
using Vino.Server.Services.MainServices.Message.Models;
using Vino.Server.Web.Areas.Admin.Models.Message;
using Vino.Shared.Constants.Common;

namespace Vino.Server.Web.Areas.Admin.Controllers
{
    public class EmailAccountController : BaseController
    {
        private readonly EmailAccountService _emailAccountService;
        private readonly EmailAccountSettings _emailAccountSettings;
        private readonly SettingService _settingService;
        public EmailAccountController(EmailAccountService emailAccountService, EmailAccountSettings emailAccountSettings, SettingService settingService)
        {
            _emailAccountService = emailAccountService;
            _emailAccountSettings = emailAccountSettings;
            _settingService = settingService;
        }

        public virtual ActionResult List()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> List(DataSourceRequest command)
        {
            var emailAccountModels = (await _emailAccountService.GetAllEmailAccounts())
                                    .Select(x => x.MapTo<EmailAccountModel>())
                                    .ToList();
            var emailAccountSetting = _settingService.LoadSetting<EmailAccountSettings>();
            foreach (var eam in emailAccountModels)
                eam.IsDefaultEmailAccount = eam.Id == emailAccountSetting.DefaultEmailAccountId;

            var gridModel = new DataSourceResult
            {
                Data = emailAccountModels,
                Total = emailAccountModels.Count()
            };

            return Json(gridModel);
        }

        public virtual async Task<ActionResult> MarkAsDefaultEmail(int id)
        {
            var defaultEmailAccount = _emailAccountService.GetEmailAccountById(id);
            if (defaultEmailAccount != null)
            {
                _emailAccountSettings.DefaultEmailAccountId = defaultEmailAccount.Id;
                await _settingService.SaveSetting(_emailAccountSettings);
            }
            return RedirectToAction("List");
        }

        public virtual ActionResult Create()
        {
            var model = new EmailAccountModel { Port = 25 };
            //default values
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(EmailAccountModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var res = await _emailAccountService.InsertEmailAccount(model);
            if (!res.IsOk && res.ErrorCode == CommonErrorStatus.CommonError)
            {
                ErrorNotification(res.ErrorDescription);
                return View(model);
            }
            if (!res.IsOk)
            {
                ErrorNotification("Thêm mới email thất bại");
                return View(model);
            }
            SuccessNotification("Thêm mới email thành công");
            return model.ContinueEditing ? RedirectToAction("Edit", new { id = res.ReturnId }) : RedirectToAction("List");
        }

        public virtual ActionResult Edit(int id)
        {
            var emailAccount = _emailAccountService.GetEmailAccountById(id);
            if (emailAccount == null)
                //No email account found with the specified id
                return RedirectToAction("List");

            return View(emailAccount.MapTo<EmailAccountModel>());
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EmailAccountModel model)
        {
            var emailAccount = _emailAccountService.GetEmailAccountById(model.Id);
            if (emailAccount == null)
                //No email account found with the specified id
                return RedirectToAction("List");
            if (model.ChangePassword)
            {
                var modelChangePassword = emailAccount.MapTo<EmailAccountModel>();
                modelChangePassword.Password = model.Password;
                var result = await _emailAccountService.UpdateEmailAccount(model);
                if (result.IsOk) SuccessNotification("Đổi mật khẩu thành công");
                return RedirectToAction("Edit", new { id = emailAccount.Id });
            }

            ModelState["Password"]?.Errors?.Clear();
            if (!ModelState.IsValid)
                return View(model);
            model.Password = emailAccount.Password;
            var res = await _emailAccountService.UpdateEmailAccount(model);
            if (!res.IsOk && res.ErrorCode == CommonErrorStatus.CommonError)
            {
                ErrorNotification(res.ErrorDescription);
                return View(model);
            }
            if (!res.IsOk)
            {
                ErrorNotification("Chỉnh sửa email thất bại");
                return View(model);
            }
            SuccessNotification("Chỉnh sửa email thành công");
            return model.ContinueEditing ? RedirectToAction("Edit", new { id = emailAccount.Id }) : RedirectToAction("List");
        }

        public virtual ActionResult SendTestEmail(int id)
        {
            var emailAccount = _emailAccountService.GetEmailAccountById(id);
            if (emailAccount == null)
                //No email account found with the specified id
                return RedirectToAction("List");
            var model = new SendEmailTestModel()
            {
                Id = emailAccount.Id,
                Email = emailAccount.Email,
            };
            return View(model);
        }
        [HttpPost]
        public virtual ActionResult SendTestEmail(SendEmailTestModel model)
        {
            var emailAccount = _emailAccountService.GetEmailAccountById(model.Id);
            if (emailAccount == null)
                //No email account found with the specified id
                return RedirectToAction("List");
            if (!ModelState.IsValid)
            {
                model.Email = emailAccount.Email;
                return View(model);
            }
            if (!CommonHelper.IsValidEmail(model.SendMailTo))
            {
                ErrorNotification("Email không hợp lệ");
                model.Email = emailAccount.Email;
                return View(model);
            }


                string subject = "Send mail test";
                string body = "Email works fine.";
            try
            {
                var message = new MailMessage()
                {
                    From = new MailAddress(emailAccount.Email),
                    Subject = subject,
                    IsBodyHtml = true,
                    Body = body
                };
                message.To.Add(model.SendMailTo);

                using (var stmp = new SmtpClient())
                {
                    var clientCertificates = new NetworkCredential()
                    {
                        UserName = emailAccount.Username,
                        Password = emailAccount.Password,
                    };
                    stmp.Credentials = clientCertificates;
                    stmp.Host = emailAccount.Host;
                    stmp.Port = emailAccount.Port;
                    stmp.EnableSsl = emailAccount.EnableSsl;
                    stmp.UseDefaultCredentials = emailAccount.UseDefaultCredentials;
                    stmp.Send(message);
                }
                SuccessNotification("Gửi mail test thành công");
                //If we got this far, something failed, redisplay form
                return View(model);

            }
            catch (Exception ex)
            {
                ErrorNotification(ex.Message);
                return View(model);
            }
        
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var emailAccount = _emailAccountService.GetEmailAccountById(id);
            if (emailAccount == null)
                //No email account found with the specified id
                return RedirectToAction("List");

            var res = await _emailAccountService.DeleteEmailAccount(emailAccount.Id);
            if (!res.IsOk && res.ErrorCode == CommonErrorStatus.CommonError)
            {
                ErrorNotification(res.ErrorDescription);
                return RedirectToAction("Edit", emailAccount.Id);
            }
            SuccessNotification("Xóa email thành công");
            return RedirectToAction("List");
        }
    }
}