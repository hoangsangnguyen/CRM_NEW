using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Falcon.Web.Mvc.Kendoui;
using Falcon.Web.Mvc.Security;
using Vino.Server.Services.Constants;
using Vino.Server.Services.MainServices.Auth;
using Vino.Server.Services.MainServices.System.Log;
using Vino.Server.Web.Areas.Admin.Models.Log;

namespace Vino.Server.Web.Areas.Admin.Controllers
{
    public class LogController : BaseController
    {
        private readonly LogService _logService;
        private readonly UserAuthService _userAuthService;
        private readonly WebContext _webContext;
        public LogController(LogService logService, UserAuthService userAuthService, WebContext webContext)
        {
            _logService = logService;
            _userAuthService = userAuthService;
            _webContext = webContext;
        }

        #region log master
        public ActionResult List()
        {
            if (_userAuthService.GetClaimByUserId(_webContext.UserId)
                .All(d => d != ServerPermissions.ManageSystemLog))
            {
                ErrorNotification("Bạn không có quyền truy cập");
                if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            }
            return View(new LogListModel());
        }

        [HttpPost]
        public async Task<ActionResult> List(DataSourceRequest common, LogListModel model)
        {
            if (_userAuthService.GetClaimByUserId(_webContext.UserId)
                .All(d => d != ServerPermissions.ManageSystemLog))
            {
                ErrorNotification("Bạn không có quyền truy cập");
                if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            }
            
            var logs = await _logService.SearchLog(new SearchLogRequest()
            {
                Page = common.Page - 1,
                PageSize = common.PageSize,
                DateForm = DateTimeOffset.Parse(model.DateFrom, new CultureInfo("vi-VN")),
                DateTo = DateTimeOffset.Parse(model.DateTo, new CultureInfo("vi-VN")),
            });
            var gridModel = new DataSourceResult()
            {
                Data = logs,
                Total = logs.TotalCount
            };
            return Json(gridModel);
        }

        public ActionResult Edit(int id)
        {
            if (_userAuthService.GetClaimByUserId(_webContext.UserId)
                .All(d => d != ServerPermissions.ManageSystemLog))
            {
                ErrorNotification("Bạn không có quyền truy cập");
                if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            }

            var model = _logService.GetLogById(id);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if (_userAuthService.GetClaimByUserId(_webContext.UserId)
                .All(d => d != ServerPermissions.ManageSystemLog))
            {
                ErrorNotification("Bạn không có quyền truy cập");
                if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            }

            var log = _logService.GetLogById(id);
            if (log == null) return RedirectToAction("List");

            await _logService.DeleteLog(log.Id);
            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<ActionResult> DeleteAll()
        {
            if (_userAuthService.GetClaimByUserId(_webContext.UserId)
                .All(d => d != ServerPermissions.ManageSystemLog))
            {
                ErrorNotification("Bạn không có quyền truy cập");
                if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            }

            await _logService.DeleteAllLog();
            return RedirectToAction("List");
        }
        #endregion
    }
}