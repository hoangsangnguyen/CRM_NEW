using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Falcon.Web.Mvc.Kendoui;
using Vino.Server.Services.MainServices.Common;
using Vino.Server.Services.MainServices.CRM.Customer;
using Vino.Server.Services.MainServices.CRM.HblLclExp;
using Vino.Server.Services.MainServices.CRM.HblLclExp.Models;
using Vino.Server.Services.MainServices.CRM.Port;
using Vino.Server.Web.Areas.Admin.Models.HblLclExps;
using Vino.Server.Web.Areas.Admin.Models.LclExps;
using Vino.Shared.Constants.Common;

namespace Vino.Server.Web.Areas.Admin.Controllers
{
    public class HblLclExpController : BaseController
    {
        private readonly HblLclExpService _service;
        private readonly CrmCustomerService _customerService;
        private readonly LookupService _lookupService;
        private readonly PortService _portService;


        public HblLclExpController(HblLclExpService service,
            CrmCustomerService customerService,
            LookupService lookupService,
            PortService portService)
        {
            this._service = service;
            _customerService = customerService;
            _lookupService = lookupService;
            _portService = portService;
        }

        // GET: Admin/HblLclExp
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(new HblLclExpListModel());
        }

        [HttpPost]
        public async Task<ActionResult> List(DataSourceRequest common, HblLclExpListModel model)
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

            var model = new HblLclExpModel()
            {
                //JobId = "FLL" + DateTimeOffset.Now.Year % 100 + DateTimeOffset.Now.Month.ToString("D2")
                //        + "/" + (index + 1).ToString().PadLeft(4, '0'),
                //Created = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
                //Eta = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
                //Etd = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
            };

            await InitContentForModel(model);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(HblLclExpModel dto)
        {


            if (!ModelState.IsValid)
            {
                await InitContentForModel(dto);
                return View(dto);
            }
            var index = await _service.GetNumberEntry();
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

            await InitContentForModel(model);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(HblLclExpModel dto)
        {
            if (!ModelState.IsValid)
            {
                await InitContentForModel(dto);
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

        private async Task InitContentForModel(HblLclExpModel model)
        {
            model.CustomerItems = await GetCustomerItems();
            model.HblTypeItems = GetTypeOfBillItems();
            model.PortItems = await GetPortItems();
            model.CommodityItems = GetCommodityItems();
            model.UnitItems = GetUnitItems();
            model.VesselItems = GetVesselItems();
            model.CountryItems = GetNationalityItems();
        }

        private async Task<IList<SelectListItem>> GetCustomerItems()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            var customers = await _customerService.GetAllAsync();
            foreach (var l in customers)
                items.Add(new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Name
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

        private IList<SelectListItem> GetVesselItems()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            var lookups = _lookupService.GetLookupByLookupType(LookupTypes.VesselType);
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
    }
}