using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Web.Core.Helpers;
using Falcon.Web.Mvc.PageList;
using Vino.Server.Services.Database;
using Vino.Server.Services.MainServices.BaseService;
using Vino.Server.Services.MainServices.CRM.Carrier;
using Vino.Server.Services.MainServices.CRM.Carrier.Model;
using Vino.Server.Services.MainServices.CRM.Contact.Models;
using SearchingRequest = Vino.Server.Services.MainServices.CRM.Carrier.Model.SearchingRequest;

namespace Vino.Server.Services.MainServices.CRM.Carrier
{
    public class CarrierService : GenericRepository<Data.CRM.Carrier, CarrierModel, CarrierModel>, ICarrierService
    {
        private DataContext _context;

        public CarrierService(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IPageList<CarrierModel>> SearchModels(SearchingRequest request)
        {
            var query = _context.Carriers.AsNoTracking().Where(w => !w.Deleted);

            if (!string.IsNullOrEmpty(request.Code))
                query = query.Where(w => w.Code.ToLower().Contains(request.Code.ToLower()));

            if (!string.IsNullOrEmpty(request.Name))
                query = query.Where(w => w.Name.ToLower().Contains(request.Name.ToLower()));

            if (request.CountryId.HasValue && request.CountryId > 0)
                query = query.Where(w => w.CountryId == request.CountryId);

            if (!string.IsNullOrEmpty(request.Cell))
                query = query.Where(w => w.Cell.ToLower().Contains(request.Cell.ToLower()));

            query = query.OrderBy(x => x.Code);
            var receives = await query.Skip(request.Page * request.PageSize)
                .Take(request.PageSize).ToListAsync();
            var models = receives.MapTo<CarrierModel>();
            return new PageList<CarrierModel>(models, request.Page, request.PageSize, query.Count());
        }
    }
}
