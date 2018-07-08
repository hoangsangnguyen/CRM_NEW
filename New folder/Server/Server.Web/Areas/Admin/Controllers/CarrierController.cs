using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Falcon.Web.Mvc.Kendoui;
using Vino.Server.Services.MainServices.Common;
using Vino.Server.Services.MainServices.Common.Models;
using Vino.Server.Services.MainServices.CRM.Carrier;
using Vino.Server.Services.MainServices.CRM.Carrier.Model;
using Vino.Server.Services.MainServices.CRM.Contact.Models;
using Vino.Server.Web.Areas.Admin.Models.Carriers;
using Vino.Shared.Constants.Common;

namespace Vino.Server.Web.Areas.Admin.Controllers
{
    public class CarrierController : BaseController
    {
        private readonly CarrierService _service;
        private readonly LookupService _lookupService;
        public CarrierController(CarrierService service, LookupService lookupService)
        {
            _service = service;
            _lookupService = lookupService;
        }

        #region Carrier

        // GET: Admin/Carrier
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(new CarriersListModel());
        }

        [HttpPost]
        public async Task<ActionResult> List(DataSourceRequest common, CarriersListModel model)
        {
            var dtoFromRepo = await _service.GetAllAsync();
            var nationalityItems = GetNationalityItems();
            foreach (var contact in dtoFromRepo)
            {
                contact.CountryName = nationalityItems.FirstOrDefault(x => x.Value == contact.CountryId.ToString())?.Text;
            }
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

            CarrierModel model = new CarrierModel()
            {
                Code = "CL" + (index + 1).ToString().PadLeft(4, '0'),
                CountryItems = GetNationalityItems()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CarrierModel dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var index = await _service.GetNumberEntry();
            dto.Code = "CL" + (index + 1).ToString().PadLeft(4, '0');

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

            model.CountryItems = GetNationalityItems();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CarrierModel dto)
        {
            if (!ModelState.IsValid)
            {
                dto.CountryItems = GetNationalityItems();
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


        #region Popup add Carrier

        public async Task<ActionResult> CarrierAddPopup(string viewId)
        {
            var index = await _service.GetNumberEntry();

            var model = new CarrierModel()
            {
                Code = "CL" + (index + 1).ToString().PadLeft(4, '0'),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> CarrierAddPopup(string viewId, string btnId,
            string formId, CarrierModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            var index = await _service.GetNumberEntry();
            request.Code = "CL" + (index + 1).ToString().PadLeft(4, '0');
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

        [HttpPost]
        public async Task<ActionResult> CreateFromSubViewAsync(CarrierModel dto)
        {
            if (!ModelState.IsValid)
            {
                dto.CountryItems = GetNationalityItems();
                return new EmptyResult();
            }

            var id = await _service.CreateAsync(dto);
            if (id >= 0)
            {
                Console.WriteLine("Create carrier succeed");
                var carrier = await _service.GetSingleAsync(id);
                if (carrier == null)
                    return new EmptyResult();

                var name = carrier.FullEnglishName;
                return Json(new NameValueModel()
                {
                    Value = id.ToString(),
                    Name = name
                });
            }
            Console.WriteLine("Create carrier succeed");

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

        [HttpPost]
        public ActionResult GetNationalityItemsFromView()
        {
            var items = new List<NameValueModel>();
            var lookups = _lookupService.GetLookupByLookupType(LookupTypes.NationalityType);
            foreach (var l in lookups)
                items.Add(new NameValueModel()
                {
                    Value = l.Id.ToString(),
                    Name = l.Title
                });
            return Json(items);
        }

        [HttpPost]
        public async Task<PartialViewResult> OpenModal(string viewId, string viewGroupId)
        {
            var index = await _service.GetNumberEntry();

            var viewModel = new ModelAndViewId()
            {
                Carrier = new CarrierModel()
                {
                    Code = "CL" + (index + 1).ToString().PadLeft(4, '0'),
                    CountryItems = GetNationalityItems()
                },
                ViewId = viewId,
                ViewGroupId = viewGroupId
            };
            return PartialView("_CreateCarrier", viewModel);
        }

        public class ModelAndViewId
        {
            public CarrierModel Carrier { get; set; }
            public string ViewId { get; set; }
            public string ViewGroupId { get; set; }
        }
    }

   
}