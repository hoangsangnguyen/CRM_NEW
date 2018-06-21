using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vino.Server.Data.CRM;
using Vino.Server.Services.Database;
using Vino.Server.Services.MainServices.BaseService;
using Vino.Server.Services.MainServices.CRM.AirExp;
using Vino.Server.Services.MainServices.CRM.AirExp.Models;
using Vino.Server.Services.MainServices.CRM.Contact.Models;

namespace Vino.Server.Services.MainServices.CRM.Contact
{
    public class ContactService : GenericRepository<CrmContact, CrmContactModel, CrmContactModel>, IContactService
    {
        private DataContext _context;

        public ContactService(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
