using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Xml;
using AutoMapper;
using Falcon.Web.Mvc.Kendoui;
using Falcon.Web.Mvc.Security;
using Vino.Server.Data.CRM;
using Vino.Server.Services.MainServices.Common;
using Vino.Server.Services.MainServices.CRM.LclExp;
using Vino.Server.Services.MainServices.CRM.LclExp.Models;
using Vino.Server.Services.MainServices.CRM.Pdf.Models;
using Vino.Server.Services.MainServices.Users;
using Vino.Server.Web.Areas.Admin.Models.LclExps;
using Vino.Shared.Constants.Warehouse;

namespace Vino.Server.Web.Areas.Admin.Controllers
{
    public class LclExpsController : BaseController
    {
        private readonly LclExpService _service;
        private readonly LclExpPdfExportService _pdfService;
        private readonly OrderGenCodeService _genCodeService;
        private readonly UserService _userService;
        private readonly WebContext _webContext;

        public LclExpsController(LclExpService service,
            LclExpPdfExportService pdfService,
            OrderGenCodeService genCodeService,
            UserService userService,
            WebContext webContext)
        {
            _service = service;
            _pdfService = pdfService;
            _genCodeService = genCodeService;
            _userService = userService;
            _webContext = webContext;
        }

        #region LclExp CRUD

        // GET: Admin/LclExps
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(new LclExpsListModel());
        }

        [HttpPost]
        public async Task<ActionResult> List(DataSourceRequest common, LclExpsListModel model)
        {
            var dateFrom = string.IsNullOrWhiteSpace(model.FromDt) ? (DateTimeOffset?)null : DateTimeOffset.Parse(model.FromDt, new CultureInfo("vi-VN"));
            var dateTo = string.IsNullOrWhiteSpace(model.ToDt) ? (DateTimeOffset?)null : DateTimeOffset.Parse(model.ToDt, new CultureInfo("vi-VN"));

            var dtoFromRepo = await _service.SearchModels(new SearchingRequest()
            {
                Page = common.Page-1,
                PageSize = common.PageSize,
                FromDt = dateFrom,
                ToDt = dateTo,
                OpIcId = model.OpIcId,
                Mbl = model.Mbl
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
            var model = new LclExpModel()
            {
                Created = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
                Eta = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
                Etd = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
            };

            var now = DateTimeOffset.Now;
            // init code
            var orderGenCode = _genCodeService.GetOrderGenCode(BookPrefixes.LclExp, now.LocalDateTime.Date);
            if (orderGenCode != null)
            {
                model.JobId = $"{orderGenCode.OrderPrefix}{now:yy}{now.Month:D2}" + "/" + $"{(orderGenCode.CurrentNumber + 1):D4}";
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LclExpModel dto)
        {
            Console.WriteLine(dto);
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var now = DateTimeOffset.Now;
            // init code
            var orderGenCode = _genCodeService.GetOrderGenCode(BookPrefixes.LclExp, now.LocalDateTime.Date);
            orderGenCode.CurrentNumber += 1;
            _genCodeService.UpdateOrderGenCode(orderGenCode);

            dto.JobId = $"{orderGenCode.OrderPrefix}{now:yy}{now.Month:D2}" + "/" + $"{orderGenCode.CurrentNumber:D4}";

            dto.CreatedAt = now.ToString("dd/MM/yyyy HH:mm:ss");
            var user = await _userService.GetById(_webContext.UserId);
            dto.CreatorId = user.Id;

            var id = await _service.CreateAsync(dto);
            if (id == 0)
            {
                ErrorNotification("Thêm mới thất bại!");
            }
            else
            {
                SuccessNotification("Thêm mới thành công!");
            }
            return RedirectToAction("Edit" , new {id});
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
        public async Task<ActionResult> Edit(LclExpModel dto)
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

        #endregion

        #region PDF Export
        public async Task<ActionResult> CreateAndDownload(int id)
        {
            var itemExpt = this.GetConfigMapping();
            var model = await _service.GetSingleAsync(id);
            if (model.Id <= 0)
            {
                return RedirectToAction("Edit", new {id = id});
            }

            var entity = Mapper.Map<LclExp>(model);

            var pdfContent = _pdfService.GetLclImpPdfContent(itemExpt, model);
            if (pdfContent.Length > 0)
            {
                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();
                Response.BufferOutput = true;
                Response.ContentType = "application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=\"" + entity.GetType().Name +
                                                             + '_' + entity.Id + ".pdf" + "\"");
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
    }
}