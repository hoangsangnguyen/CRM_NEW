﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Falcon.Web.Core.Helpers;
using Falcon.Web.Mvc.Kendoui;
using Falcon.Web.Mvc.Security;
using Vino.Server.Services.MainServices.Common;
using Vino.Server.Services.MainServices.CRM.Customer;
using Vino.Server.Services.MainServices.CRM.HblLclExp.Models;
using Vino.Server.Services.MainServices.CRM.LclExp;
using Vino.Server.Services.MainServices.CRM.Port;
using Vino.Server.Services.MainServices.CRM.ShippingInstruction.LclExp;
using Vino.Server.Services.MainServices.CRM.Topic;
using Vino.Server.Services.MainServices.Users;
using Vino.Server.Web.Areas.Admin.Models.HblLclExps;
using Vino.Server.Web.Areas.Admin.Models.SiLclExp;
using Vino.Shared.Constants.Common;
using Vino.Shared.Constants.Warehouse;
using SearchingRequest = Vino.Server.Services.MainServices.CRM.ShippingInstruction.LclExp.SearchingRequest;

namespace Vino.Server.Web.Areas.Admin.Controllers
{
    public class SiLclExpController : BaseController
    {
        private readonly LclExpSiService _service;
        private readonly CrmCustomerService _customerService;
        private readonly TopicService _topicService;
        private readonly OrderGenCodeService _genCodeService;
        private readonly LclExpService _lclExpService;
        private readonly PortService _portService;
        private readonly UserService _userService;
        private readonly WebContext _webContext;
        private readonly LookupService _lookupService;

        public SiLclExpController(LclExpSiService service,
            CrmCustomerService customerService,
            TopicService topicService,
            OrderGenCodeService genCodeService,
            LclExpService lclExpService,
            PortService portService,
            UserService userService,
            WebContext webContext,
            LookupService lookupService)
        {
            _service = service;
            _customerService = customerService;
            _topicService = topicService;
            _genCodeService = genCodeService;
            _lclExpService = lclExpService;
            _portService = portService;
            _userService = userService;
            _webContext = webContext;
            _lookupService = lookupService;
        }

        // GET: Admin/LclExpSi
        #region HblLclExp
        // GET: Admin/HblLclExp
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List(int? id)
        {
            if (id == null)
                return RedirectToAction("List", "LclExps");
            var siLclExp = _lclExpService.GetSingleAsync(id.Value);
            if (siLclExp.Id <= 0)
                return RedirectToAction("List", "LclExps");

            return View(new SiLclExpListModel()
            {
                LclExpId = id
            });
        }

        [HttpPost]
        public async Task<ActionResult> List(DataSourceRequest common, SiLclExpListModel model)
        {
            var dateFrom = string.IsNullOrWhiteSpace(model.FromDt) ? (DateTimeOffset?)null : DateTimeOffset.Parse(model.FromDt, new CultureInfo("vi-VN"));
            var dateTo = string.IsNullOrWhiteSpace(model.ToDt) ? (DateTimeOffset?)null : DateTimeOffset.Parse(model.ToDt, new CultureInfo("vi-VN"));

            var dtoFromRepo = await _service.SearchModels(new SearchingRequest()
            {
                Page = common.Page - 1,
                PageSize = common.PageSize,
                FromDt = dateFrom,
                ToDt = dateTo,
                LclExpId = model.LclExpId,
                ReferenceNo = model.ReferenceNo,
                BookingNumber = model.BookingNumber,
                ShipperId = model.ShipperId,
                ConsigneeId = model.ConsigneeId
            });

            var gridModel = new DataSourceResult()
            {
                Data = dtoFromRepo,
                Total = dtoFromRepo.Count()
            };

            return Json(gridModel);
        }

        public async Task<ActionResult> Create(int? id)
        {
            if (id == null)
                return RedirectToAction("List", "LclExps");
            var lclExp = await _lclExpService.GetSingleAsync(id.Value);
            if (lclExp.Id <= 0)
                return RedirectToAction("List", "LclExps");

            var siLclExp = await _service.GetSingleAsyncByLclExpId(id.Value);
            if (siLclExp != null)
                return RedirectToAction("Edit", new {id = siLclExp.Id});

            var company = await _topicService.GetTopicByTopicType(TopicType.Company);
            
            var model = new LclExpSiModel()
            {
                Etd  = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
                BookingNumber = lclExp?.BkgNumber,
                LclExpId = id,
                QtyOfContainer = "PART OF CONTAINER",
                ReferenceNo = lclExp.JobId,
                ShipperInfo = company != null ? company?.Name + "\n" + company?.Address + "\nTel: "
                              + company?.Phone : "",
                ColoaderName = lclExp.CoLoaderName
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LclExpSiModel dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var now = DateTimeOffset.Now;

            var lclExpId = dto.LclExpId;
            var lclExp = await _lclExpService.GetSingleAsync(lclExpId??0);
            if (lclExp == null)
            {
                ErrorNotification("Tạo mới thất bại!");
                return View(dto);
            }

            dto.CreatedAt = now.ToString("dd/MM/yyyy HH:mm:ss");
            var user = await _userService.GetById(_webContext.UserId);
            dto.CreatorId = user.Id;

            // same as consignee

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
            if (id == 0)
                return RedirectToAction("List", "LclExps");
            var siLclExp = await _service.GetSingleAsync(id);
            if (siLclExp.Id <= 0)
                return RedirectToAction("List", "LclExps");

            var model = await _service.GetSingleAsync(id);

            if (model == null)
            {
                return RedirectToAction("List");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(LclExpSiModel dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            // same as consignee

            var user = await _userService.GetById(_webContext.UserId);
            dto.UpdateName = user?.UserName ?? "";
            dto.UpdateAt = DateTimeOffset.Now.ToString("dd/MM/yyyy HH:mm:ss");

            await _service.EditAsync(dto.Id, dto);

            // print report
            if (dto.Preview)
                return RedirectToAction("SiLclExpReport", "CallReport", new { siLclExpId = dto.Id });

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

    }
}