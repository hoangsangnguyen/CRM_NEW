using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vino.Server.Services.MainServices.BaseService;
using Vino.Server.Services.MainServices.CRM.AirImp.Models;
using Vino.Server.Services.MainServices.CRM.LclExp.Models;

namespace Vino.Server.Services.MainServices.CRM.LclExp
{
    public interface ILclExpService : IGenericRepository<Data.CRM.LclExp, LclExpModel, LclExpModel>
    {
    }
}
