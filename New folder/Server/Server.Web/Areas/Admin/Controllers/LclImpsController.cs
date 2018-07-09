﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Falcon.Web.Mvc.Kendoui;
using Vino.Server.Services.MainServices.Common;
using Vino.Server.Services.MainServices.CRM.Carrier;
using Vino.Server.Services.MainServices.CRM.Contact;
using Vino.Server.Services.MainServices.CRM.LclImp;
using Vino.Server.Services.MainServices.CRM.LclImp.Models;
using Vino.Server.Services.MainServices.CRM.Port;
using Vino.Server.Web.Areas.Admin.Models.LclImps;
using Vino.Shared.Constants.Common;

namespace Vino.Server.Web.Areas.Admin.Controllers
{
    public class LclImpsController : BaseController
    {
        private readonly LclImpService _service;
        private readonly ContactService _contactService;
        private readonly PortService _portService;
        private readonly CarrierService _carrierService;

        private readonly LookupService _lookupService;
        public LclImpsController(LclImpService service, ContactService contactService,
            PortService portService, CarrierService carrierService,
            LookupService lookupService)
        {
            _service = service;
            _contactService = contactService;
            _portService = portService;
            _lookupService = lookupService;
            _carrierService = carrierService;
        }
        // GET: Admin/LclImps
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(new LclImpsListModel());
        }

        [HttpPost]
        public async Task<ActionResult> List(DataSourceRequest common, LclImpsListModel model)
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
            var model = new LclImpModel()
            {
                JobId = "FIL" + DateTimeOffset.Now.Year % 100 + DateTimeOffset.Now.Month.ToString("D2")
                        + "/" + (index + 1).ToString().PadLeft(4, '0'),
                Created = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
                Eta = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
                Etd = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LclImpModel dto)
        {
            Console.WriteLine(dto);
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var index = await _service.GetNumberEntry();
            dto.JobId = "FIL" + DateTimeOffset.Now.Year % 100 + DateTimeOffset.Now.Month.ToString("D2")
                        + "/" + (index + 1).ToString().PadLeft(4, '0');

            var id = await _service.CreateAsync(dto);
            if (id == 0)
            {
                ErrorNotification("Thêm mới thất bại!");
            }
            else
            {
                SuccessNotification("Thêm mới thành công!");
            }
            return RedirectToAction("Edit", new {id});
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
        public async Task<ActionResult> Edit(LclImpModel dto)
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