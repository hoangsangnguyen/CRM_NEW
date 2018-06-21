using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Falcon.Web.Mvc.Kendoui;
using Vino.Server.Services.MainServices.Common;
using Vino.Server.Services.MainServices.Common.Models;
using Vino.Server.Services.MainServices.CRM.Carrier.Model;
using Vino.Server.Services.MainServices.CRM.Contact.Models;
using Vino.Server.Services.MainServices.CRM.Port;
using Vino.Server.Services.MainServices.CRM.Port.Model;
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
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> GetList()
        {
            var dtoFromRepo =  await _service.GetAllAsync();

            var gridModel = new DataSourceResult()
            {
                Data = dtoFromRepo,
                Total = dtoFromRepo.Count()
            };

            return Json(gridModel);
        }

        public ActionResult Create()
        {
            var model = new PortModel()
            {
                NationalityItems = GetNationalityItems(),
                ZoneItems =  GetZoneItems(),
                ModeItems = GetModeItems(),
            };
           
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PortModel dto)
        {
            if (!ModelState.IsValid)
            {
                dto.ZoneItems =  GetZoneItems();
                dto.ModeItems = GetModeItems();
                dto.NationalityItems = GetNationalityItems();
                return View(dto);
            }

            var id = await _service.CreateAsync(dto);
            if (id >= 0)
            {
                Console.WriteLine("Create port failed");
            }
            else
            {
                Console.WriteLine("Create port succeed");
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<ActionResult> CreateFromSubViewAsync(PortModel dto)
        {
            if (!ModelState.IsValid)
            {
                //dto.ZoneItems = GetZoneItems();
                //dto.ModeItems = GetModeItems();
                //dto.NationalityItems = GetNationalityItems();
                return new EmptyResult();
            }

            var id = await _service.CreateAsync(dto);
            if (id >= 0)
            {
                Console.WriteLine("Create port succeed");
                var port = await _service.GetSingleAsync(id);
                if (port == null)
                    return new EmptyResult();

                var name = port.PortName;
                return Json(new NameValueModel()
                {
                    Value = id.ToString(),
                    Name = name
                });
            }
            Console.WriteLine("Create port succeed");

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

        [HttpPost]
        public PartialViewResult OpenModal(string viewId, string viewGroupId)
        {
            var viewModel = new ModelAndViewId()
            {
                Port = new PortModel()
                {
                    ZoneItems = GetZoneItems(),
                    ModeItems = GetModeItems(),
                    NationalityItems = GetNationalityItems(),
                },
                ViewId = viewId,
                ViewGroupId = viewGroupId
            };
            return PartialView("_CreatePort", viewModel);
        }

        public class ModelAndViewId
        {
            public PortModel Port { get; set; }
            public string ViewId { get; set; }
            public string ViewGroupId { get; set; }
        }

    }
}