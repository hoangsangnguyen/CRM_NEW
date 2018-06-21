using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vino.Server.Services.Database;
using Vino.Server.Services.MainServices.BaseService;
using Vino.Server.Services.MainServices.CRM.AirExp;
using Vino.Server.Services.MainServices.CRM.AirExp.Models;
using Vino.Server.Services.MainServices.CRM.LclImp.Models;

namespace Vino.Server.Services.MainServices.CRM.LclImp
{
    public class LclImpService : GenericRepository<Data.CRM.LclImp, LclImpModel, LclImpModel>, ILclImpService
    {
        private DataContext _context;

        public LclImpService(DataContext context) : base(context)
        {
            _context = context;
        }

    }
}
