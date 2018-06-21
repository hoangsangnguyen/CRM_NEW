using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Falcon.Web.Mvc.Kendoui;
using Vino.Server.Services.MainServices.Common;
using Vino.Server.Services.MainServices.Common.Models;
using Vino.Server.Services.MainServices.CRM.AirExp;
using Vino.Server.Services.MainServices.CRM.AirExp.Models;
using Vino.Server.Services.MainServices.CRM.Contact;
using Vino.Server.Services.MainServices.CRM.Contact.Models;
using Vino.Shared.Constants.Common;

namespace Vino.Server.Web.Areas.Admin.Controllers
{
    public class ContactController : BaseController
    {
        private readonly ContactService _service;
        private readonly LookupService _lookupService;
        public ContactController(ContactService service, LookupService lookupService)
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
            var dtoFromRepo = await _service.GetAllAsync();
            var positionItems = GetPositionItems();
            var departmentItems = GetDepartmentItems();

            foreach (var contact in dtoFromRepo)
            {
                contact.PositionName = positionItems.FirstOrDefault(x => x.Value == contact.PositionId.ToString())?.Text;
                contact.DepartmentName = departmentItems.FirstOrDefault(x => x.Value == contact.DepartmentId.ToString())?.Text;
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
            var model = new CrmContactModel()
            {
                ContactId = "CT" + (index + 1).ToString().PadLeft(3, '0'),
                Birthday = DateTimeOffset.Now.Date,
                SpouseBirthday = DateTimeOffset.Now.Date,
                PositionItems = GetPositionItems(),
                DepartmentItems = GetDepartmentItems()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CrmContactModel dto)
        {


            if (!ModelState.IsValid)
            {
                dto.PositionItems = GetPositionItems();
                dto.DepartmentItems = GetDepartmentItems();
                return View(dto);
            }

            var id = await _service.CreateAsync(dto);
            if (id >= 0)
            {
                Console.WriteLine("Create contact failed");
            }
            else
            {
                Console.WriteLine("Create contact succeed");
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<ActionResult> CreateContactFromSubView(CrmContactModel dto)
        {
            if (!ModelState.IsValid)
            {
                //dto.PositionItems = GetPositionItems();
                //dto.DepartmentItems = GetDepartmentItems();
                return new EmptyResult();
            }

            var id = await _service.CreateAsync(dto);
            if (id >= 0)
            {
                Console.WriteLine("Create contact succeed");
                var crmContact = await _service.GetSingleAsync(id);
                if (crmContact == null)
                {
                    return new EmptyResult();
                }

                var name = crmContact.EnglishName;
                return Json(new NameValueModel()
                {
                    Value = id.ToString(),
                    Name = name
                });
            }
            Console.WriteLine("Create contact failed");
            return new EmptyResult();
        }

        public IList<SelectListItem> GetPositionItems()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            var lookups = _lookupService.GetLookupByLookupType(LookupTypes.PositionType);
            foreach (var l in lookups)
                items.Add(new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Title
                });
            return items;
        }

        [HttpPost]
        public async Task<PartialViewResult> OpenModal(string viewId, string viewGroupId)
        {
            var index = await _service.GetNumberEntry();

            var viewModel = new ModelAndViewId()
            {
                Contact = new CrmContactModel()
                {
                    ContactId = "CT" + (index + 1).ToString().PadLeft(3, '0'),
                    Birthday = DateTimeOffset.Now.Date,
                    SpouseBirthday = DateTimeOffset.Now.Date,
                    PositionItems = GetPositionItems(),
                    DepartmentItems = GetDepartmentItems()
                },
                ViewId = viewId,
                ViewGroupId = viewGroupId
            };

            return PartialView("_CreateContact", viewModel);
        }

        public IList<SelectListItem> GetDepartmentItems()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            var lookups = _lookupService.GetLookupByLookupType(LookupTypes.DepartmentType);
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
            public CrmContactModel Contact { get; set; }
            public string ViewId { get; set; }
            public string ViewGroupId { get; set; }
        }

    }

}