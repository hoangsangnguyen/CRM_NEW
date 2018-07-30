using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Web.Core.Helpers;
using Vino.Server.Services.Database;
using Vino.Server.Services.MainServices.CRM.HblLclExp.Models;

namespace Vino.Server.Services.MainServices.Report
{
    public class ReportService
    {
        private readonly DataContext _context;
        public ReportService(DataContext context)
        {
            _context = context;
        }

        public HblLclExpModel GetHblLclExpReport(int hblLclExpId)
        {
            var hblLclExp = _context.HblLclExps.FirstOrDefault(x => x.Id == hblLclExpId && !x.Deleted);
            var model = hblLclExp.MapTo<HblLclExpModel>();
            return model;
        }
    }
}
