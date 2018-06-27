using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Falcon.Web.Mvc.Kendoui;
using Vino.Server.Services.MainServices.CRM.HblLclExp;
using Vino.Server.Services.MainServices.CRM.HblLclExp.Models;
using Vino.Server.Web.Areas.Admin.Models.HblLclExps;
using Vino.Server.Web.Areas.Admin.Models.LclExps;

namespace Vino.Server.Web.Areas.Admin.Controllers
{
    public class HblLclExpController : Controller
    {
        private readonly HblLclExpService _service;

        public HblLclExpController(HblLclExpService service)
        {
            this._service = service;
        }

        // GET: Admin/HblLclExp
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(new HblLclExpListModel());
        }

        [HttpPost]
        public async Task<ActionResult> List(DataSourceRequest common, HblLclExpListModel model)
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

            var model = new HblLclExpModel()
            {
                //JobId = "FLL" + DateTimeOffset.Now.Year % 100 + DateTimeOffset.Now.Month.ToString("D2")
                //        + "/" + (index + 1).ToString().PadLeft(4, '0'),
                //Created = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
                //Eta = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
                //Etd = DateTimeOffset.Now.Date.ToString("dd/MM/yyyy"),
            };

            //await InitDataForModel(model);

            return View(model);
        }

    }
}