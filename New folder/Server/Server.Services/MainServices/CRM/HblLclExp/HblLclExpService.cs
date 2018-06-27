using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vino.Server.Services.Database;
using Vino.Server.Services.MainServices.BaseService;
using Vino.Server.Services.MainServices.CRM.HblLclExp.Models;
using Vino.Server.Services.MainServices.CRM.LclImp;
using Vino.Server.Services.MainServices.CRM.LclImp.Models;

namespace Vino.Server.Services.MainServices.CRM.HblLclExp
{
    public class HblLclExpService : GenericRepository<Data.CRM.HblLclExp, HblLclExpModel, HblLclExpModel>, IHblLclExpService
    {
        private DataContext _context;

        public HblLclExpService(DataContext context) : base(context)
        {
            _context = context;
        }

    }
}
