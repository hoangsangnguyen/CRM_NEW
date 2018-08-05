using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Falcon.Web.Core.Helpers;
using Vino.Server.Services.Database;
using Vino.Server.Services.MainServices.Common;
using Vino.Server.Services.MainServices.CRM.HblFclExp.Models;
using Vino.Server.Services.MainServices.CRM.HblLclExp.Models;
using Vino.Server.Services.MainServices.CRM.ShippingInstruction.LclExp;
using Vino.Shared.Constants.Common;

namespace Vino.Server.Services.MainServices.Report
{
    public class ReportService
    {
        private readonly DataContext _context;
        private readonly LookupService _lookupService;

        public ReportService(DataContext context, LookupService lookupService)
        {
            _context = context;
            _lookupService = lookupService;
        }

        public HblLclExpModel GetHblLclExpReport(int hblLclExpId)
        {
            var hblLclExp = _context.HblLclExps.FirstOrDefault(x => x.Id == hblLclExpId && !x.Deleted);
            var model = hblLclExp.MapTo<HblLclExpModel>();
            model.HblTypeName = _lookupService.GetLookupById(model.HblType ?? 0)?.Title;
            model.UnitName = _lookupService.GetLookupById(model.UnitId ?? 0)?.Title;
            model.TypeOfMoveName = _lookupService.GetLookupById(model.TypeOfMoveId ?? 0)?.Title;
            model.FreightPayableName = _lookupService.GetLookupById(model.FreightPayableId ?? 0)?.Title;
            model.LocalVesselName = _lookupService.GetLookupById(model.LocalVessel ?? 0)?.Title;
            model.PlaceOfIssueName = _lookupService.GetLookupById(model.PlaceOfIssueId ?? 0)?.Title;
            if (model.NotifyPartyId == model.ConsigneeId)
                model.NotifyPartyInfo = "SAME AS CONSIGNEE";

            model.ContainerInfo = model.NumberOfPackage + " " + model.UnitName + " " + model.QtyOfContainer;

            return model;
        }

        public HblFclExpModel GetHblFclExpReport(int hblFclExpId)
        {
            var hblFclExp = _context.HblFclExps.FirstOrDefault(x => x.Id == hblFclExpId && !x.Deleted);
            var model = hblFclExp.MapTo<HblFclExpModel>();
            return model;
        }

        public LclExpSiModel GetSiLclExpReport(int siLclExpId)
        {
            var siLclExp = _context.LclExpSis.FirstOrDefault(x => x.Id == siLclExpId && !x.Deleted);
            if (siLclExp == null)
                return new LclExpSiModel();
            var siLclExpModel = siLclExp.MapTo<LclExpSiModel>();

            var hblList = _context.HblLclExps.Where(x => x.LclExpId == siLclExpModel.LclExpId && !x.Deleted).ToList();
            var unitLookups = _lookupService.GetLookupByLookupType(LookupTypes.UnitType);
            foreach (var hblLclExp in hblList)
            {
                var model = hblLclExp.MapTo<HblLclExpModel>();
                model.UnitName = unitLookups.FirstOrDefault(x => x.Id == model.UnitId)?.Title;
                siLclExpModel.Details.Add(model);
            }
            siLclExpModel.VesselName = _lookupService.GetLookupById(siLclExpModel.VesselId??0)?.Title;
            siLclExpModel.RemarkName = _lookupService.GetLookupById(siLclExpModel.Remark??0)?.Title;
            siLclExpModel.PaymentName = _lookupService.GetLookupById(siLclExpModel.PaymentId ?? 0)?.Title;

            return siLclExpModel;
        }
    }
}
