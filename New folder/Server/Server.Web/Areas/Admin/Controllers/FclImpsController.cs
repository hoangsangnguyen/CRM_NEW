using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Falcon.Web.Mvc.Kendoui;
using Vino.Server.Services.MainServices.Common;
using Vino.Server.Services.MainServices.CRM.Carrier;
using Vino.Server.Services.MainServices.CRM.Contact;
using Vino.Server.Services.MainServices.CRM.FclImp;
using Vino.Server.Services.MainServices.CRM.FclImp.Models;
using Vino.Server.Services.MainServices.CRM.Port;
using Vino.Server.Web.Areas.Admin.Models.FclImps;
using Vino.Shared.Constants.Warehouse;

namespace Vino.Server.Web.Areas.Admin.Controllers
{
    public class FclImpsController : BaseController
    {
        private readonly FclImpService _service;
        private readonly OrderGenCodeService _genCodeService;

        public FclImpsController(FclImpService service,
            OrderGenCodeService genCodeService)
        {
            _service = service;
            _genCodeService = genCodeService;
        }
        // GET: Admin/FclImps
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(new FclImpsListModel());
        }

        [HttpPost]
        public async Task<ActionResult> List(DataSourceRequest common, FclImpsListModel model)
        {
            var dtoFromRepo = await _service.GetAllAsync();
            var gridModel = new DataSourceResult()
            {
                Data = dtoFromRepo,
                Total = dtoFromRepo.Count()
            };

            return Json(gridModel);
        }

        public ActionResult Create()
        {
            var model = new FclImpModel()
            {
                Created = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
                Eta = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
                Etd = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
            };
            var now = DateTimeOffset.Now;
            // init code
            var orderGenCode = _genCodeService.GetOrderGenCode(BookPrefixes.FclImp, now.LocalDateTime.Date);
            if (orderGenCode != null)
            {
                model.JobId = $"{orderGenCode.OrderPrefix}{now:yy}{now.Month:D2}" + "/" + $"{(orderGenCode.CurrentNumber + 1):D4}";
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(FclImpModel dto)
        {
            Console.WriteLine(dto);
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var now = DateTimeOffset.Now;
            // init code
            var orderGenCode = _genCodeService.GetOrderGenCode(BookPrefixes.FclImp, now.LocalDateTime.Date);
            orderGenCode.CurrentNumber += 1;
            _genCodeService.UpdateOrderGenCode(orderGenCode);

            dto.JobId = $"{orderGenCode.OrderPrefix}{now:yy}{now.Month:D2}" + "/" + $"{(orderGenCode.CurrentNumber + 1):D4}";

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

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(FclImpModel dto)
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

    }
}