using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Web.Core.Helpers;
using Falcon.Web.Mvc.PageList;
using Vino.Server.Data.CRM;
using Vino.Server.Services.Database;
using Vino.Server.Services.MainServices.BaseService;
using Vino.Server.Services.MainServices.CRM.AirExp.Models;
using Vino.Server.Services.MainServices.CRM.Customer.Models;
using Vino.Server.Services.MainServices.CRM.FclExp;
using Vino.Server.Services.MainServices.CRM.FclExp.Models;
using SearchingRequest = Vino.Server.Services.MainServices.CRM.Customer.Models.SearchingRequest;

namespace Vino.Server.Services.MainServices.CRM.Customer
{
    public class CrmCustomerService : GenericRepository<Data.CRM.CrmCustomer, CrmCustomerModel, CrmCustomerModel>, ICrmCustomerService
    {
        private readonly DataContext _context;

        public CrmCustomerService(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IPageList<CrmCustomerModel>> SearchModels(SearchingRequest request)
        {
            var query = _context.Customers.AsNoTracking().Where(w => !w.Deleted);

            if (!string.IsNullOrEmpty(request.Name))
                query = query.Where(w => w.Name.ToLower().Contains(request.Name.ToLower()));

            if (!string.IsNullOrEmpty(request.Address))
                query = query.Where(w => w.Address.ToLower().Contains(request.Address.ToLower()));

            if (request.ContactId.HasValue && request.ContactId > 0)
                query = query.Where(w => w.ContactId == request.ContactId);

            if (request.LocationId.HasValue && request.LocationId > 0)
                query = query.Where(w => w.LocationId == request.LocationId);

            query = query.OrderBy(x => x.CustomerId);
            var receives = await query.Skip(request.Page * request.PageSize)
                .Take(request.PageSize).ToListAsync();
            var models = receives.MapTo<CrmCustomerModel>();
            return new PageList<CrmCustomerModel>(models, request.Page, request.PageSize, query.Count());
        }
    }
}
