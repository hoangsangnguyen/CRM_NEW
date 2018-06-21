using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vino.Server.Services.MainServices.BaseService;
using Vino.Server.Services.MainServices.CRM.AirImp.Models;
using Vino.Server.Services.MainServices.CRM.FclImp.Models;

namespace Vino.Server.Services.MainServices.CRM.FclImp
{
    public interface IFclImpService : IGenericRepository<Data.CRM.FclImp, FclImpModel, FclImpModel>
    {
    }
}
