using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vino.Server.Services.MainServices.CRM.HblFclExp;
using Vino.Server.Services.MainServices.CRM.HblLclExp;
using Vino.Server.Services.MainServices.CRM.ShippingInstruction.LclExp;

namespace Vino.Server.Web.Areas.Admin.Controllers
{
    public class CallReportController : BaseController
    {
	    private readonly HblLclExpService _hblLclExpService;
        private readonly HblFclExpService _hblFclExpService;
        private readonly LclExpSiService _lclExpSiService;


        public CallReportController(HblLclExpService hblLclExpService, HblFclExpService hblFclExpService,
            LclExpSiService lclExpSiService)
        {
            _hblLclExpService = hblLclExpService;
            _hblFclExpService = hblFclExpService;
            _lclExpSiService = lclExpSiService;
        }

        // GET: Admin/CallReport
        public async Task<ActionResult> HblLclExpReport(int hblLclExpId)
        {
            var hblLclExpModel = await _hblLclExpService.GetSingleAsync(hblLclExpId);
            if (hblLclExpModel == null) return RedirectToAction("HblList", "HblLclExp");
            return View(hblLclExpModel);
        }

        public async Task<ActionResult> HblFclExpReport(int hblFclExpId)
        {
            var hblFclExpModel = await _hblFclExpService.GetSingleAsync(hblFclExpId);
            if (hblFclExpModel == null) return RedirectToAction("HblList", "HblFclExp");
            return View(hblFclExpModel);
        }

        public async Task<ActionResult> SiLclExpReport(int siLclExpId)
        {
            var lclExpSiModel = await _lclExpSiService.GetSingleAsync(siLclExpId);
            if (lclExpSiModel == null) return RedirectToAction("List", "LclExps");
            return View(lclExpSiModel);
        }
    }
}