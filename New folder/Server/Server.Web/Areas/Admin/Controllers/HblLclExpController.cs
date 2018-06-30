using System;
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
using Vino.Server.Web.Areas.Admin.Models.HblLclExps;
using Vino.Server.Web.Areas.Admin.Models.LclExps;
using Vino.Shared.Constants.Common;

namespace Vino.Server.Web.Areas.Admin.Controllers
{
    public class HblLclExpController : BaseController
    {
        private readonly HblLclExpService _service;
        private readonly LclExpService _lclExpService;
        private readonly CrmCustomerService _customerService;
        private readonly LookupService _lookupService;
        private readonly PortService _portService;
        private readonly HblLclExpPdfService _pdfService;



        public HblLclExpController(HblLclExpService service,
            LclExpService lclExpService,
            CrmCustomerService customerService,
            LookupService lookupService,
            PortService portService,
            HblLclExpPdfService pdfService)
        {
            this._service = service;
            _lclExpService = lclExpService;
            _customerService = customerService;
            _lookupService = lookupService;
            _portService = portService;
            _pdfService = pdfService;
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
            var index = await _service.GetNumberEntry();

            var model = new HblLclExpModel()
            {
                //JobId = "FLL" + DateTimeOffset.Now.Year % 100 + DateTimeOffset.Now.Month.ToString("D2")
                //        + "/" + (index + 1).ToString().PadLeft(4, '0'),
                ClosingDate = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
                SellingDate = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
                IssueDate = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
                LclExpId = id
            };

            await InitContentForModel(model);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(HblLclExpModel dto)
        {
            if (!ModelState.IsValid)
            {
                await InitContentForModel(dto);
                return View(dto);
            }
            var index = await _service.GetNumberEntry();
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

            await InitContentForModel(model);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(HblLclExpModel dto)
        {
            if (!ModelState.IsValid)
            {
                await InitContentForModel(dto);
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

        #region Init Data for model

        private async Task InitContentForModel(HblLclExpModel model)
        {
            model.CustomerItems = await GetCustomerItems();
            model.HblTypeItems = GetTypeOfBillItems();
            model.PortItems = await GetPortItems();
            model.CommodityItems = GetCommodityItems();
            model.UnitItems = GetUnitItems();
            model.VesselItems = GetVesselItems();
            model.CountryItems = GetNationalityItems();
        }

        private async Task<IList<SelectListItem>> GetCustomerItems()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            var customers = await _customerService.GetAllAsync();
            foreach (var l in customers)
                items.Add(new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Name
                });

            return items;
        }

        private IList<SelectListItem> GetTypeOfBillItems()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            var lookups = _lookupService.GetLookupByLookupType(LookupTypes.TypeOfBill);
            foreach (var l in lookups)
                items.Add(new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Title
                });
            return items;
        }

        private async Task<IList<SelectListItem>> GetPortItems()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            var contacts = await _portService.GetAllAsync();
            foreach (var l in contacts)
                items.Add(new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.PortName
                });

            return items;
        }
        private IList<SelectListItem> GetCommodityItems()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            var lookups = _lookupService.GetLookupByLookupType(LookupTypes.CommoditiesType);
            foreach (var l in lookups)
                items.Add(new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Title
                });
            return items;
        }

        private IList<SelectListItem> GetVesselItems()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            var lookups = _lookupService.GetLookupByLookupType(LookupTypes.VesselType);
            foreach (var l in lookups)
                items.Add(new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Title
                });
            return items;
        }

        private IList<SelectListItem> GetUnitItems()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            var lookups = _lookupService.GetLookupByLookupType(LookupTypes.UnitType);
            foreach (var l in lookups)
                items.Add(new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Title
                });
            return items;
        }

        private IList<SelectListItem> GetNationalityItems()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            var lookups = _lookupService.GetLookupByLookupType(LookupTypes.NationalityType);
            foreach (var l in lookups)
                items.Add(new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Title
                });
            return items;
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
    }
}