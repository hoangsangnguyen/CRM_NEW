using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Falcon.Web.Mvc.Kendoui;
using Vino.Server.Services.MainServices.Common;
using Vino.Server.Services.MainServices.CRM.Contact;
using Vino.Server.Services.MainServices.CRM.Contact.Models;
using Vino.Server.Services.MainServices.CRM.Customer;
using Vino.Server.Services.MainServices.CRM.Customer.Models;
using Vino.Server.Web.Areas.Admin.Models.Customer;
using Vino.Shared.Constants.Common;

namespace Vino.Server.Web.Areas.Admin.Controllers
{
    public class CustomersController : BaseController
    {
        private readonly CrmCustomerService _service;
        private readonly LookupService _lookupService;
        private readonly ContactService _contactService;

        public CustomersController(CrmCustomerService service,
            LookupService lookupService,
            ContactService contactService)
        {
            _service = service;
            _lookupService = lookupService;
            _contactService = contactService;
        }

        // GET: Admin/Customer
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(new CustomerListModel());
        }

        [HttpPost]
        public async Task<ActionResult> List(DataSourceRequest common, CustomerListModel model)
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
            var model = new CrmCustomerModel()
            {
                CustomerId = "CS" + (index + 1).ToString().PadLeft(3, '0'),
            };
            await InitDataModel(model);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CrmCustomerModel dto)
        {
            if (!ModelState.IsValid)
            {
                await InitDataModel(dto);
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

            return RedirectToAction("List");
        }

        public async Task<ActionResult> Edit(int id = 0)
        {
            var model = await _service.GetSingleAsync(id);

            if (model == null)
            {
                return RedirectToAction("List");
            }

            await InitDataModel(model);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CrmCustomerModel dto)
        {
            if (!ModelState.IsValid)
            {
                await InitDataModel(dto);
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

        private async Task InitDataModel(CrmCustomerModel model)
        {
            model.ContactItems = await GetContactItems();
            model.LocationItems = GetLocationItems();
            model.CategoriesItems = GetCategoryItems();
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

        private IList<SelectListItem> GetLocationItems()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            var lookups = _lookupService.GetLookupByLookupType(LookupTypes.LocationType);
            foreach (var l in lookups)
                items.Add(new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Title
                });
            return items;
        }

        private IList<SelectListItem> GetCategoryItems()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            var lookups = _lookupService.GetLookupByLookupType(LookupTypes.CategoryType);
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