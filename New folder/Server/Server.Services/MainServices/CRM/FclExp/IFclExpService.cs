using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vino.Server.Services.MainServices.BaseService;
using Vino.Server.Services.MainServices.CRM.AirImp.Models;
using Vino.Server.Services.MainServices.CRM.FclExp.Models;

namespace Vino.Server.Services.MainServices.CRM.FclExp
{
    public interface IFclExpService : IGenericRepository<Data.CRM.FclExp, FclExpModel, FclExpModel>
    {
    }
}
