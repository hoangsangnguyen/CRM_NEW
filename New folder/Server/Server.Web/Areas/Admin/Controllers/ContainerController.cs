using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Falcon.Web.Mvc.Kendoui;
using Vino.Server.Services.MainServices.CRM.Container;
using Vino.Server.Services.MainServices.CRM.Container.Models;
using Vino.Server.Services.MainServices.CRM.FclExp;
using Vino.Server.Web.Areas.Admin.Models.Carriers;
using Vino.Server.Web.Areas.Admin.Models.Container;
using Vino.Server.Web.Helper;
using Vino.Shared.Constants.Common;
using Vino.Shared.Constants.Warehouse;

namespace Vino.Server.Web.Areas.Admin.Controllers
{
    public class ContainerController : BaseController
    {
        private readonly FclExpService _fclExpService;

        public ContainerController(FclExpService fclExpService)
        {
            _fclExpService = fclExpService;
        }

        #region Container
        // GET: Admin/Container

        public ActionResult List(string viewId, int id)
        {
            return View(new ContainerListModel() { FclId = id });
        }

        [HttpPost]
        public async Task<ActionResult> List(DataSourceRequest common, ContainerListModel model)
        {
            var dtoFromRepo = await _fclExpService.GetAllContainerOfFclExp(
                id: model.FclId ?? 0,
                page : common.Page-1,
                pageSize:common.PageSize);

            var gridModel = new DataSourceResult()
            {
                Data = dtoFromRepo,
                Total = dtoFromRepo?.Count ?? 0
            };

            return Json(gridModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ContainerModel dto, int fclExpId)
        {
            var fclExp = _fclExpService.GetSingleAsync(fclExpId);
            if (fclExp.Id <= 0)
                return Json(new DataSourceResult { Errors = "Fcl Export không tồn tại" });

            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            await _fclExpService.InsertContainer(fclExpId, dto);
            return new NullJsonResult();
        }

        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> Edit(ContainerModel model, int fclExpId)
        {
            var fclExp = _fclExpService.GetSingleAsync(fclExpId);
            if (fclExp.Id <= 0)
                return Json(new DataSourceResult { Errors = "Fcl Export không tồn tại" });
          
            if (!ModelState.IsValid)
                return Json(new DataSourceResult { Errors = ModelState.SerializeErrors() });
            await _fclExpService.UpdateContainer(fclExpId, model);

            return new NullJsonResult();
        }

        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> Delete(Guid id, int fclExpId)
        {
            var fclExp = _fclExpService.GetSingleAsync(fclExpId);
            if (fclExp.Id <= 0)
                return new NullJsonResult();
            await _fclExpService.DeleteContainer(id, fclExpId);
            return new NullJsonResult();
        }
        #endregion

        #region Popup add Carrier

        public ActionResult ContainerAddPopup(string viewId, int id)
        {
            return View(new ContainerListModel() { FclId = id });
        }

        [HttpPost]
        public ActionResult ContainerAddPopup(string viewId, string btnId,
            string formId)
        {
            ViewBag.RefreshPage = true;
            ViewBag.btnId = btnId;
            ViewBag.formId = formId;
            ViewBag.viewId = viewId;

            return View(new ContainerListModel());
        }
        #endregion
      

    }
}