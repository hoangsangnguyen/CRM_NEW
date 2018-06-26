using System;
using System.Collections.Generic;
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
using Vino.Server.Data.CRM;
using Vino.Server.Services.Infrastructure;
using Vino.Server.Services.MainServices.Common;
using Vino.Server.Services.MainServices.CRM.Carrier;
using Vino.Server.Services.MainServices.CRM.Contact;
using Vino.Server.Services.MainServices.CRM.FclExp;
using Vino.Server.Services.MainServices.CRM.FclExp.Models;
using Vino.Server.Services.MainServices.CRM.LclExp;
using Vino.Server.Services.MainServices.CRM.LclExp.Models;
using Vino.Server.Services.MainServices.CRM.Pdf.Models;
using Vino.Server.Services.MainServices.CRM.Port;
using Vino.Server.Web.Areas.Admin.Models.LclExps;
using Vino.Server.Web.Helper;
using Vino.Shared.Constants.Common;

namespace Vino.Server.Web.Areas.Admin.Controllers
{
    public class LclExpsController : BaseController
    {
        private readonly LclExpService _service;
        private readonly ContactService _contactService;
        private readonly PortService _portService;
        private readonly CarrierService _carrierService;
        private readonly LclExpPdfExportService _pdfService;

        private readonly LookupService _lookupService;
        public LclExpsController(LclExpService service, ContactService contactService,
            PortService portService, CarrierService carrierService,
            LookupService lookupService, LclExpPdfExportService pdfService)
        {
            _service = service;
            _contactService = contactService;
            _portService = portService;
            _lookupService = lookupService;
            _carrierService = carrierService;
            _pdfService = pdfService;
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

            var model = new LclExpModel()
            {
                JobId = "FLL" + DateTimeOffset.Now.Year % 100 + DateTimeOffset.Now.Month.ToString("D2") 
                        + "/" + (index+1).ToString().PadLeft(4, '0'),
                Created = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
                Eta = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
                Etd = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
            };

            await InitDataForModel(model);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LclExpModel dto)
        {
            Console.WriteLine(dto);
            if (!ModelState.IsValid)
            {
                await InitDataForModel(dto);
                return View(dto);
            }
            var index = await _service.GetNumberEntry();
            dto.JobId = "FLL" + DateTimeOffset.Now.Year % 100 + DateTimeOffset.Now.Month.ToString("D2")
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
            return RedirectToAction("Edit" , new {id});
        }

        public async Task<ActionResult> Edit(int id = 0)
        {
            var model = await _service.GetSingleAsync(id);

            if (model == null)
            {
                return RedirectToAction("List");
            }

            await InitDataForModel(model);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(LclExpModel dto)
        {
            if (!ModelState.IsValid)
            {
                await InitDataForModel(dto);
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

        private async Task InitDataForModel(LclExpModel model)
        {
            model.CarrierItems = await GetCarrierItems();
            model.ContactItems = await GetContactItems();
            model.CommodityItems =  GetCommodityItems();
            model.ShipmentItems = GetShipmentItems();
            model.PortItems = await GetPortItems();
            model.MblTypesItems =  GetMblTypeItems();
            model.VesselItems =  GetVesselItems();
            model.FreightItems = GetFreightItems();
            model.UnitItems =  GetUnitItems();
        }

        private async Task<IList<SelectListItem>> GetContactItems()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            var contacts = await _contactService.GetAllAsync();
            foreach (var l in contacts)
                items.Add(new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.EnglishName
                });

            return items;
        }

        private async Task<IList<SelectListItem>> GetCarrierItems()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            var contacts = await _carrierService.GetAllAsync();
            foreach (var l in contacts)
                items.Add(new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Name
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
        private IList<SelectListItem> GetShipmentItems()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            var lookups = _lookupService.GetLookupByLookupType(LookupTypes.ShipmentType);
            foreach (var l in lookups)
                items.Add(new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Title
                });
            return items;
        }

        private IList<SelectListItem> GetMblTypeItems()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            var lookups =  _lookupService.GetLookupByLookupType(LookupTypes.MblType);
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

        private IList<SelectListItem> GetFreightItems()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            var lookups = _lookupService.GetLookupByLookupType(LookupTypes.FreightType);
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

            var pdfContent = _pdfService.GetLclImpPdfContent(itemExpt, entity);
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