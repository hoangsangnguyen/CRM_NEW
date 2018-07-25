using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Falcon.Web.Mvc.Kendoui;
using Falcon.Web.Mvc.Security;
using Vino.Server.Services.MainServices.Common;
using Vino.Server.Services.MainServices.Common.Models;
using Vino.Server.Services.MainServices.CRM.Contact;
using Vino.Server.Services.MainServices.CRM.Contact.Models;
using Vino.Server.Services.MainServices.Users;
using Vino.Server.Web.Areas.Admin.Models.Contact;
using Vino.Shared.Constants.Common;
using Vino.Shared.Constants.Warehouse;

namespace Vino.Server.Web.Areas.Admin.Controllers
{
    public class ContactController : BaseController
    {
        private readonly ContactService _service;
        private readonly LookupService _lookupService;
        private readonly OrderGenCodeService _genCodeService;
        private readonly UserService _userService;
        private readonly WebContext _webContext;

        public ContactController(ContactService service,
            LookupService lookupService,
            OrderGenCodeService genCodeService,
            UserService userService,
            WebContext webContext)
        {
            _service = service;
            _lookupService = lookupService;
            _genCodeService = genCodeService;
            _userService = userService;
            _webContext = webContext;
        }

        #region Contact
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(new ContactListModel());
        }

        [HttpPost]
        public async Task<ActionResult> List(DataSourceRequest common, ContactListModel model)
        {
            var dtoFromRepo = await _service.SearchModels(new SearchingRequest()
            {
                Page = common.Page - 1,
                PageSize = common.PageSize,
                Name = model.Name,
                Address = model.Address,
                PositionId = model.PositionId,
                DepartmentId = model.DepartmentId
            });

            var positionItems = _lookupService.GetLookupByLookupType(LookupTypes.PositionType);
            var departmentItems = _lookupService.GetLookupByLookupType(LookupTypes.DepartmentType);
            foreach (var contact in dtoFromRepo)
            {
                contact.PositionName = positionItems.FirstOrDefault(x => x.Id == contact.PositionId)?.Title;
                contact.DepartmentName = departmentItems.FirstOrDefault(x => x.Id == contact.DepartmentId)?.Title;
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
            var model = new CrmContactModel()
            {
                Birthday = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
                SpouseBirthday = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
            };

            var now = DateTimeOffset.Now;
            // init code for customer
            var orderGenCode = _genCodeService.GetOrderGenCode(BookPrefixes.Contact, now.LocalDateTime.Date);
            if (orderGenCode != null)
            {
                model.ContactId = $"{orderGenCode.OrderPrefix}{now:yy}{now.Month:D2}{now.Day:D2}{(orderGenCode.CurrentNumber + 1):D3}";
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CrmContactModel dto)
        {

            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var now = DateTimeOffset.Now;
            // init code for contact
            var orderGenCode = _genCodeService.GetOrderGenCode(BookPrefixes.Contact, now.LocalDateTime.Date);
            orderGenCode.CurrentNumber += 1;
            _genCodeService.UpdateOrderGenCode(orderGenCode);
            dto.ContactId = $"{orderGenCode.OrderPrefix}{now:yy}{now.Month:D2}{now.Day:D2}{orderGenCode.CurrentNumber:D3}";

            dto.CreatedAt = now.ToString("dd/MM/yyyy HH:mm:ss");
            var user = await _userService.GetById(_webContext.UserId);
            dto.CreatorId = user.Id;

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
        public async Task<ActionResult> Edit(CrmContactModel dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var user = await _userService.GetById(_webContext.UserId);
            dto.UpdateName = user?.UserName ?? "";
            dto.UpdateAt = DateTimeOffset.Now.ToString("dd/MM/yyyy HH:mm:ss");

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

        #region Popup add Contact

        public ActionResult ContactAddPopup(string viewId)
        {
            var model = new CrmContactModel();
            var now = DateTimeOffset.Now;
            // init code for customer
            var orderGenCode = _genCodeService.GetOrderGenCode(BookPrefixes.Contact, now.LocalDateTime.Date);
            if (orderGenCode != null)
            {
                model.ContactId = $"{orderGenCode.OrderPrefix}{now:yy}{now.Month:D2}{now.Day:D2}{(orderGenCode.CurrentNumber + 1):D3}";
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> ContactAddPopup(string viewId, string btnId,
            string formId, CrmContactModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var now = DateTimeOffset.Now;
            // init code for contact
            var orderGenCode = _genCodeService.GetOrderGenCode(BookPrefixes.Contact, now.LocalDateTime.Date);
            orderGenCode.CurrentNumber += 1;
            _genCodeService.UpdateOrderGenCode(orderGenCode);
            request.ContactId = $"{orderGenCode.OrderPrefix}{now:yy}{now.Month:D2}{now.Day:D2}{orderGenCode.CurrentNumber:D3}";

            request.CreatedAt = now.ToString("dd/MM/yyyy HH:mm:ss");
            var user = await _userService.GetById(_webContext.UserId);
            request.CreatorId = user.Id;

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

        // GET: Admin/Contact

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

    }

}