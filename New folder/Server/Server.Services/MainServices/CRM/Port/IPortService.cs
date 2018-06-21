using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vino.Server.Data.CRM;
using Vino.Server.Services.MainServices.BaseService;
using Vino.Server.Services.MainServices.CRM.Contact.Models;
using Vino.Server.Services.MainServices.CRM.Port.Model;

namespace Vino.Server.Services.MainServices.CRM.Port
{
    public interface IPortService : IGenericRepository<Data.CRM.Port, PortModel, PortModel>
    {
    }
}
