using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Falcon.Web.Mvc.Kendoui;
using Vino.Server.Services.MainServices.Common;
using Vino.Server.Services.MainServices.CRM.Customer;
using Vino.Server.Services.MainServices.CRM.Customer.Models;
using Vino.Server.Web.Areas.Admin.Models.Customer;
using Vino.Shared.Constants.Warehouse;

namespace Vino.Server.Web.Areas.Admin.Controllers
{
    public class CustomersController : BaseController
    {
        private readonly CrmCustomerService _service;
        private readonly OrderGenCodeService _genCodeService;

        public CustomersController(CrmCustomerService service,
            OrderGenCodeService genCodeService)
        {
            _service = service;
            _genCodeService = genCodeService;
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
            var dtoFromRepo = await _service.SearchModels(new SearchingRequest()
            {
                Page = common.Page - 1,
                PageSize = common.PageSize,
                Name = model.Name,
                Address = model.Address,
                ContactId = model.ContactId,
                LocationId = model.LocationId
            });

            var gridModel = new DataSourceResult()
            {
                Data = dtoFromRepo,
                Total = dtoFromRepo.Count()
            };

            return Json(gridModel);
        }

        public ActionResult Create()
        {
            var model = new CrmCustomerModel();

            var now = DateTimeOffset.Now;
            // init code for customer
            var orderGenCode = _genCodeService.GetOrderGenCode(BookPrefixes.Customer, now.LocalDateTime.Date);
            if (orderGenCode != null)
            {
                model.CustomerId = $"{orderGenCode.OrderPrefix}{now:yy}{now.Month:D2}{now.Day:D2}{(orderGenCode.CurrentNumber + 1):D3}";
            }
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

            var now = DateTimeOffset.Now;
            // init code for customer
            var orderGenCode = _genCodeService.GetOrderGenCode(BookPrefixes.Customer, now.LocalDateTime.Date);
            orderGenCode.CurrentNumber += 1;
            _genCodeService.UpdateOrderGenCode(orderGenCode);

            dto.CustomerId = $"{orderGenCode.OrderPrefix}{now:yy}{now.Month:D2}{now.Day:D2}{orderGenCode.CurrentNumber:D3}";

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

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CrmCustomerModel dto)
        {
            if (!ModelState.IsValid)
            {
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

        [HttpPost]
        public async Task<ActionResult> GetCustomerInfo(int customerId)
        {
            var customer = await _service.GetSingleAsync(customerId);
            if (customer == null)
                return null;
            var info = $"{customer.FullVietNamName} - {customer.Address} - {customer.FaxNo}";
            return Json(info);
        }


        [HttpPost]
        public async Task<PartialViewResult> OpenModal(string viewId, string[] viewGroupId, CrmCustomerModel model = null)
        {
            var index = await _service.GetNumberEntry();

            TempData["IdView"] = viewId;
            TempData["IdGroups"] = viewGroupId;
            TempData.Keep();

            if (model == null)
            {
                model = new CrmCustomerModel()
                {
                    CustomerId = "CS" + (index + 1).ToString().PadLeft(3, '0')
                };
            }
            return PartialView("_CreateCustomer", model);
        }

        [HttpPost]
        public async Task<ActionResult> CreateFromSubViewAsync(CrmCustomerModel dto)
        {
            var idGroups = (object[])TempData["IdGroups"];
            var idViews = TempData["IdView"];

            if (!ModelState.IsValid)
            {
                return Json(dto);
            }

            var id = await _service.CreateAsync(dto);
            if (id >= 0)
            {
                SuccessNotification("Create new customer succeed");
                var customer = await _service.GetSingleAsync(id);
                if (customer == null)
                {
                    return RedirectToAction("OpenModal", dto);
                }

                return Json(new 
                {
                    GroupIds = String.Join(",", idGroups),
                    ViewIds = idViews,
                    Name = customer.Name,
                    Value = customer.Id.ToString()
                });
            }

            ErrorNotification("Create new customer failed");
            return new EmptyResult();
        }

        #region Popup add Customer

        public async Task<ActionResult> CustomerAddPopup(string viewId)
        {
            var index = await _service.GetNumberEntry();
            var model = new CrmCustomerModel()
            {
                CustomerId = "CS" + (index + 1).ToString().PadLeft(3, '0'),
            };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> CustomerAddPopup(string viewId, string btnId, string formId
            , CrmCustomerModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

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