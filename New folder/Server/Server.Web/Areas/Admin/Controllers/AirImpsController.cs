using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Falcon.Web.Mvc.Kendoui;
using Vino.Server.Services.MainServices.Common;
using Vino.Server.Services.MainServices.CRM.AirImp;
using Vino.Server.Services.MainServices.CRM.AirImp.Models;
using Vino.Server.Web.Areas.Admin.Models.AirImps;
using Vino.Shared.Constants.Common;
using Vino.Shared.Constants.Warehouse;

namespace Vino.Server.Web.Areas.Admin.Controllers
{
    public class AirImpsController : BaseController
    {
        private readonly AirImpService _service;
        private readonly OrderGenCodeService _genCodeService;

        public AirImpsController(AirImpService service,
            OrderGenCodeService genCodeService)
        {
            _service = service;
            _genCodeService = genCodeService;
        }
        // GET: Admin/AirImps
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(new AirImpListModel());
        }

        [HttpPost]
        public async Task<ActionResult> List(DataSourceRequest common, AirImpListModel model)
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
            var model = new AirImpModel()
            {
                Created = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
                Eta = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
                FLyDate = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),

            };

            var now = DateTimeOffset.Now;
            // init code for customer
            var orderGenCode = _genCodeService.GetOrderGenCode(BookPrefixes.AirImp, now.LocalDateTime.Date);
            if (orderGenCode != null)
            {
                model.JobId = $"{orderGenCode.OrderPrefix}{now:yy}{now.Month:D2}" + "/" + $"{(orderGenCode.CurrentNumber + 1):D4}";
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AirImpModel dto)
        {
            Console.WriteLine(dto);
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var now = DateTimeOffset.Now;
            // init code for customer
            var orderGenCode = _genCodeService.GetOrderGenCode(BookPrefixes.AirImp, now.LocalDateTime.Date);
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
        public async Task<ActionResult> Edit(AirImpModel dto)
        {
            if (!ModelState.IsValid)
            {
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
    }
}