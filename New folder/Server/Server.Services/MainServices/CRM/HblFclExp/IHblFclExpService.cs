using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vino.Server.Services.MainServices.BaseService;
using Vino.Server.Services.MainServices.CRM.HblFclExp.Models;
using Vino.Server.Services.MainServices.CRM.HblLclExp.Models;

namespace Vino.Server.Services.MainServices.CRM.HblFclExp
{
    public interface IHblFclExpService : IGenericRepository<Data.CRM.HblFclExp, HblFclExpModel, HblFclExpModel>
    {
    }
}
