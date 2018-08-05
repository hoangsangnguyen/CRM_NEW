using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Falcon.Web.Core.Helpers;
using Falcon.Web.Core.Infrastructure;
using Newtonsoft.Json;
using Vino.Server.Services.MainServices.Common;
using Vino.Server.Services.MainServices.Common.Models;
using Vino.Server.Services.MainServices.CRM.HblFclExp.Models;
using Vino.Server.Services.MainServices.CRM.HblLclExp.Models;
using Vino.Server.Services.MainServices.CRM.ShippingInstruction.LclExp;
using Vino.Server.Services.MainServices.Report;
using Vino.Server.Services.MainServices.Users;
using Vino.Shared.Constants.Common;
using Vino.Shared.Constants.Producing;
using Vino.Shared.Entities.Producing;

namespace Vino.Server.Web.Reports
{
	public class DataAccessLayer
	{
		
		private LookupService lookupService;
	    private readonly ReportService _reportService;

		public DataAccessLayer()
		{
		    _reportService = EngineContext.Current.Resolve<ReportService>();
			lookupService = EngineContext.Current.Resolve<LookupService>();
		}

	    public HblLclExpModel GetHblLclExpModel(int hblLclExpId)
	    {
	        return _reportService.GetHblLclExpReport(hblLclExpId);
	    }

	    public HblFclExpModel GetHblFclExpModel(int hblFclExpId)
	    {
	        return _reportService.GetHblFclExpReport(hblFclExpId);
	    }

	    public LclExpSiModel GetSiLclExpModel(int siLclExpId)
	    {
	        return _reportService.GetSiLclExpReport(siLclExpId);
	    }
    }
}