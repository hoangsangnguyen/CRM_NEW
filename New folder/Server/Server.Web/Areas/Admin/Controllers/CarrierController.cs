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
using Vino.Server.Services.MainServices.CRM.Carrier;
using Vino.Server.Services.MainServices.CRM.Carrier.Model;
using Vino.Server.Services.MainServices.Users;
using Vino.Server.Web.Areas.Admin.Models.Carriers;
using Vino.Shared.Constants.Common;
using Vino.Shared.Constants.Warehouse;

namespace Vino.Server.Web.Areas.Admin.Controllers
{
    public class CarrierController : BaseController
    {
        private readonly CarrierService _service;
        private readonly LookupService _lookupService;
        private readonly OrderGenCodeService _genCodeService;
        private readonly UserService _userService;
        private readonly WebContext _webContext;

        public CarrierController(CarrierService service,
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
            var dtoFromRepo = await _service.SearchModels(new SearchingRequest()
            {
                Page = common.Page - 1,
                PageSize = common.PageSize,
                Name = model.Name,
                Code = model.Code,
                CountryId = model.CountryId,
                Cell = model.Cell
            });

            var nationalityItems = _lookupService.GetLookupByLookupType(LookupTypes.NationalityType);
            foreach (var contact in dtoFromRepo)
            {
                contact.CountryName = nationalityItems.FirstOrDefault(x => x.Id == contact.CountryId)?.Title;
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
            var model = new CarrierModel();

            var now = DateTimeOffset.Now;
            // init code for customer
            var orderGenCode = _genCodeService.GetOrderGenCode(BookPrefixes.Carrier, now.LocalDateTime.Date);
            if (orderGenCode != null)
            {
                model.Code = $"{orderGenCode.OrderPrefix}{now:yy}{now.Month:D2}{now.Day:D2}{(orderGenCode.CurrentNumber + 1):D3}";
            }
            
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

            var now = DateTimeOffset.Now;
            // init code for customer
            var orderGenCode = _genCodeService.GetOrderGenCode(BookPrefixes.Carrier, now.LocalDateTime.Date);
            orderGenCode.CurrentNumber += 1;
            _genCodeService.UpdateOrderGenCode(orderGenCode);

            dto.Code = $"{orderGenCode.OrderPrefix}{now:yy}{now.Month:D2}{now.Day:D2}{orderGenCode.CurrentNumber:D3}";

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
        public async Task<ActionResult> Edit(CarrierModel dto)
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

    }

   
}