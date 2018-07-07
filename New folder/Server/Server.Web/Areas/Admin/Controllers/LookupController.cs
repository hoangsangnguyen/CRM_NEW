using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Falcon.Web.Core.Helpers;
using Falcon.Web.Mvc.Kendoui;
using Falcon.Web.Mvc.Security;
using Vino.Server.Services.Constants;
using Vino.Server.Services.MainServices.Auth;
using Vino.Server.Services.MainServices.Common;
using Vino.Server.Services.MainServices.Common.Models;
using Vino.Server.Web.Areas.Admin.Models.Lookup;
using Vino.Shared.Constants.Common;

namespace Vino.Server.Web.Areas.Admin.Controllers
{
    public class LookupController : BaseController
    {
        private readonly LookupService _lookupService;
        private readonly UserAuthService _userAuthService;
        private readonly WebContext _webContext;

        public LookupController(LookupService lookupService, UserAuthService userAuthService, WebContext webContext)
        {
            _lookupService = lookupService;
            _userAuthService = userAuthService;
            _webContext = webContext;
        }

        #region lookup
        public ActionResult LookupList()
        {
            if (_userAuthService.GetClaimByUserId(_webContext.UserId)
                .All(d => d != ServerPermissions.ManageLookup))
            {
                ErrorNotification("Bạn không có quyền truy cập");
                if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            }

            return View(new LookupListModel());
        }

        [HttpPost]
        public async Task<ActionResult> LookupList(DataSourceRequest common, LookupListModel model)
        {
            if (_userAuthService.GetClaimByUserId(_webContext.UserId)
                .All(d => d != ServerPermissions.ManageLookup))
            {
                ErrorNotification("Bạn không có quyền truy cập");
                if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            }

            var lookup = await _lookupService.SearchLookup(new SearchLookupRequest()
            {
                Page = common.Page - 1,
                PageSize = common.PageSize,
                Code = model.Code,
                Title = model.Title,
                LookupType = model.LookupType
            });
            var gridModel = new DataSourceResult()
            {
                Data = lookup,
                Total = lookup.TotalCount
            };
            return Json(gridModel);
        }

        public ActionResult LookupCreate()
        {
            if (_userAuthService.GetClaimByUserId(_webContext.UserId)
                .All(d => d != ServerPermissions.ManageLookup))
            {
                ErrorNotification("Bạn không có quyền truy cập");
                if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            }

            return View(new LookupModel());
        }
        [HttpPost]
        public async Task<ActionResult> LookupCreate(LookupModel model)
        {
            if (_userAuthService.GetClaimByUserId(_webContext.UserId)
                .All(d => d != ServerPermissions.ManageLookup))
            {
                ErrorNotification("Bạn không có quyền truy cập");
                if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            }

            if (!ModelState.IsValid) return View(model);
            await _lookupService.InsertLookup(model);
            SuccessNotification("Thêm thành công!");
            return model.ContinueEditing
                ? RedirectToAction("LookupEdit", new {id = model.Id})
                : RedirectToAction("LookupList");
        }

        public async Task<ActionResult> LookupEdit(int id)
        {
            if (_userAuthService.GetClaimByUserId(_webContext.UserId)
                .All(d => d != ServerPermissions.ManageLookup))
            {
                ErrorNotification("Bạn không có quyền truy cập");
                if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            }

            var lookup = _lookupService.GetLookupById(id);
            if (lookup == null) return RedirectToAction("LookupList");

            var model = lookup.MapTo<LookupModel>();

            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> LookupEdit(LookupModel model)
        {
            if (_userAuthService.GetClaimByUserId(_webContext.UserId)
                .All(d => d != ServerPermissions.ManageLookup))
            {
                ErrorNotification("Bạn không có quyền truy cập");
                if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            }

            var lookup = _lookupService.GetLookupById(model.Id);
            if (lookup == null) return RedirectToAction("LookupList");
            if (!ModelState.IsValid) return View(model);

            await _lookupService.UpdateLookup(model);
            SuccessNotification("Chỉnh sửa thành công!");
            return model.ContinueEditing
                ? RedirectToAction("LookupEdit")
                : RedirectToAction("LookupList");
        }

        [HttpPost]
        public async Task<ActionResult> LookupDelete(int id)
        {
            if (_userAuthService.GetClaimByUserId(_webContext.UserId)
                .All(d => d != ServerPermissions.ManageLookup))
            {
                ErrorNotification("Bạn không có quyền truy cập");
                if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            }

            var lookup = _lookupService.GetLookupById(id);
            if (lookup == null) return RedirectToAction("LookupList");

            await _lookupService.DeleteLookup(id);
            SuccessNotification("Xóa thành công!");
            return RedirectToAction("LookupList");
        }
        #endregion


        #region Popup add Port

        public ActionResult LookupAddPopup(string viewId, LookupTypes type)
        {
            var model = new LookupModel()
            {
                Type = type
            };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> LookupAddPopup(string viewId, string btnId,
            string formId, LookupModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            await _lookupService.InsertLookup(request);
            SuccessNotification("Thêm thành công!");

            ViewBag.RefreshPage = true;
            ViewBag.btnId = btnId;
            ViewBag.formId = formId;
            ViewBag.viewId = viewId;

            return View(request);
        }
        #endregion
    }
}