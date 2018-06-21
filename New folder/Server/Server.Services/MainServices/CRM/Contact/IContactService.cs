using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vino.Server.Data.CRM;
using Vino.Server.Services.MainServices.BaseService;
using Vino.Server.Services.MainServices.CRM.AirExp.Models;
using Vino.Server.Services.MainServices.CRM.Contact.Models;

namespace Vino.Server.Services.MainServices.CRM.Contact
{
    public interface IContactService : IGenericRepository<CrmContact, CrmContactModel, CrmContactModel>
    {
    }
}
