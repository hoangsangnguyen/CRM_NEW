﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using AutoMapper;
using Falcon.Web.Core.Helpers;
using Falcon.Web.Mvc.Kendoui;
using Falcon.Web.Mvc.Security;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.css;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.html.table;
using iTextSharp.tool.xml.parser;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.end;
using iTextSharp.tool.xml.pipeline.html;
using Vino.Server.Data.CRM;
using Vino.Server.Services.MainServices.Common;
using Vino.Server.Services.MainServices.CRM.Customer;
using Vino.Server.Services.MainServices.CRM.HblLclExp;
using Vino.Server.Services.MainServices.CRM.HblLclExp.Models;
using Vino.Server.Services.MainServices.CRM.LclExp;
using Vino.Server.Services.MainServices.CRM.Pdf.Models;
using Vino.Server.Services.MainServices.CRM.Port;
using Vino.Server.Services.MainServices.CRM.Topic;
using Vino.Server.Services.MainServices.Employees;
using Vino.Server.Services.MainServices.Users;
using Vino.Server.Web.Areas.Admin.Models.HblLclExps;
using Vino.Server.Web.Helper;
using Vino.Shared.Constants.Common;
using Vino.Shared.Constants.Warehouse;


namespace Vino.Server.Web.Areas.Admin.Controllers
{
    public class HblLclExpController : BaseController
    {
        private readonly HblLclExpService _service;
        private readonly CrmCustomerService _customerService;
        private readonly HblLclExpPdfService _pdfService;
        private readonly TopicService _topicService;
        private readonly OrderGenCodeService _genCodeService;
        private readonly LclExpService _lclExpService;
        private readonly PortService _portService;
        private readonly UserService _userService;
        private readonly WebContext _webContext;
        private readonly LookupService _lookupService;
        private readonly HtmlViewRenderer _htmlViewRenderer;
        private readonly StandardPdfRenderer _standardPdfRenderer;


        public HblLclExpController(HblLclExpService service,
            CrmCustomerService customerService,
            HblLclExpPdfService pdfService,
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
            _pdfService = pdfService;
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

        #region HblLclExp
        // GET: Admin/HblLclExp
        public ActionResult Index()
        {
            return RedirectToAction("HblList");
        }

        public ActionResult HblList(int? id)
        {
            return View(new HblLclExpListModel()
            {
                ExpId = id
            });
        }

        [HttpPost]
        public async Task<ActionResult> HblList(DataSourceRequest common, HblLclExpListModel model)
        {
            var dateFrom = string.IsNullOrWhiteSpace(model.FromDt) ? (DateTimeOffset?)null : DateTimeOffset.Parse(model.FromDt, new CultureInfo("vi-VN"));
            var dateTo = string.IsNullOrWhiteSpace(model.ToDt) ? (DateTimeOffset?)null : DateTimeOffset.Parse(model.ToDt, new CultureInfo("vi-VN"));

            var dtoFromRepo = await _service.SearchModels(new SearchingRequest()
            {
                Page = common.Page - 1,
                PageSize = common.PageSize,
                FromDt = dateFrom,
                ToDt = dateTo,
                LclExpId = model.ExpId,
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

            var model = new HblLclExpModel()
            {
                ClosingDate = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
                SailingDate = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
                IssueDate = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
                LclExpId = id ?? 0,
                ForwardingAgent = topic?.Name + "-" + topic?.Address + "-" + topic?.Phone,
                QtyOfContainer = "PART OF CONTAINER"
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(HblLclExpModel dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var now = DateTimeOffset.Now;

            var lclExpId = dto.LclExpId;
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
            var orderGenCode = _genCodeService.GetOrderGenCode(BookPrefixes.HblLclExp + port.PortCode, now.LocalDateTime.Date);
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
        public async Task<ActionResult> Edit(HblLclExpModel dto)
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
                return RedirectToAction("HblLclExpReport", "CallReport", new { hblLclExpId = dto.Id});

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
        public ActionResult Export(string gridHtml)
        {
            string css = @"D:\Workspace\Work\DoAnThucTap\CRM_NEW\New folder\Server\Server.Web\wwwroot\css\pdf-form.css";
            Document document = new Document(PageSize.A4);
            byte[] result;
            List<string> cssFiles = new List<string>();
            cssFiles.Add(@"/wwwroot/css/pdf-form.css");

            using (var ms = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(document, ms);
                writer.CloseStream = true;
                document.Open();

                HtmlPipelineContext htmlContext = new HtmlPipelineContext(null);

                htmlContext.SetTagFactory(Tags.GetHtmlTagProcessorFactory());

                ICSSResolver cssResolver = XMLWorkerHelper.GetInstance().GetDefaultCssResolver(false);
                cssFiles.ForEach(i => cssResolver.AddCssFile(System.Web.HttpContext.Current.Server.MapPath(i), true));

                IPipeline pipeline = new CssResolverPipeline(cssResolver,
                    new HtmlPipeline(htmlContext, new PdfWriterPipeline(document, writer)));

                XMLWorker worker = new XMLWorker(pipeline, true);
                XMLParser xmlParser = new XMLParser(worker);
                xmlParser.Parse(new MemoryStream(Encoding.UTF8.GetBytes(gridHtml)));

                document.Close();
                return File(ms.ToArray(), "application/pdf", "Grid.pdf");
            }


            // var htmlText = System.IO.File.ReadAllText(@"D:\Workspace\Work\DoAnThucTap\CRM_NEW\New folder\Server\Server.Web\Areas\Admin\Views\HblLclExp\_form.cshtml");
            //using (var stream = new System.IO.MemoryStream())
            //{
            //    var sr = new StringReader(gridHtml);
            //    var pdfDoc = new Document(PageSize.A4, 50, 50, 60, 60);
            //    var writer = PdfWriter.GetInstance(pdfDoc, stream);

            //    pdfDoc.Open();
            //    XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
            //    pdfDoc.Close();
            //    return File(stream.ToArray(), "application/pdf", "Grid.pdf");
            //}


            //var model = await GetModel(1);
            //string htmlText = this._htmlViewRenderer.RenderViewToString(this, "~/Areas/Admin/Views/HblLclExp/Preview.cshtml", model);

            //// Let the html be rendered into a PDF document through iTextSharp.
            //byte[] buffer = _standardPdfRenderer.Render(htmlText, "Report");

            //// Return the PDF as a binary stream to the client.
            //return new BinaryContentResult(buffer, "application/pdf");


            //var cssText = System.IO.File.ReadAllText(@"D:\Workspace\Work\DoAnThucTap\CRM_NEW\New folder\Server\Server.Web\wwwroot\css\pdf-form.css");
            //using (var memoryStream = new MemoryStream())
            //{
            //    var sr = new StringReader(gridHtml);
            //    var pdfDoc = new Document(PageSize.A4, 50, 50, 60, 60);
            //    var writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
            //    pdfDoc.Open();

            //    //XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
            //    //using (var cssMemoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(cssText)))
            //    //{
            //        using (var htmlMemoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(gridHtml)))
            //        {
            //            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, htmlMemoryStream);
            //        }
            //    //}

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
            var orderGenCode = _genCodeService.GetOrderGenCode(BookPrefixes.HblLclExp + port.PortCode, now.LocalDateTime.Date);
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