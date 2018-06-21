using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Falcon.Web.Core.Helpers;
using Falcon.Web.Mvc.Kendoui;
using Vino.Server.Data.Common;
using Vino.Server.Services.MainServices.Message;
using Vino.Server.Services.MainServices.Message.Models;
using Vino.Server.Web.Areas.Admin.Models.Message;

namespace Vino.Server.Web.Areas.Admin.Controllers
{
    public class MessageTemplateController : BaseController
    {
        private readonly MessageTemplateService _messageTemplateService;

        public MessageTemplateController(MessageTemplateService messageTemplateService)
        {
            _messageTemplateService = messageTemplateService;
        }

        public virtual ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public virtual ActionResult List()
        {
            var model = new MessageTemplateListModel();

            return View(model);
        }

        [HttpPost]
        public virtual ActionResult List(DataSourceRequest command, MessageTemplateListModel model)
        {
            var messageTemplates = _messageTemplateService.GetAllMessageTemplates();
            var gridModel = new DataSourceResult
            {
                Data = messageTemplates.Select(x => x.MapTo<MessageTemplateModel>()),
                Total = messageTemplates.Count
            };

            return Json(gridModel);
        }

        public virtual ActionResult Edit(int id)
        {
            var messageTemplate = _messageTemplateService.GetMessageTemplateById(id);
            if (messageTemplate == null)
                //No message template found with the specified id
                return RedirectToAction("List");

            var model = messageTemplate.MapTo<MessageTemplateModel>();
            //model.HasAttachedDownload = model.AttachedDownloadId > 0;
            //var allowedTokens = string.Join(", ", _messageTokenProvider.GetListOfAllowedTokens(messageTemplate.GetTokenGroups()));
            //model.AllowedTokens = string.Format("{0}{1}{1}{2}{1}", allowedTokens, Environment.NewLine,_localizationService.GetResource("Admin.ContentManagement.MessageTemplates.Tokens.ConditionalStatement"));
            //available email accounts
            //foreach (var ea in _emailAccountService.GetAllEmailAccounts())
            //    model.AvailableEmailAccounts.Add(new SelectListItem { Text = ea.DisplayName, Value = ea.Id.ToString() });
            //Store


            return View(ToContentModel(model));
        }

        [HttpPost]
        public virtual async Task<ActionResult> Edit(MessageTemplateContentModel contentModel)
        {
            
            var messageTemplate = _messageTemplateService.GetMessageTemplateById(contentModel.Id);
            if (messageTemplate == null)
                //No message template found with the specified id
                return RedirectToAction("List");

            if (!ModelState.IsValid)
                return View(contentModel);
            var model = ToModel(contentModel);
            messageTemplate = model.MapTo<MessageTemplate>();
            //attached file
            //if (!model.HasAttachedDownload)
            //    messageTemplate.AttachedDownloadId = 0;
            //if (model.SendImmediately)
            //    messageTemplate.DelayBeforeSend = null;
            await _messageTemplateService.UpdateMessageTemplate(model);

            SuccessNotification("Chỉnh sửa message template thành công");

            return model.ContinueEditing ? RedirectToAction("Edit", new { id = messageTemplate.Id }) : RedirectToAction("List");


            //If we got this far, something failed, redisplay form
            //model.HasAttachedDownload = model.AttachedDownloadId > 0;
            //var allowedTokens = string.Join(", ", _messageTokenProvider.GetListOfAllowedTokens(messageTemplate.GetTokenGroups()));
            //model.AllowedTokens = string.Format("{0}{1}{1}{2}{1}", allowedTokens, Environment.NewLine,
            //    _localizationService.GetResource("Admin.ContentManagement.MessageTemplates.Tokens.ConditionalStatement"));
            ////available email accounts
            //foreach (var ea in _emailAccountService.GetAllEmailAccounts())
            //    model.AvailableEmailAccounts.Add(new SelectListItem { Text = ea.DisplayName, Value = ea.Id.ToString() });
            ////locales (update email account dropdownlists)
            //foreach (var locale in model.Locales)
            //{
            //    //available email accounts (we add "Standard" value for localizable field)
            //    locale.AvailableEmailAccounts.Add(new SelectListItem
            //    {
            //        Text = _localizationService.GetResource("Admin.ContentManagement.MessageTemplates.Fields.EmailAccount.Standard"),
            //        Value = "0"
            //    });
            //    foreach (var ea in _emailAccountService.GetAllEmailAccounts())
            //        locale.AvailableEmailAccounts.Add(new SelectListItem
            //        {
            //            Text = ea.DisplayName,
            //            Value = ea.Id.ToString(),
            //            Selected = ea.Id == locale.EmailAccountId
            //        });
            //}
            ////Store
            //PrepareStoresMappingModel(model, messageTemplate, true);
            //return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            //if (!_permissionService.Authorize(StandardPermissionProvider.ManageMessageTemplates))
            //    return AccessDeniedView();

            var messageTemplate = _messageTemplateService.GetMessageTemplateById(id);
            if (messageTemplate == null)
                //No message template found with the specified id
                return RedirectToAction("List");

            await _messageTemplateService.DeleteMessageTemplate(messageTemplate.Id);
            SuccessNotification("Xóa message template thành công ");
            return RedirectToAction("List");
        }
        #region prepare content model

        public MessageTemplateModel ToModel(MessageTemplateContentModel contentModel)
        {
            return new MessageTemplateModel()
            {
                Id = contentModel.Id,
                Name = contentModel.Name,
                BccEmailAddresses = contentModel.BccEmailAddresses,
                Subject = contentModel.Subject,
                Body = contentModel.Body,
                IsActive = contentModel.IsActive,
                DelayBeforeSend = contentModel.DelayBeforeSend,
                DelayPeriod = contentModel.DelayPeriod,
                AttachedDownloadId = contentModel.AttachedDownloadId,
                //SendImmediately = contentModel.SendImmediately,
                HasAttachedDownload = contentModel.HasAttachedDownload,
                ContinueEditing = contentModel.ContinueEditing,

            };
        }

        public MessageTemplateContentModel ToContentModel(MessageTemplateModel model)
        {
            return new MessageTemplateContentModel()
            {
                Id = model.Id,
                Name = model.Name,
                BccEmailAddresses = model.BccEmailAddresses,
                Subject = model.Subject,
                Body = model.Body,
                IsActive = model.IsActive,
                DelayBeforeSend = model.DelayBeforeSend,
                DelayPeriod = model.DelayPeriod,
                AttachedDownloadId = model.AttachedDownloadId,
                //SendImmediately = model.SendImmediately,
                HasAttachedDownload = model.HasAttachedDownload,
                ContinueEditing = model.ContinueEditing,
            };
        }
        #endregion  
    }
}