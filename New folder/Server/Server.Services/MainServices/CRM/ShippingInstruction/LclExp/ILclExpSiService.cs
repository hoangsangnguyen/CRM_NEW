using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vino.Server.Services.MainServices.BaseService;
using Vino.Server.Services.MainServices.CRM.Port.Model;

namespace Vino.Server.Services.MainServices.CRM.ShippingInstruction.LclExp
{
    public interface ILclExpSiService : IGenericRepository<Data.CRM.LclExpSi, LclExpSiModel, LclExpSiModel>
    {

    }
}
