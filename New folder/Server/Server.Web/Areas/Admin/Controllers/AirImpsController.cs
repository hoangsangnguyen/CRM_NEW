using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Falcon.Web.Mvc.Kendoui;
using Vino.Server.Services.MainServices.Common;
using Vino.Server.Services.MainServices.CRM.AirExp;
using Vino.Server.Services.MainServices.CRM.AirImp;
using Vino.Server.Services.MainServices.CRM.AirImp.Models;
using Vino.Server.Services.MainServices.CRM.Carrier;
using Vino.Server.Services.MainServices.CRM.Contact;
using Vino.Server.Services.MainServices.CRM.FclExp;
using Vino.Server.Services.MainServices.CRM.FclExp.Models;
using Vino.Server.Services.MainServices.CRM.Port;
using Vino.Server.Web.Areas.Admin.Models.AirImps;
using Vino.Shared.Constants.Common;

namespace Vino.Server.Web.Areas.Admin.Controllers
{
    public class AirImpsController : BaseController
    {
        private readonly AirImpService _service;
        private readonly ContactService _contactService;
        private readonly PortService _portService;
        private readonly CarrierService _carrierService;

        private readonly LookupService _lookupService;
        public AirImpsController(AirImpService service, ContactService contactService,
            PortService portService, CarrierService carrierService,
            LookupService lookupService)
        {
            _service = service;
            _contactService = contactService;
            _portService = portService;
            _lookupService = lookupService;
            _carrierService = carrierService;
        }
        // GET: Admin/AirImps
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(new AirImpListModel());
        }

        [HttpPost]
        public async Task<ActionResult> List(DataSourceRequest common, AirImpListModel model)
        {
            var dtoFromRepo = await _service.GetAllAsync();
            var gridModel = new DataSourceResult()
            {
                Data = dtoFromRepo,
                Total = dtoFromRepo.Count()
            };

            return Json(gridModel);
        }

        public async Task<ActionResult> Create()
        {
            var index = await _service.GetNumberEntry();
            var model = new AirImpModel()
            {
                JobId = "AI" + DateTimeOffset.Now.Year % 100 + DateTimeOffset.Now.Month.ToString("D2")
                        + "/" + (index + 1).ToString().PadLeft(4, '0'),
                Created = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
                Eta = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
                FLyDate = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),

            };

            await InitDataForModel(model);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AirImpModel dto)
        {
            Console.WriteLine(dto);
            if (!ModelState.IsValid)
            {
                await InitDataForModel(dto);
                return View(dto);
            }

            var index = await _service.GetNumberEntry();
            dto.JobId = "AI" + DateTimeOffset.Now.Year % 100 + DateTimeOffset.Now.Month.ToString("D2")
                        + "/" + (index + 1).ToString().PadLeft(4, '0');
            var id = await _service.CreateAsync(dto);
            if (id == 0)
            {
                ErrorNotification("Thêm mới thất bại!");
            }
            else
            {
                SuccessNotification("Thêm mới thành công!");
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

            await InitDataForModel(model);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AirImpModel dto)
        {
            if (!ModelState.IsValid)
            {
                await InitDataForModel(dto);
                return View(dto);
            }

            Console.WriteLine(dto);
            await _service.EditAsync(dto.Id, dto);
            SuccessNotification("Chỉnh sửa thành công!");

            return RedirectToAction("Edit", new {id = dto.Id});
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

        private async Task InitDataForModel(AirImpModel model)
        {
            model.CarrierItems = await GetCarrierItems();
            model.ContactItems = await GetContactItems();
            model.CommodityItems = GetCommodityItems();
            model.ShipmentItems = GetShipmentItems();
            model.PortItems = await GetPortItems();
            model.TypeOfBillItems = GetTypeOfBIllsItems();
            model.UnitItems = GetUnitsItems();

        }

        private async Task<IList<SelectListItem>> GetContactItems()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            var contacts = await _contactService.GetAllAsync();
            foreach (var l in contacts)
                items.Add(new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.EnglishName
                });

            return items;
        }

        private async Task<IList<SelectListItem>> GetCarrierItems()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            var contacts = await _carrierService.GetAllAsync();
            foreach (var l in contacts)
                items.Add(new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Name
                });

            return items;
        }
        private async Task<IList<SelectListItem>> GetPortItems()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            var ports = await _portService.GetAllAsync();
            foreach (var port in ports)
            {
                items.Add(new SelectListItem()
                {
                    Value = port.Id.ToString(),
                    Text = port.PortName
                });
            }

            return items;
        }
        private IList<SelectListItem> GetCommodityItems()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            var lookups = _lookupService.GetLookupByLookupType(LookupTypes.CommoditiesType);
            foreach (var l in lookups)
                items.Add(new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Title
                });
            return items;
        }
        private IList<SelectListItem> GetShipmentItems()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            var lookups = _lookupService.GetLookupByLookupType(LookupTypes.ShipmentType);
            foreach (var l in lookups)
                items.Add(new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Title
                });
            return items;
        }

        private IList<SelectListItem> GetTypeOfBIllsItems()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            var lookups = _lookupService.GetLookupByLookupType(LookupTypes.TypeOfBill);
            foreach (var l in lookups)
                items.Add(new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Title
                });
            return items;
        }
        private IList<SelectListItem> GetUnitsItems()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            var lookups = _lookupService.GetLookupByLookupType(LookupTypes.UnitType);
            foreach (var l in lookups)
                items.Add(new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Title
                });
            return items;
        }
    }
}