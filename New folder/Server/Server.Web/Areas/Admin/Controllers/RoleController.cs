using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Falcon.Web.Core.Auth;
using Falcon.Web.Core.Helpers;
using Falcon.Web.Mvc.Kendoui;
using Falcon.Web.Mvc.Security;
using Vino.Server.Services.Constants;
using Vino.Server.Services.MainServices.Auth;
using Vino.Server.Services.MainServices.Auth.Models;
using Vino.Server.Web.Areas.Admin.Models.Role;

namespace Vino.Server.Web.Areas.Admin.Controllers
{
    public class RoleController : BaseController
    {
        private readonly RoleService _roleService;
        private readonly UserAuthService _userAuthService;
        private readonly WebContext _webContext;

        public RoleController(RoleService roleService, UserAuthService userAuthService, WebContext webContext)
        {
            _roleService = roleService;
            _userAuthService = userAuthService;
            _webContext = webContext;
        }

        public ActionResult RoleList()
        {

            if (_userAuthService.GetClaimByUserId(_webContext.UserId)
                .All(d => d != ServerPermissions.ManageRole))
            {
                ErrorNotification("Bạn không có quyền truy cập");
                if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            }

            return View(new RoleListModel());
        }

        [HttpPost]
        public async Task<ActionResult> RoleList(DataSourceRequest common, RoleListModel model)
        {
            if (_userAuthService.GetClaimByUserId(_webContext.UserId)
                .All(d => d != ServerPermissions.ManageRole))
            {
                ErrorNotification("Bạn không có quyền truy cập");
                if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            }

            var query = await _roleService.SearchRole(new SearchRoleRequest()
            {
                Page = common.Page - 1,
                PageSize = common.PageSize,
                Display = model.Display
            });
            var gridModel = new DataSourceResult()
            {
                Data = query,
                Total = query.TotalCount
            };
            return Json(gridModel);
        }

        public ActionResult RoleCreate()
        {
            if (_userAuthService.GetClaimByUserId(_webContext.UserId)
                .All(d => d != ServerPermissions.ManageRole))
            {
                ErrorNotification("Bạn không có quyền truy cập");
                if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            }
            ViewBag.Edit = false;
            return View(new RoleModel());
        }

        [HttpPost]
        public async Task<ActionResult> RoleCreate(RoleModel model)
        {
            if (_userAuthService.GetClaimByUserId(_webContext.UserId)
                .All(d => d != ServerPermissions.ManageRole))
            {
                ErrorNotification("Bạn không có quyền truy cập");
                if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            }
            ViewBag.Edit = false;
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (_roleService.CheckRoleSystemNameExist(model.SystemName))
            {
                ModelState.AddModelError("SystemName", "Tên hệ thống đã tồn tại vui lòng nhập tên khác");
                return View(model);
            }
            var role = model.MapTo<Role>();
            await _roleService.Create(role);
            SuccessNotification("Thêm thành công!");
            return model.ContinueEditing ? RedirectToAction("RoleEdit", new {id = role.SystemName }) : RedirectToAction("RoleList");
        }

        public ActionResult RoleEdit(string id)
        {
            if (_userAuthService.GetClaimByUserId(_webContext.UserId)
                .All(d => d != ServerPermissions.ManageRole))
            {
                ErrorNotification("Bạn không có quyền truy cập");
                if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            }

            var role = _roleService.GetRoleBySystemName(id);
            if (role == null) return RedirectToAction("RoleList");

            var model = role.MapTo<RoleModel>();
            ViewBag.Edit = true;
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> RoleEdit(RoleModel model)
        {
            ViewBag.Edit = true;
            if (_userAuthService.GetClaimByUserId(_webContext.UserId)
                .All(d => d != ServerPermissions.ManageRole))
            {
                ErrorNotification("Bạn không có quyền truy cập");
                if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            }

            var role = _roleService.GetRoleBySystemName(model.SystemName);
            if (role == null) return View(model);
            if (!ModelState.IsValid) return View(model);
            if (_roleService.CheckRoleSystemNameExist(model.SystemName, role.SystemName))
            {
                ModelState.AddModelError("SystemName", "Tên hệ thống đã tồn tại vui lòng nhập tên khác");
                return View(model);
            }
            await _roleService.UpdateRole(model);
            SuccessNotification("Chỉnh sửa thành công!");
        
            return model.ContinueEditing ? RedirectToAction("RoleEdit") : RedirectToAction("RoleList");
        }
        [HttpPost]
        public async Task<ActionResult> RoleDelete(string id)
        {
            if (_userAuthService.GetClaimByUserId(_webContext.UserId)
                .All(d => d != ServerPermissions.ManageRole))
            {
                ErrorNotification("Bạn không có quyền truy cập");
                if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            }

            var role = _roleService.GetRoleBySystemName(id);
            if (role == null) return RedirectToAction("RoleList");

            await _roleService.DeleteRole(role.SystemName);
            SuccessNotification("Xóa thành công!");
            return RedirectToAction("RoleList");
        }

        public async Task<ActionResult> RoleClaimList()
        {
            if (_userAuthService.GetClaimByUserId(_webContext.UserId)
                .All(d => d != ServerPermissions.ManageRole))
            {
                ErrorNotification("Bạn không có quyền truy cập");
                if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            }

            var model = await _roleService.GetRoleClaim();
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> RoleClaimList(RoleClaimUpdateModel model)
        {
            if (_userAuthService.GetClaimByUserId(_webContext.UserId)
                .All(d => d != ServerPermissions.ManageRole))
            {
                ErrorNotification("Bạn không có quyền truy cập");
                if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            }

            await _roleService.UpdateClaimByRole(model);
            return Content("success");
        }
    }
}