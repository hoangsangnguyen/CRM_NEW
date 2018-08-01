using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Falcon.Web.Core.Helpers;
using Falcon.Web.Mvc.Kendoui;
using Falcon.Web.Mvc.Security;
using Vino.Server.Services.MainServices.Common;
using Vino.Server.Services.MainServices.CRM.Customer;
using Vino.Server.Services.MainServices.CRM.HblFclExp;
using Vino.Server.Services.MainServices.CRM.HblFclExp.Models;
using Vino.Server.Services.MainServices.CRM.LclExp;
using Vino.Server.Services.MainServices.CRM.Pdf.Models;
using Vino.Server.Services.MainServices.CRM.Port;
using Vino.Server.Services.MainServices.CRM.Topic;
using Vino.Server.Services.MainServices.Users;
using Vino.Server.Web.Areas.Admin.Models.HblFclExps;
using Vino.Server.Web.Areas.Admin.Models.HblLclExps;
using Vino.Server.Web.Helper;
using Vino.Shared.Constants.Common;
using Vino.Shared.Constants.Warehouse;

namespace Vino.Server.Web.Areas.Admin.Controllers
{
    public class HblFclExpController : BaseController
    {
        private readonly HblFclExpService _service;
        private readonly CrmCustomerService _customerService;
        private readonly TopicService _topicService;
        private readonly OrderGenCodeService _genCodeService;
        private readonly LclExpService _lclExpService;
        private readonly PortService _portService;
        private readonly UserService _userService;
        private readonly WebContext _webContext;
        private readonly LookupService _lookupService;
        private readonly HtmlViewRenderer _htmlViewRenderer;
        private readonly StandardPdfRenderer _standardPdfRenderer;


        public HblFclExpController(HblFclExpService service,
            CrmCustomerService customerService,
            TopicService topicService,
            OrderGenCodeService genCodeService,
            LclExpService lclExpService,
            PortService portService,
            UserService userService,
            WebContext webContext,
            LookupService lookupService,
            HtmlViewRenderer htmlViewRenderer,
            StandardPdfRenderer standardPdfRenderer)
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
            _htmlViewRenderer = htmlViewRenderer;
            _standardPdfRenderer = standardPdfRenderer;
        }

        #region HblFclExp
        // GET: Admin/HblLclExp
        public ActionResult Index()
        {
            return RedirectToAction("HblList");
        }

        public ActionResult HblList(int? id)
        {
            return View(new HblFclExpListModel()
            {
                FclExpId = id
            });
        }

        [HttpPost]
        public async Task<ActionResult> HblList(DataSourceRequest common, HblFclExpListModel model)
        {
            var dateFrom = string.IsNullOrWhiteSpace(model.FromDt) ? (DateTimeOffset?)null : DateTimeOffset.Parse(model.FromDt, new CultureInfo("vi-VN"));
            var dateTo = string.IsNullOrWhiteSpace(model.ToDt) ? (DateTimeOffset?)null : DateTimeOffset.Parse(model.ToDt, new CultureInfo("vi-VN"));

            var dtoFromRepo = await _service.SearchModels(new SearchingRequest()
            {
                Page = common.Page - 1,
                PageSize = common.PageSize,
                FromDt = dateFrom,
                ToDt = dateTo,
                FclExpId = model.FclExpId,
                BlNumber = model.BlNumber,
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
            var topic = await _topicService.GetTopicByTopicType(TopicType.Company);

            var model = new HblFclExpModel()
            {
                ClosingDate = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
                SailingDate = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
                IssueDate = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
                FclExpId = id ?? 0,
                ForwardingAgent = topic?.Name + "-" + topic?.Address + "-" + topic?.Phone,
                QtyOfContainer = "CONTAINER"
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(HblFclExpModel dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var now = DateTimeOffset.Now;

            var lclExpId = dto.FclExpId;
            var lclExp = await _lclExpService.GetSingleAsync(lclExpId);
            if (lclExp == null)
                ErrorNotification("Tạo mới thất bại!");

            var port = await _portService.GetSingleAsync(dto.Port.GetValueOrDefault());
            if (port == null)
            {
                ErrorNotification("Tạo mới thất bại!");
                return View(dto);
            }

            // init code
            var orderGenCode = _genCodeService.GetOrderGenCode(BookPrefixes.FclExp + port.PortCode, now.LocalDateTime.Date);
            orderGenCode.CurrentNumber += 1;
            _genCodeService.UpdateOrderGenCode(orderGenCode);

            dto.BlNumber = $"{orderGenCode.OrderPrefix}{now:yy}{now.Month:D2}" + "/" + $"{orderGenCode.CurrentNumber:D4}";

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
            var model = await _service.GetSingleAsync(id);

            if (model == null)
            {
                return RedirectToAction("HblList");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(HblFclExpModel dto)
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

            if (dto.Preview)
                return RedirectToAction("HblFclExpReport", "CallReport", new { hblFclExpId = dto.Id });


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

            var model = entity.MapTo<HblFclExpModel>();
            if (model.NotifyPartyId == model.ConsigneeId)
                model.NotifyPartyName = "SAME AS CONSIGNEE";

            var vesselLookups = _lookupService.GetLookupByLookupType(LookupTypes.VesselType);
            model.OceanVesselName = vesselLookups.FirstOrDefault(x => x.Id == model.OceanVessel)?.Title;
            model.LocalVesselName = vesselLookups.FirstOrDefault(x => x.Id == model.LocalVessel)?.Title;

            return View(model);
        }

        private async Task<HblFclExpModel> GetModel(int id)
        {
            var entity = await _service.GetSingleAsync(id);
            var model = entity.MapTo<HblFclExpModel>();
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
                return RedirectToAction("HblList");
            }

            await _service.DeleteAsync(id);
            SuccessNotification("Xóa thành công!");
            return RedirectToAction("HblList");
        }

        #endregion

        #region PDF Export

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> Export()
        {
            var model = await GetModel(1);
            string htmlText = this._htmlViewRenderer.RenderViewToString(this, "~/Areas/Admin/Views/HblLclExp/Preview.cshtml", model);

            // Let the html be rendered into a PDF document through iTextSharp.
            byte[] buffer = _standardPdfRenderer.Render(htmlText, "Report");

            // Return the PDF as a binary stream to the client.
            return new BinaryContentResult(buffer, "application/pdf");
            //var cssText = System.IO.File.ReadAllText(@"D:\Workspace\Work\DoAnThucTap\CRM_NEW\New folder\Server\Server.Web\wwwroot\css\pdf-form.css");
            //using (var memoryStream = new MemoryStream())
            //{
            //    StringReader sr = new StringReader(gridHtml);
            //    var pdfDoc = new Document(PageSize.A4, 50, 50, 60, 60);
            //    var writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
            //    pdfDoc.Open();

            //    XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
            //    // using (var cssMemoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(cssText)))
            //    // {
            //    //using (var htmlMemoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(gridHtml)))
            //    //    {
            //    //        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, htmlMemoryStream);
            //    //    XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, htmlMemoryStream);
            //    //    }
            //   // }

            //    pdfDoc.Close();

            //    return File(memoryStream.ToArray(), "application/pdf", "Grid.pdf");

            //}
        }

        //public async Task<ActionResult> CreateAndDownload(int id)
        //{
        //    var itemExpt = this.GetConfigMapping();
        //    var model = await _service.GetSingleAsync(id);
        //    if (model.Id <= 0)
        //    {
        //        return RedirectToAction("Edit", new { id = id });
        //    }

        //    var pdfContent = _pdfService.GetLclImpPdfContent(itemExpt, model);
        //    if (pdfContent.Length > 0)
        //    {
        //        Response.Clear();
        //        Response.ClearContent();
        //        Response.ClearHeaders();
        //        Response.BufferOutput = true;
        //        Response.ContentType = "application/pdf";
        //        Response.AppendHeader("Content-Disposition", "attachment; filename=\"" + model.GetType().Name +
        //                                                     +'_' + model.Id + ".pdf" + "\"");
        //        Response.BinaryWrite(pdfContent);
        //        Response.End();
        //    }

        //    return Json(null);
        //}
        //private PdfMappingConfig GetConfigMapping()
        //{
        //    XmlDocument xmlConfig = null;
        //    var configMappingPath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/PdfMapping/PdfMappingConfig.xml");
        //    xmlConfig = new XmlDocument();
        //    xmlConfig.Load(configMappingPath);
        //    XmlNodeList fileNode = null;
        //    var nodePath = "PdfMapping/Template";
        //    fileNode = xmlConfig.SelectSingleNode(nodePath)?.SelectNodes("File");
        //    foreach (XmlNode node in fileNode)
        //    {
        //        return new PdfMappingConfig()
        //        {
        //            PdfTemplatePath = System.Web.HttpContext.Current.Server.MapPath(node.Attributes["pdffile"].Value),
        //            XmlMappingPath = System.Web.HttpContext.Current.Server.MapPath(node.Attributes["xmlfile"].Value)
        //        };
        //    }
        //    return null;
        //}

        #endregion

        #region OpenModal

        [HttpPost]
        public PartialViewResult OpenModal(string viewResultId, string formId, LclExpAndPodModel model = null)
        {
            TempData["viewResultId"] = viewResultId;
            TempData["formId"] = formId;

            if (model == null)
                model = new LclExpAndPodModel();

            return PartialView("_FirstCreation", model);
        }

        [HttpPost]
        public async Task<ActionResult> CreateFromSubViewAsync(LclExpAndPodModel dto)
        {
            var viewResultId = TempData["viewResultId"];
            var formId = TempData["formId"];

            if (!ModelState.IsValid)
            {
                return Json(dto);
            }

            var blNumber = "";

            var port = await _portService.GetSingleAsync(dto.PortId.GetValueOrDefault());
            if (port == null)
                return new EmptyResult();

            var now = DateTimeOffset.Now;
            // init code
            var orderGenCode = _genCodeService.GetOrderGenCode(BookPrefixes.FclExp + port.PortCode, now.LocalDateTime.Date);
            if (orderGenCode != null)
            {
                blNumber = $"{orderGenCode.OrderPrefix}{now:yy}{now.Month:D2}" + "/" + $"{(orderGenCode.CurrentNumber + 1):D4}";
            }

            SuccessNotification("Create new customer succeed");
            return Json(new
            {
                viewResultId,
                portId = port.Id,
                formId,
                blNumber
            });

        }

        #endregion
    }
}