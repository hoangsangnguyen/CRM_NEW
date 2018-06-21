using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vino.Server.Services.Database;
using Vino.Server.Services.MainServices.BaseService;
using Vino.Server.Services.MainServices.CRM.AirExp;
using Vino.Server.Services.MainServices.CRM.AirExp.Models;
using Vino.Server.Services.MainServices.CRM.FclImp.Models;

namespace Vino.Server.Services.MainServices.CRM.FclImp
{
    public class FclImpService : GenericRepository<Data.CRM.FclImp, FclImpModel, FclImpModel>, IFclImpService
    {
        private DataContext _context;

        public FclImpService(DataContext context) : base(context)
        {
            _context = context;
        }

    }
}
