using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vino.Server.Services.Database;
using Vino.Server.Services.MainServices.BaseService;
using Vino.Server.Services.MainServices.CRM.AirExp;
using Vino.Server.Services.MainServices.CRM.AirExp.Models;
using Vino.Server.Services.MainServices.CRM.LclExp.Models;

namespace Vino.Server.Services.MainServices.CRM.LclExp
{
    public class LclExpService : GenericRepository<Data.CRM.LclExp, LclExpModel, LclExpModel>, ILclExpService
    {
        private DataContext _context;

        public LclExpService(DataContext context) : base(context)
        {
            _context = context;
        }

    }
}
