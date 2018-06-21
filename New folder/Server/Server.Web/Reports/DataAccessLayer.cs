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
using Vino.Server.Services.MainServices.Users;
using Vino.Shared.Constants.Common;
using Vino.Shared.Constants.Producing;
using Vino.Shared.Entities.Producing;

namespace Vino.Server.Web.Reports
{
	public class DataAccessLayer
	{
		
		private LookupService lookupService;
		public DataAccessLayer()
		{
			lookupService = EngineContext.Current.Resolve<LookupService>();
		}
	}
}