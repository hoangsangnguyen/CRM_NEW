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
using Vino.Server.Services.MainServices.CRM.FclExp.Models;
using Vino.Server.Services.MainServices.CRM.HblFclExp.Models;
using Vino.Server.Services.MainServices.CRM.LclExp.Models;
using Vino.Shared.Constants.Common;

namespace Vino.Server.Services.MainServices.CRM.FclExp
{
    public class FclExpService : GenericRepository<Data.CRM.FclExp, FclExpModel, FclExpModel>, IFclExpService
    {
        private readonly DataContext _context;
        private readonly LookupService _lookupService;

        public FclExpService(DataContext context, LookupService lookupService) : base(context)
        {
            _context = context;
            _lookupService = lookupService;
        }

        public async Task<IPageList<FclExpModel>> SearchModels(Models.SearchingRequest request)
        {
            var query = _context.FclExps.AsNoTracking().Where(w => !w.Deleted);
            if (request.FromDt.HasValue)
                query = query.Where(w => w.Created >= request.FromDt.Value);
            if (request.ToDt.HasValue)
            {
                var to = request.ToDt.Value.Date.AddDays(1);
                query = query.Where(w => w.Created < to);
            }

            if (!string.IsNullOrEmpty(request.Mbl))
            {
                query = query.Where(w => w.Mbl.ToLower().Contains(request.Mbl.ToLower()));
            }

            if (request.OpIcId.HasValue && request.OpIcId.Value > 0)
            {
                query = query.Where(w => w.OpIcId == request.OpIcId);
            }
            query = query.OrderByDescending(d => d.Created);

            var details = await query.Skip(request.Page * request.PageSize)
                .Take(request.PageSize).ToListAsync();

            var models = details.MapTo<FclExpModel>();

            var fclExpIds = models.Select(x => x.Id).ToList();

            var hblItems = await _context.HblFclExps.Where(x =>
                !x.Deleted && fclExpIds.Contains(x.FclExpId.Value)).ToListAsync();
            var hblItemModels = hblItems.MapTo<HblFclExpModel>();
            var unitLookups = _lookupService.GetLookupByLookupType(LookupTypes.UnitType);

            foreach (var fclExpModel in models)
            {
                var qty = 0;
                var grossWeight = 0.0;
                var cbm = 0.0;

                foreach (var hblFclExpModel in hblItemModels)
                {
                    if (hblFclExpModel.FclExpId == fclExpModel.Id)
                    {
                        qty += hblFclExpModel.NumberOfPackage;
                        grossWeight += hblFclExpModel.GrossWeight;
                        cbm += hblFclExpModel.Measurement;
                        hblFclExpModel.UnitName = unitLookups.FirstOrDefault(x => x.Id == hblFclExpModel.UnitId)?.Title;
                        fclExpModel.Items.Add(hblFclExpModel);
                    }
                }

                //lclExpModel.Packages = lclExpModel.Packages > qty ? lclExpModel.Packages : qty;
                fclExpModel.Gw = fclExpModel.Gw > grossWeight ? fclExpModel.Gw : grossWeight;
                fclExpModel.Cbm = fclExpModel.Cbm > cbm ? fclExpModel.Cbm : cbm;

            }

            return new PageList<FclExpModel>(models, request.Page, request.PageSize, query.Count());
        }

    }
}
