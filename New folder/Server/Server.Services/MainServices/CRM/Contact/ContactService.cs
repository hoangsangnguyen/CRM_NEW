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
using Vino.Server.Services.MainServices.CRM.AirExp;
using Vino.Server.Services.MainServices.CRM.AirExp.Models;
using Vino.Server.Services.MainServices.CRM.Contact.Models;
using Vino.Server.Services.MainServices.CRM.Customer.Models;
using SearchingRequest = Vino.Server.Services.MainServices.CRM.Contact.Models.SearchingRequest;

namespace Vino.Server.Services.MainServices.CRM.Contact
{
    public class ContactService : GenericRepository<CrmContact, CrmContactModel, CrmContactModel>, IContactService
    {
        private readonly DataContext _context;

        public ContactService(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IPageList<CrmContactModel>> SearchModels(SearchingRequest request)
        {
            var query = _context.CrmContacts.AsNoTracking().Where(w => !w.Deleted);

            if (!string.IsNullOrEmpty(request.Name))
                query = query.Where(w => w.EnglishName.ToLower().Contains(request.Name.ToLower()));

            if (!string.IsNullOrEmpty(request.Address))
                query = query.Where(w => w.HomeAddress.ToLower().Contains(request.Address.ToLower()));

            if (request.PositionId.HasValue && request.PositionId > 0)
                query = query.Where(w => w.PositionId == request.PositionId);

            if (request.DepartmentId.HasValue && request.DepartmentId > 0)
                query = query.Where(w => w.DepartmentId == request.DepartmentId);

            query = query.OrderBy(x => x.ContactId);
            var receives = await query.Skip(request.Page * request.PageSize)
                .Take(request.PageSize).ToListAsync();
            var models = receives.MapTo<CrmContactModel>();
            return new PageList<CrmContactModel>(models, request.Page, request.PageSize, query.Count());
        }
    }
}
