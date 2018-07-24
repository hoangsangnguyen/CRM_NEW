using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Falcon.Web.Mvc.Kendoui;
using Vino.Server.Services.MainServices.Common;
using Vino.Server.Services.MainServices.Common.Models;
using Vino.Server.Services.MainServices.CRM.Port;
using Vino.Server.Services.MainServices.CRM.Port.Model;
using Vino.Server.Web.Areas.Admin.Models.Ports;
using Vino.Shared.Constants.Common;

namespace Vino.Server.Web.Areas.Admin.Controllers
{
    public class PortController : BaseController
    {
        private readonly PortService _service;
        private readonly LookupService _lookupService;
        public PortController(PortService service, LookupService lookupService)
        {
            _service = service;
            _lookupService = lookupService;
        }

        #region Port
        // GET: Admin/Contact
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(new PortsListModel());
        }

        [HttpPost]
        public async Task<ActionResult> List(DataSourceRequest common, PortsListModel model)
        {
            var dtoFromRepo = await _service.SearchModels(new SearchingRequest()
            {
                Page = common.Page - 1,
                PageSize = common.PageSize,
                PortName = model.PortName,
                PortCode = model.PortCode,
                NationalityId = model.NationalityId,
                ModeId = model.ModeId
            });

            var nationalityItems = _lookupService.GetLookupByLookupType(LookupTypes.NationalityType);
            var zoneItems = _lookupService.GetLookupByLookupType(LookupTypes.ZoneType);
            var modeItems = _lookupService.GetLookupByLookupType(LookupTypes.ModeType);

            foreach (var contact in dtoFromRepo)
            {
                contact.NationalityName = nationalityItems.FirstOrDefault(x => x.Id == contact.NationalityId)?.Title;
                contact.ZoneName = zoneItems.FirstOrDefault(x => x.Id == contact.ZoneId)?.Title;
                contact.ModeName = modeItems.FirstOrDefault(x => x.Id == contact.ModeId)?.Title;
            }

            var gridModel = new DataSourceResult()
            {
                Data = dtoFromRepo,
                Total = dtoFromRepo.Count()
            };

            return Json(gridModel);
        }

        public ActionResult Create()
        {
            return View(new PortModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PortModel dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var id = await _service.CreateAsync(dto);
            if (id == 0)
            {
                ErrorNotification("Tạo mới thất bại!");
            }
            else
            {
                SuccessNotification("Tạo mới thành công!");
            }

            return RedirectToAction("Edit", new { id });
        }

        public async Task<ActionResult> Edit(int id = 0)
        {
            var model = await _service.GetSingleAsync(id);

            if (model == null)
            {
                return RedirectToAction("List");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PortModel dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            Console.WriteLine(dto);
            await _service.EditAsync(dto.Id, dto);

            SuccessNotification("Chỉnh sửa thành công!");
            return RedirectToAction("Edit", new { id = dto.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {

            var news = await _service.GetSingleAsync(id);
            if (news == null)
            {
                ErrorNotification("Xóa thất bại!");
                return RedirectToAction("List");
            }

            await _service.DeleteAsync(id);
            SuccessNotification("Xóa thành công!");
            return RedirectToAction("List");
        }
      
        #endregion

        #region Popup add Port

        public ActionResult PortAddPopup(string viewId)
        {
            var model = new PortModel();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> PortAddPopup(string viewId, string btnId,
            string formId, PortModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var id = await _service.CreateAsync(request);
            if (id == 0)
            {
                ErrorNotification("Tạo mới thất bại!");
            }
            else
            {
                request.Id = id;
                SuccessNotification("Tạo mới thành công!");
            }

            ViewBag.RefreshPage = true;
            ViewBag.btnId = btnId;
            ViewBag.formId = formId;
            ViewBag.viewId = viewId;

            return View(request);
        }
        #endregion
    }
}