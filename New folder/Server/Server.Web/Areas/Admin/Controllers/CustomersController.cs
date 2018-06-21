using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Falcon.Web.Mvc.Kendoui;
using Vino.Server.Services.MainServices.Common;
using Vino.Server.Services.MainServices.CRM.Contact.Models;
using Vino.Server.Services.MainServices.CRM.Customer;
using Vino.Server.Services.MainServices.CRM.Customer.Models;

namespace Vino.Server.Web.Areas.Admin.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CrmCustomerService _service;
        private readonly LookupService _lookupService;
        public CustomersController(CrmCustomerService service, LookupService lookupService)
        {
            _service = service;
            _lookupService = lookupService;
        }

        // GET: Admin/Customer
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

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CrmCustomerModel dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var id = await _service.CreateAsync(dto);
            if (id >= 0)
            {
                Console.WriteLine("Create customer failed");
            }
            else
            {
                Console.WriteLine("Create customer succeed");
            }

            return RedirectToAction("List");
        }

    }
}