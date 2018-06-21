using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Falcon.Web.Mvc.Kendoui;
using Vino.Server.Services.MainServices.Common;
using Vino.Server.Services.MainServices.CRM.AirExp;
using Vino.Server.Services.MainServices.CRM.AirExp.Models;
using Vino.Server.Services.MainServices.CRM.Carrier;
using Vino.Server.Services.MainServices.CRM.Contact;
using Vino.Server.Services.MainServices.CRM.Port;
using Vino.Server.Web.Areas.Admin.Models.AirExps;
using Vino.Shared.Constants.Common;

namespace Vino.Server.Web.Areas.Admin.Controllers
{
    public class AirExpsController : BaseController
    {
        private readonly AirExpService _service;
        private readonly ContactService _contactService;
        private readonly PortService _portService;
        private readonly CarrierService _carrierService;

        private readonly LookupService _lookupService;
        public AirExpsController(AirExpService service, ContactService contactService,
            PortService portService, CarrierService carrierService,
            LookupService lookupService)
        {
            _service = service;
            _contactService = contactService;
            _portService = portService;
            _lookupService = lookupService;
            _carrierService = carrierService;
        }

        // GET: Admin/AirExps
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(new AirExpsListModel());
        }

        [HttpPost]
        public async Task<ActionResult> List(DataSourceRequest common, AirExpsListModel model)
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
            var model = new AirExpModel()
            {
                JobId = "AE" + DateTimeOffset.Now.Year % 100 + DateTimeOffset.Now.Month.ToString("D2")
                        + "/" + (index + 1).ToString().PadLeft(4, '0'),
                Created = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
                Eta = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
                Etd = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
                FlyDate = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
            };

            await InitContentForModel(model);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AirExpModel dto)
        {
            if (!ModelState.IsValid)
            {
                await InitContentForModel(dto);
                return View(dto);

            }

            var index = await _service.GetNumberEntry();
            dto.JobId = "AE" + DateTimeOffset.Now.Year % 100 + DateTimeOffset.Now.Month.ToString("D2")
                        + "/" + (index + 1).ToString().PadLeft(4, '0');

            Console.WriteLine(dto);
            var id = await _service.CreateAsync(dto);
            if (id == 0)
            {
                ErrorNotification("Tạo mới thất bại!");
            }
            else
            {
                SuccessNotification("Tạo mới thành công!");
            }
            return RedirectToAction("Edit" , new {id});
        }

        private async Task InitContentForModel(AirExpModel model)
        {
            model.ContactItems = await GetContactItems();
            model.CommodityItems = GetCommodityItems();
            model.ShipmentItems = GetShipmentItems();
            model.PaymentItems = GetPaymentItems();
            model.TypeOfBillItems = GetTypeOfBillItems();
            model.UnitItems = GetUnitItems();
            model.PortItems = await GetPortItems();
            model.CarrierItems = await GetCarrierItems();
        }

        public async Task<ActionResult> Edit(int id = 0)
        {
            var model = await _service.GetSingleAsync(id);

            if (model == null)
            {
                return RedirectToAction("List");
            }

            await InitContentForModel(model);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AirExpModel dto)
        {
            if (!ModelState.IsValid)
            {
                await InitContentForModel(dto);
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
            var contacts = await _portService.GetAllAsync();
            foreach (var l in contacts)
                items.Add(new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.PortName
                });

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

        private IList<SelectListItem> GetPaymentItems()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            var lookups = _lookupService.GetLookupByLookupType(LookupTypes.PaymentType);
            foreach (var l in lookups)
                items.Add(new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Title
                });
            return items;
        }

        private IList<SelectListItem> GetTypeOfBillItems()
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

        private IList<SelectListItem> GetUnitItems()
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