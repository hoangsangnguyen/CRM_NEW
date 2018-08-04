using System;
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

        public ActionResult Create(int? id)
        {
            if (id == null)
                return RedirectToAction("List", "LclExps");
            var siLclExp = _lclExpService.GetSingleAsync(id.Value);
            if (siLclExp.Id <= 0)
                return RedirectToAction("List", "LclExps");

            var model = new LclExpSiModel()
            {
                Etd  = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
                LclExpId = id ?? 0,
                QtyOfContainer = "PART OF CONTAINER"
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
            if (dto.NotifyPartyId == 0)
                dto.NotifyPartyId = dto.ConsigneeId;

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
            var siLclExp = _lclExpService.GetSingleAsync(id);
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
            if (dto.NotifyPartyId == 0)
                dto.NotifyPartyId = dto.ConsigneeId;

            var user = await _userService.GetById(_webContext.UserId);
            dto.UpdateName = user?.UserName ?? "";
            dto.UpdateAt = DateTimeOffset.Now.ToString("dd/MM/yyyy HH:mm:ss");

            await _service.EditAsync(dto.Id, dto);

            //if (dto.Preview)
            //    return RedirectToAction("HblLclExpReport", "CallReport", new { hblLclExpId = dto.Id });

            SuccessNotification("Chỉnh sửa thành công!");
            return RedirectToAction("Edit", new { id = dto.Id });
        }

        public async Task<ActionResult> Preview(int id)
        {
            var entity = await _service.GetSingleAsync(id);
            if (entity == null)
            {
                ErrorNotification("Không tìm thấy phiếu");
                return RedirectToAction("Edit", id);
            }

            var model = entity.MapTo<HblLclExpModel>();
            if (model.NotifyPartyId == model.ConsigneeId)
                model.NotifyPartyName = "SAME AS CONSIGNEE";

            var vesselLookups = _lookupService.GetLookupByLookupType(LookupTypes.VesselType);
            model.OceanVesselName = vesselLookups.FirstOrDefault(x => x.Id == model.OceanVessel)?.Title;
            model.LocalVesselName = vesselLookups.FirstOrDefault(x => x.Id == model.LocalVessel)?.Title;

            return View(model);
        }

        private async Task<HblLclExpModel> GetModel(int id)
        {
            var entity = await _service.GetSingleAsync(id);
            var model = entity.MapTo<HblLclExpModel>();
            if (model.NotifyPartyId == model.ConsigneeId)
                model.NotifyPartyName = "SAME AS CONSIGNEE";

            var vesselLookups = _lookupService.GetLookupByLookupType(LookupTypes.VesselType);
            model.OceanVesselName = vesselLookups.FirstOrDefault(x => x.Id == model.OceanVessel)?.Title;
            model.LocalVesselName = vesselLookups.FirstOrDefault(x => x.Id == model.LocalVessel)?.Title;
            return model;
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