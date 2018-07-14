﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using AutoMapper;
using Falcon.Web.Mvc.Kendoui;
using Vino.Server.Data.CRM;
using Vino.Server.Services.MainServices.Common;
using Vino.Server.Services.MainServices.CRM.Customer;
using Vino.Server.Services.MainServices.CRM.HblLclExp;
using Vino.Server.Services.MainServices.CRM.HblLclExp.Models;
using Vino.Server.Services.MainServices.CRM.LclExp;
using Vino.Server.Services.MainServices.CRM.Pdf.Models;
using Vino.Server.Services.MainServices.CRM.Port;
using Vino.Server.Services.MainServices.CRM.Topic;
using Vino.Server.Web.Areas.Admin.Models.HblLclExps;
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


        public HblLclExpController(HblLclExpService service,
            CrmCustomerService customerService,
            HblLclExpPdfService pdfService,
            TopicService topicService,
            OrderGenCodeService genCodeService,
            LclExpService lclExpService,
            PortService portService)
        {
            _service = service;
            _customerService = customerService;
            _pdfService = pdfService;
            _topicService = topicService;
            _genCodeService = genCodeService;
            _lclExpService = lclExpService;
            _portService = portService;
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
                LclExpId = id
            });
        }

        [HttpPost]
        public async Task<ActionResult> HblList(DataSourceRequest common, HblLclExpListModel model)
        {
            var dtoFromRepo = await _service.GetAllAsync();

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
                SellingDate = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
                IssueDate = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
                LclExpId = id,
                ForwardingAgent = topic?.Name + "-" + topic?.Address + "-" + topic?.Phone
            };

            var now = DateTimeOffset.Now;
            // init code for BlNumber
            if (id != null && id > 0)
            {
                var lclExp = await _lclExpService.GetSingleAsync(id.Value);
                if (lclExp != null)
                {
                    var orderGenCode = _genCodeService.GetOrderGenCode(BookPrefixes.HblLclExp, now.LocalDateTime.Date);
                    if (orderGenCode != null)
                    {
                        model.BlNumber = $"{orderGenCode.OrderPrefix}{now:yy}{now.Month:D2}{now.Day:D2}{(orderGenCode.CurrentNumber + 1):D3}";
                    }
                }
            }


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
                return RedirectToAction("HblList");
            }

            await _service.DeleteAsync(id);
            SuccessNotification("Xóa thành công!");
            return RedirectToAction("HblList");
        }

        #endregion

        #region PDF Export
        public async Task<ActionResult> CreateAndDownload(int id)
        {
            var itemExpt = this.GetConfigMapping();
            var model = await _service.GetSingleAsync(id);
            if (model.Id <= 0)
            {
                return RedirectToAction("Edit", new { id = id });
            }

            var pdfContent = _pdfService.GetLclImpPdfContent(itemExpt, model);
            if (pdfContent.Length > 0)
            {
                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();
                Response.BufferOutput = true;
                Response.ContentType = "application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=\"" + model.GetType().Name +
                                                             +'_' + model.Id + ".pdf" + "\"");
                Response.BinaryWrite(pdfContent);
                Response.End();
            }

            return Json(null);
        }
        private PdfMappingConfig GetConfigMapping()
        {
            XmlDocument xmlConfig = null;
            var configMappingPath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/PdfMapping/PdfMappingConfig.xml");
            xmlConfig = new XmlDocument();
            xmlConfig.Load(configMappingPath);
            XmlNodeList fileNode = null;
            var nodePath = "PdfMapping/Template";
            fileNode = xmlConfig.SelectSingleNode(nodePath)?.SelectNodes("File");
            foreach (XmlNode node in fileNode)
            {
                return new PdfMappingConfig()
                {
                    PdfTemplatePath = System.Web.HttpContext.Current.Server.MapPath(node.Attributes["pdffile"].Value),
                    XmlMappingPath = System.Web.HttpContext.Current.Server.MapPath(node.Attributes["xmlfile"].Value)
                };
            }
            return null;
        }

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
                formId,
                blNumber
            });

        }

        #endregion
    }
}