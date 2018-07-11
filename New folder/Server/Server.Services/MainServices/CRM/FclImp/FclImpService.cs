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
using Vino.Server.Services.MainServices.CRM.FclImp.Models;

namespace Vino.Server.Services.MainServices.CRM.FclImp
{
    public class FclImpService : GenericRepository<Data.CRM.FclImp, FclImpModel, FclImpModel>, IFclImpService
    {
        private DataContext _context;

        public FclImpService(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IPageList<FclImpModel>> SearchModels(Models.SearchingRequest request)
        {
            var query = _context.FclImps.AsNoTracking().Where(w => !w.Deleted);
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
            var models = receives.MapTo<FclImpModel>();
            return new PageList<FclImpModel>(models, request.Page, request.PageSize, query.Count());
        }
    }
}
