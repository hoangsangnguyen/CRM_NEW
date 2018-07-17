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
using Vino.Server.Services.MainServices.CRM.AirExp.Models;
using Vino.Server.Services.MainServices.CRM.HblLclExp.Models;
using Vino.Server.Services.MainServices.CRM.LclImp;
using Vino.Server.Services.MainServices.CRM.LclImp.Models;
using SearchingRequest = Vino.Server.Services.MainServices.CRM.HblLclExp.Models.SearchingRequest;

namespace Vino.Server.Services.MainServices.CRM.HblLclExp
{
    public class HblLclExpService : GenericRepository<Data.CRM.HblLclExp, HblLclExpModel, HblLclExpModel>, IHblLclExpService
    {
        private DataContext _context;

        public HblLclExpService(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IPageList<HblLclExpModel>> SearchModels(SearchingRequest request)
        {
            var query = _context.HblLclExps.AsNoTracking().Where(w => !w.Deleted);
            if (request.FromDt.HasValue)
                query = query.Where(w => w.CreatedAt >= request.FromDt.Value);
            if (request.ToDt.HasValue)
            {
                var to = request.ToDt.Value.Date.AddDays(1);
                query = query.Where(w => w.CreatedAt < to);
            }

            if (!string.IsNullOrEmpty(request.BookingNumber))
            {
                query = query.Where(w => w.BookingNumber.ToLower().Contains(request.BookingNumber.ToLower()));
            }

            if (!string.IsNullOrEmpty(request.BlNumber))
            {
                query = query.Where(w => w.BlNumber.ToLower().Contains(request.BlNumber.ToLower()));
            }

            if (request.ShipperId.HasValue && request.ShipperId.Value > 0)
            {
                query = query.Where(w => w.ShipperId == request.ShipperId);
            }

            if (request.ConsigneeId.HasValue && request.ConsigneeId.Value > 0)
            {
                query = query.Where(w => w.ConsigneeId == request.ConsigneeId);
            }

            if (request.LclExpId.HasValue && request.LclExpId.Value > 0)
            {
                query = query.Where(w => w.LclExpId == request.LclExpId);
            }

            query = query.OrderByDescending(d => d.CreatedAt);
            var receives = await query.Skip(request.Page * request.PageSize)
                .Take(request.PageSize).ToListAsync();
            var models = receives.MapTo<HblLclExpModel>();
            return new PageList<HblLclExpModel>(models, request.Page, request.PageSize, query.Count());
        }

    }
}
