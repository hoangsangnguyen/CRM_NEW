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
using Vino.Server.Services.MainServices.CRM.LclExp.Models;
using Vino.Server.Services.MainServices.CRM.LclImp.Models;

namespace Vino.Server.Services.MainServices.CRM.LclImp
{
    public class LclImpService : GenericRepository<Data.CRM.LclImp, LclImpModel, LclImpModel>, ILclImpService
    {
        private DataContext _context;

        public LclImpService(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IPageList<LclImpModel>> SearchModels(Models.SearchingRequest request)
        {
            var query = _context.LclImps.AsNoTracking().Where(w => !w.Deleted);
            if (request.FromDt.HasValue)
                query = query.Where(w => w.Created >= request.FromDt.Value);
            if (request.ToDt.HasValue)
            {
                var to = request.ToDt.Value.Date.AddDays(1);
                query = query.Where(w => w.Created < to);
            }

            if (!string.IsNullOrEmpty(request.Mbl))
            {
                query = query.Where(w => w.MblNumber.ToLower().Contains(request.Mbl.ToLower()));
            }

            if (request.OpIcId.HasValue && request.OpIcId.Value > 0)
            {
                query = query.Where(w => w.OpIcId == request.OpIcId);
            }
            query = query.OrderByDescending(d => d.Created);
            var receives = await query.Skip(request.Page * request.PageSize)
                .Take(request.PageSize).ToListAsync();
            var models = receives.MapTo<LclImpModel>();
            return new PageList<LclImpModel>(models, request.Page, request.PageSize, query.Count());
        }
    }
}
