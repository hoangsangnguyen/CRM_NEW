using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Vino.Server.Services.MainServices.BaseService;
using Vino.Server.Services.MainServices.CRM.Carrier.Model;
using Vino.Server.Services.MainServices.CRM.Port.Model;

namespace Vino.Server.Services.MainServices.CRM.LclExp.Models
{
    public class LclExpModel : BaseDto
    {
        public LclExpModel()
        {
            CommodityItems = new List<SelectListItem>();
            ContactItems = new List<SelectListItem>();
            ShipmentItems = new List<SelectListItem>();
            PortItems = new List<SelectListItem>();
            CarrierItems = new List<SelectListItem>();
            MblTypesItems = new List<SelectListItem>();
            VesselItems = new List<SelectListItem>();
            FreightItems = new List<SelectListItem>();
            UnitItems = new List<SelectListItem>();

        }

        [Required]
        public string JobId { get; set; }

        [Required]
        public string Created { get; set; }

        [Required]
        public string Etd { get; set; }

        [Required]
        public string Eta { get; set; }

        [Required]
        public string BkgNumber { get; set; }

        [Required]
        public string MblNumber { get; set; }

        [Required]
        public int MblTypeId { get; set; }

        [Required]
        public bool IsFinish { get; set; }

        [Required]
        public int OpIcId { get; set; }

        [Required]
        public int VesselId { get; set; }

        [Required]
        public int ShipmentId { get; set; }

        public string PolName { get; set; }

        [Required]
        public int PolId { get; set; }

        [Required]
        public double Gw { get; set; }

        [Required]
        public double Cbm { get; set; }

        [Required]
        public int Packages { get; set; }

        [Required]
        public int UnitId { get; set; }

        public string CoLoaderName { get; set; }

        [Required]
        public int CoLoaderId { get; set; }

        public string AgentName { get; set; }

        [Required]
        public int AgentId { get; set; }

        [Required]
        public int CommodityId { get; set; }

        public string PodName { get; set; }

        [Required]
        public int PodId { get; set; }

        [Required]
        public int FreightId { get; set; }

        public string Notes { get; set; }

        public IList<SelectListItem> CommodityItems { get; set; }
        public IList<SelectListItem> ContactItems { get; set; }
        public IList<SelectListItem> ShipmentItems { get; set; }
        public IList<SelectListItem> PortItems { get; set; }
        public IList<SelectListItem> CarrierItems { get; set; }
        public IList<SelectListItem> MblTypesItems { get; set; }
        public IList<SelectListItem> VesselItems { get; set; }
        public IList<SelectListItem> FreightItems { get; set; }
        public IList<SelectListItem> UnitItems { get; set; }

    }
}
