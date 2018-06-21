using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Falcon.Web.Core.Helpers;
using Falcon.Web.Mvc.PageList;
using Vino.Server.Services.Database;
using Vino.Server.Services.MainServices.BaseService;
using Vino.Server.Services.MainServices.CRM.AirExp.Models;
using Vino.Shared.Constants.Common;

namespace Vino.Server.Services.MainServices.CRM.AirExp
{
    public class AirExpService : GenericRepository<Data.CRM.AirExp, AirExpModel, AirExpModel>, IAirExpService
    {
        private readonly DataContext _context;

        public AirExpService(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IList<AirExpModel>> SearchList(SearchingRequest request)
        {
            var query = _context.AirExps.Where(x => !x.Deleted);
            if (request.FromDt.HasValue)
                query = query.Where(w => w.Created >= request.FromDt.Value);
            if (request.ToDt.HasValue)
            {
                var to = request.ToDt.Value.Date.AddDays(1);
                query = query.Where(w => w.Created < to);
            }

            query = query.OrderByDescending(d => d.Created);
            var items = await query.Skip(request.Page * request.PageSize)
                .Take(request.PageSize).ToListAsync();
            var models = items.MapTo<AirExpModel>();
            return new PageList<AirExpModel>(models, request.Page, request.PageSize, query.Count());
        }
    }
}
