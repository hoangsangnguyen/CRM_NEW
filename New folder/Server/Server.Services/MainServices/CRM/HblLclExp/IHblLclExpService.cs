using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vino.Server.Services.MainServices.BaseService;
using Vino.Server.Services.MainServices.CRM.HblLclExp.Models;
using Vino.Server.Services.MainServices.CRM.LclImp.Models;

namespace Vino.Server.Services.MainServices.CRM.HblLclExp
{
    public interface IHblLclExpService : IGenericRepository<Data.CRM.HblLclExp, HblLclExpModel, HblLclExpModel>
    {
    }
}
