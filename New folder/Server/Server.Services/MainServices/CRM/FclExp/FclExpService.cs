using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vino.Server.Services.Database;
using Vino.Server.Services.MainServices.BaseService;
using Vino.Server.Services.MainServices.CRM.AirExp;
using Vino.Server.Services.MainServices.CRM.AirExp.Models;
using Vino.Server.Services.MainServices.CRM.FclExp.Models;

namespace Vino.Server.Services.MainServices.CRM.FclExp
{
    public class FclExpService : GenericRepository<Data.CRM.FclExp, FclExpModel, FclExpModel>, IFclExpService
    {
        private DataContext _context;

        public FclExpService(DataContext context) : base(context)
        {
            _context = context;
        }

    }
}
