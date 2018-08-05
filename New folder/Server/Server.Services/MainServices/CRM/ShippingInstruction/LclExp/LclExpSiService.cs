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
using Vino.Server.Services.MainServices.Common;
using Vino.Server.Services.MainServices.CRM.HblLclExp.Models;
using Vino.Server.Services.MainServices.CRM.Port;
using Vino.Server.Services.MainServices.CRM.Port.Model;
using Vino.Shared.Constants.Common;

namespace Vino.Server.Services.MainServices.CRM.ShippingInstruction.LclExp
{
    public class LclExpSiService : GenericRepository<Data.CRM.LclExpSi, LclExpSiModel, LclExpSiModel>, ILclExpSiService
    {
        private readonly DataContext _context;
        private readonly LookupService _lookupService;


        public LclExpSiService(DataContext context, LookupService lookupService) : base(context)
        {
            _context = context;
            _lookupService = lookupService;
        }

        public async Task<IPageList<LclExpSiModel>> SearchModels(SearchingRequest request)
        {
            var query = _context.LclExpSis.AsNoTracking().Where(w => !w.Deleted);
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

            if (!string.IsNullOrEmpty(request.ReferenceNo))
            {
                query = query.Where(w => w.ReferenceNo.ToLower().Contains(request.ReferenceNo.ToLower()));
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
            var hclLclExps = await query.Skip(request.Page * request.PageSize)
                .Take(request.PageSize).ToListAsync();
            var models = hclLclExps.MapTo<LclExpSiModel>();

            return new PageList<LclExpSiModel>(models, request.Page, request.PageSize, query.Count());
        }

        public async Task<LclExpSiModel> GetSingleAsyncByLclExpId(int lclExpId)
        {
            var siLclExp = await _context.LclExpSis.FirstOrDefaultAsync(x => x.LclExpId == lclExpId && !x.Deleted);
            var result = siLclExp.MapTo<LclExpSiModel>();
            return result;
        }

        public async Task<LclExpSiModel> GetSingleAsyncForReport(int id)
        {
            var siLclExp = await _context.LclExpSis.FirstOrDefaultAsync(x => x.Id == id && !x.Deleted);
            if (siLclExp == null)
                return new LclExpSiModel();
            var siLclExpModel = siLclExp.MapTo<LclExpSiModel>();

            var hblList = _context.HblLclExps.Where(x => x.LclExpId == siLclExpModel.LclExpId && !x.Deleted).ToList();
            hblList.ForEach(d => siLclExpModel.Details.Add(d.MapTo<HblLclExpModel>()));
            return siLclExpModel;
        }
    }
}
