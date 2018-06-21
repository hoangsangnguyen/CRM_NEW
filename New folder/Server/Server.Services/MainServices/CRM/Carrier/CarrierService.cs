using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vino.Server.Services.Database;
using Vino.Server.Services.MainServices.BaseService;
using Vino.Server.Services.MainServices.CRM.Carrier;
using Vino.Server.Services.MainServices.CRM.Carrier.Model;

namespace Vino.Server.Services.MainServices.CRM.Carrier
{
    public class CarrierService : GenericRepository<Data.CRM.Carrier, CarrierModel, CarrierModel>, ICarrierService
    {
        private DataContext _context;

        public CarrierService(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
