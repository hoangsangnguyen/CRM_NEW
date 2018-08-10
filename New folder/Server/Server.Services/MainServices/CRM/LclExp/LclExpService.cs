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
using Vino.Server.Services.MainServices.CRM.AirExp;
using Vino.Server.Services.MainServices.CRM.AirExp.Models;
using Vino.Server.Services.MainServices.CRM.HblLclExp.Models;
using Vino.Server.Services.MainServices.CRM.LclExp.Models;
using Vino.Shared.Constants.Common;
using SearchingRequest = Vino.Server.Services.MainServices.CRM.LclExp.Models.SearchingRequest;

namespace Vino.Server.Services.MainServices.CRM.LclExp
{
    public class LclExpService : GenericRepository<Data.CRM.LclExp, LclExpModel, LclExpModel>, ILclExpService
    {
        private readonly DataContext _context;
        private readonly LookupService _lookupService;

        public LclExpService(DataContext context, LookupService lookupService) : base(context)
        {
            _context = context;
            _lookupService = lookupService;
        }

        public async Task<IPageList<LclExpModel>> SearchModels(SearchingRequest request)
        {
            var query = _context.LclExps.AsNoTracking().Where(w => !w.Deleted);
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
            var details = await query.Skip(request.Page * request.PageSize)
                .Take(request.PageSize).ToListAsync();
            var models = new List<LclExpModel>();

            //var lclExpIds = models.Select(x => x.Id).ToList();
            //var hblItems = await details
            //var hblItems = await _context.HblLclExps.Where(x =>
            //    !x.Deleted && lclExpIds.Contains(x.LclExpId.Value)).ToListAsync();
            var unitLookups = _lookupService.GetLookupByLookupType(LookupTypes.UnitType);

            foreach (var lclExp in details)
            {
                var lclExpModel = lclExp.MapTo<LclExpModel>();

                var qty = 0;
                var grossWeight = 0.0;
                var cbm = 0.0;

                var hblLists = lclExp.HblLclExps.MapTo<HblLclExpModel>();
                hblLists.ForEach(d =>
                {
                    qty += d.NumberOfPackage;
                    grossWeight += d.GrossWeight;
                    cbm += d.Measurement;
                    d.UnitName = unitLookups.FirstOrDefault(x => x.Id == d.UnitId)?.Title;
                });

                lclExpModel.Items = hblLists;
                lclExpModel.Packages = lclExpModel.Packages > qty ? lclExpModel.Packages : qty;
                lclExpModel.Gw = lclExpModel.Gw > grossWeight ? lclExpModel.Gw : grossWeight;
                lclExpModel.Cbm = lclExpModel.Cbm > cbm ? lclExpModel.Cbm : cbm;
                lclExpModel.IsVailableSi = lclExpModel.Items.Count > 0;
                models.Add(lclExpModel);
            }

            return new PageList<LclExpModel>(models, request.Page, request.PageSize, query.Count());
        }
    }
}
