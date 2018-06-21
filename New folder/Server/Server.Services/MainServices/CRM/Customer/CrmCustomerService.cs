using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vino.Server.Services.Database;
using Vino.Server.Services.MainServices.BaseService;
using Vino.Server.Services.MainServices.CRM.Customer.Models;
using Vino.Server.Services.MainServices.CRM.FclExp;
using Vino.Server.Services.MainServices.CRM.FclExp.Models;

namespace Vino.Server.Services.MainServices.CRM.Customer
{
    public class CrmCustomerService : GenericRepository<Data.CRM.CrmCustomer, CrmCustomerModel, CrmCustomerModel>, ICrmCustomerService
    {
        private DataContext _context;

        public CrmCustomerService(DataContext context) : base(context)
        {
            _context = context;
        }

    }
}
