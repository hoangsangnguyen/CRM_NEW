using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vino.Server.Services.MainServices.CRM.HblFclExp;
using Vino.Server.Services.MainServices.CRM.HblLclExp;

namespace Vino.Server.Web.Areas.Admin.Controllers
{
    public class CallReportController : BaseController
    {
	    private readonly HblLclExpService _hblLclExpService;
        private readonly HblFclExpService _hblFclExpService;

        public CallReportController(HblLclExpService hblLclExpService, HblFclExpService hblFclExpService)
        {
            _hblLclExpService = hblLclExpService;
            _hblFclExpService = hblFclExpService;
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
    }
}