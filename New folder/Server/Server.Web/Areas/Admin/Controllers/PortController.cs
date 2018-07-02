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
            var dtoFromRepo =  await _service.GetAllAsync();
            var nationalityItems = GetNationalityItems();
            var zoneItems = GetZoneItems();
            var modeItems = GetModeItems();

            foreach (var contact in dtoFromRepo)
            {
                contact.NationalityName = nationalityItems.FirstOrDefault(x => x.Value == contact.NationalityId.ToString())?.Text;
                contact.ZoneName = zoneItems.FirstOrDefault(x => x.Value == contact.ZoneId.ToString())?.Text;
                contact.ModeName = modeItems.FirstOrDefault(x => x.Value == contact.ModeId.ToString())?.Text;
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
            var model = new PortModel();
            InitDataModel(model);
           
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PortModel dto)
        {
            if (!ModelState.IsValid)
            {
                InitDataModel(dto);
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

            return RedirectToAction("Edit", new {id});
        }

        public async Task<ActionResult> Edit(int id = 0)
        {
            var model = await _service.GetSingleAsync(id);

            if (model == null)
            {
                return RedirectToAction("List");
            }

            InitDataModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PortModel dto)
        {
            if (!ModelState.IsValid)
            {
                InitDataModel(dto);
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

        private void InitDataModel(PortModel model)
        {
            model.NationalityItems = GetNationalityItems();
            model.ZoneItems = GetZoneItems();
            model.ModeItems = GetModeItems();
        }

        [HttpPost]
        public PartialViewResult OpenModal(string viewId, string[] viewGroupId)
        {
            TempData["IdView"] = viewId;
            TempData["IdGroups"] = viewGroupId;

            var model = new PortModel();
            InitDataModel(model);

            return PartialView("_CreatePort", model);
        }

        [HttpPost]
        public async Task<ActionResult> CreateFromSubViewAsync(PortModel dto)
        {
            if (!ModelState.IsValid)
            {
                InitDataModel(dto);
                return new EmptyResult();
            }

            var id = await _service.CreateAsync(dto);
            if (id >= 0)
            {
                SuccessNotification("Create port succeed");
                var port = await _service.GetSingleAsync(id);
                if (port == null)
                {
                    InitDataModel(dto);
                    return RedirectToAction("OpenModal");
                }

                var idGroups = (object[])TempData["IdGroups"];
                var idViews = TempData["IdView"];

                return Json(new
                {
                    GroupIds = String.Join(",", idGroups),
                    ViewIds = idViews,
                    Value = port.Id.ToString(),
                    Name = port.PortName
                });
            }
            
            ErrorNotification("Create port failed");

            return new EmptyResult();
        }

        private IList<SelectListItem> GetNationalityItems()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            var lookups = _lookupService.GetLookupByLookupType(LookupTypes.NationalityType);
            foreach (var l in lookups)
                items.Add(new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Title
                });
            return items;
        }
        private IList<SelectListItem> GetZoneItems()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            var lookups = _lookupService.GetLookupByLookupType(LookupTypes.ZoneType);
            foreach (var l in lookups)
                items.Add(new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Title
                });
            return items;
        }
        private IList<SelectListItem> GetModeItems()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            var lookups = _lookupService.GetLookupByLookupType(LookupTypes.ModeType);
            foreach (var l in lookups)
                items.Add(new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Title
                });
            return items;
        }


        public class ModelAndViewId
        {
            public PortModel Port { get; set; }
            public string ViewId { get; set; }
            public string ViewGroupId { get; set; }
        }

    }
}