using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vino.Server.Services.MainServices.BaseService;
using Vino.Server.Services.MainServices.CRM.AirExp.Models;
using Vino.Server.Services.MainServices.CRM.Carrier.Model;

namespace Vino.Server.Services.MainServices.CRM.Carrier
{
    public interface ICarrierService : IGenericRepository<Data.CRM.Carrier, CarrierModel, CarrierModel>
    {
    }
}
