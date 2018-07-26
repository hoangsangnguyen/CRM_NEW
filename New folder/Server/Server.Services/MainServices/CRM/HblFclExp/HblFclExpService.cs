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
using Vino.Server.Services.MainServices.Common;
using Vino.Server.Services.MainServices.CRM.HblFclExp.Models;
using Vino.Shared.Constants.Common;

namespace Vino.Server.Services.MainServices.CRM.HblFclExp
{
    public class HblFclExpService : GenericRepository<Data.CRM.HblFclExp, HblFclExpModel, HblFclExpModel>, IHblFclExpService
    {
        private readonly DataContext _context;
        private readonly LookupService _lookupService;

        public HblFclExpService(DataContext context, LookupService lookupService) : base(context)
        {
            _context = context;
            _lookupService = lookupService;
        }

        public async Task<IPageList<HblFclExpModel>> SearchModels(SearchingRequest request)
        {
            var query = _context.HblFclExps.AsNoTracking().Where(w => !w.Deleted);
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

            if (request.FclExpId.HasValue && request.FclExpId.Value > 0)
            {
                query = query.Where(w => w.FclExpId == request.FclExpId);
            }

            query = query.OrderByDescending(d => d.CreatedAt);
            var hclLclExps = await query.Skip(request.Page * request.PageSize)
                .Take(request.PageSize).ToListAsync();
            var unitLookups = _lookupService.GetLookupByLookupType(LookupTypes.UnitType);
            var models = hclLclExps.MapTo<HblFclExpModel>();
            models.ForEach(m => m.UnitName = unitLookups.FirstOrDefault(x => x.Id == m.UnitId)?.Title);

            return new PageList<HblFclExpModel>(models, request.Page, request.PageSize, query.Count());
        }
    }
}
