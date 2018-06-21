using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Falcon.Web.Core.Helpers;
using Falcon.Web.Core.Settings;
using Falcon.Web.Mvc.Kendoui;
using Falcon.Web.Mvc.Security;
using Vino.Server.Services.Constants;
using Vino.Server.Services.MainServices.Auth;
using Vino.Server.Services.MainServices.System.Setting;
using Vino.Server.Services.MainServices.System.Setting.Models;
using Vino.Server.Web.Areas.Admin.Models.Setting;

namespace Vino.Server.Web.Areas.Admin.Controllers
{
    public class SettingController : BaseController
    {
        private readonly SettingService _settingService;
        private readonly UserAuthService _userAuthService;
        private readonly WebContext _webContext;

        public SettingController(SettingService settingService, UserAuthService userAuthService, WebContext webContext)
        {
            _settingService = settingService;
            _userAuthService = userAuthService;
            _webContext = webContext;
        }

        #region Setting
        public ActionResult SettingList()
        {
            if (_userAuthService.GetClaimByUserId(_webContext.UserId)
                .All(d => d != ServerPermissions.ManageSettings))
            {
                ErrorNotification("Bạn không có quyền truy cập");
                if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            }

            return View(new SettingListModel());
        }

        [HttpPost]
        public async Task<ActionResult> SettingList(DataSourceRequest common, SettingListModel model)
        {
            if (_userAuthService.GetClaimByUserId(_webContext.UserId)
                .All(d => d != ServerPermissions.ManageSettings))
            {
                ErrorNotification("Bạn không có quyền truy cập");
                if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            }

            var query = await _settingService.SearchSettings(new SearchSettingRequest()
            {
                Page = common.Page - 1,
                PageSize = common.PageSize,
                Name = model.Name,
                Value = model.Value
            });
            var gridModel = new DataSourceResult()
            {
                Data = query,
                Total = query.TotalCount
            };
            return Json(gridModel);
        }

        public ActionResult SettingCreate()
        {
            if (_userAuthService.GetClaimByUserId(_webContext.UserId)
                .All(d => d != ServerPermissions.ManageSettings))
            {
                ErrorNotification("Bạn không có quyền truy cập");
                if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            }

            return View(new SettingModel());
        }
        [HttpPost]
        public async Task<ActionResult> SettingCreate(SettingModel model)
        {
            if (_userAuthService.GetClaimByUserId(_webContext.UserId)
                .All(d => d != ServerPermissions.ManageSettings))
            {
                ErrorNotification("Bạn không có quyền truy cập");
                if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            }

            if (!ModelState.IsValid) return View(model);
            var setting = model.MapTo<Setting>();
            await _settingService.CreateSetting(setting);
            SuccessNotification("Thêm thành công!");
            return model.ContinueEditing
                ? RedirectToAction("SettingEdit", new {id = setting.Id})
                : RedirectToAction("SettingList");
        }

        public ActionResult SettingEdit(int id)
        {
            if (_userAuthService.GetClaimByUserId(_webContext.UserId)
                .All(d => d != ServerPermissions.ManageSettings))
            {
                ErrorNotification("Bạn không có quyền truy cập");
                if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            }

            var setting = _settingService.GetSettingsById(id);
            if (setting == null) return RedirectToAction("SettingList");

            var model = setting.MapTo<SettingModel>();

            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> SettingEdit(SettingModel model)
        {
            if (_userAuthService.GetClaimByUserId(_webContext.UserId)
                .All(d => d != ServerPermissions.ManageSettings))
            {
                ErrorNotification("Bạn không có quyền truy cập");
                if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            }

            if (!ModelState.IsValid) return View(model);
            var setting = _settingService.GetSettingsById(model.Id);
            if (setting == null) return RedirectToAction("SettingList");

            await _settingService.UpdateSettings(model);
            SuccessNotification("Chỉnh sửa thành công!");
            return model.ContinueEditing
                ? RedirectToAction("SettingEdit", new { id = setting.Id })
                : RedirectToAction("SettingList");
        }

        [HttpPost]
        public async Task<ActionResult> SettingDelete(int id)
        {
            if (_userAuthService.GetClaimByUserId(_webContext.UserId)
                .All(d => d != ServerPermissions.ManageSettings))
            {
                ErrorNotification("Bạn không có quyền truy cập");
                if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            }

            var setting = _settingService.GetSettingsById(id);
            if (setting == null) return RedirectToAction("SettingList");

            await _settingService.DeleteSettings(id);
            SuccessNotification("Xóa thành công!");
            return RedirectToAction("SettingList");
        }
        #endregion
    }
}