using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vino.Server.Services.MainServices.BaseService;
using Vino.Server.Services.MainServices.CRM.AirExp.Models;

namespace Vino.Server.Services.MainServices.CRM.AirExp
{
    public interface IAirExpService : IGenericRepository<Data.CRM.AirExp, AirExpModel, AirExpModel>
    {
    }
}
