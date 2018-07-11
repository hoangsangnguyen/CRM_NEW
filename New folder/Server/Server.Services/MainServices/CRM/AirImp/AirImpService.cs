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
using Vino.Server.Services.MainServices.CRM.AirExp;
using Vino.Server.Services.MainServices.CRM.AirExp.Models;
using Vino.Server.Services.MainServices.CRM.AirImp.Models;
using Vino.Server.Services.MainServices.CRM.LclImp.Models;
using SearchingRequest = Vino.Server.Services.MainServices.CRM.AirImp.Models.SearchingRequest;

namespace Vino.Server.Services.MainServices.CRM.AirImp
{
    public class AirImpService : GenericRepository<Data.CRM.AirImp, AirImpModel, AirImpModel>, IAirImpService
    {
        private DataContext _context;

        public AirImpService(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IPageList<AirImpModel>> SearchModels(SearchingRequest request)
        {
            var query = _context.AirImps.AsNoTracking().Where(w => !w.Deleted);
            if (request.FromDt.HasValue)
                query = query.Where(w => w.Created >= request.FromDt.Value);
            if (request.ToDt.HasValue)
            {
                var to = request.ToDt.Value.Date.AddDays(1);
                query = query.Where(w => w.Created < to);
            }

            if (!string.IsNullOrEmpty(request.MawbNumber))
            {
                query = query.Where(w => w.MawbNumber.ToLower().Contains(request.MawbNumber.ToLower()));
            }

            if (request.OpIcId.HasValue && request.OpIcId.Value > 0)
            {
                query = query.Where(w => w.OpIcId == request.OpIcId);
            }
            query = query.OrderByDescending(d => d.Created);
            var receives = await query.Skip(request.Page * request.PageSize)
                .Take(request.PageSize).ToListAsync();
            var models = receives.MapTo<AirImpModel>();
            return new PageList<AirImpModel>(models, request.Page, request.PageSize, query.Count());
        }

    }
}
