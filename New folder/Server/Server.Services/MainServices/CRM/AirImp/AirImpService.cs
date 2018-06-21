using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vino.Server.Services.Database;
using Vino.Server.Services.MainServices.BaseService;
using Vino.Server.Services.MainServices.CRM.AirExp;
using Vino.Server.Services.MainServices.CRM.AirExp.Models;
using Vino.Server.Services.MainServices.CRM.AirImp.Models;

namespace Vino.Server.Services.MainServices.CRM.AirImp
{
    public class AirImpService : GenericRepository<Data.CRM.AirImp, AirImpModel, AirImpModel>, IAirImpService
    {
        private DataContext _context;

        public AirImpService(DataContext context) : base(context)
        {
            _context = context;
        }

    }
}
