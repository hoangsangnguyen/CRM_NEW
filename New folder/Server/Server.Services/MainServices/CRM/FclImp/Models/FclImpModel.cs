using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Vino.Server.Data.CRM;
using Vino.Server.Services.MainServices.BaseService;
using Vino.Server.Services.MainServices.CRM.Carrier.Model;
using Vino.Server.Services.MainServices.CRM.Contact.Models;
using Vino.Server.Services.MainServices.CRM.Port.Model;

namespace Vino.Server.Services.MainServices.CRM.FclImp.Models
{
    public class FclImpModel : BaseDto
    {
        public FclImpModel()
        {
            CommodityItems = new List<SelectListItem>();
            ContactItems = new List<SelectListItem>();
            ShipmentItems = new List<SelectListItem>();
            PortItems = new List<SelectListItem>();
            CarrierItems = new List<SelectListItem>();
            VesselItems = new List<SelectListItem>();
            ShipmentItems = new List<SelectListItem>();
        }

        [Required]
        public string JobId { get; set; }

        [Required]
        public DateTimeOffset Created { get; set; }

        [Required]
        public DateTimeOffset Eta { get; set; }

        [Required]
        public string MblNumber { get; set; }

        public PortModel Pol { get; set; }
        [Required]
        public int PolId { get; set; }
        [Required]
        public string Service { get; set; }

        [Required]
        public int MblTypeId { get; set; }

        [Required]
        public int ShipmentId { get; set; }

        [Required]
        public DateTimeOffset Etd { get; set; }

        public CrmContactModel OpIc { get; set; }
        [Required]
        public int OpIcId { get; set; }

        [Required]
        public string ScName { get; set; }

        [Required]
        public string PoNumber { get; set; }

        public PortModel Pod { get; set; }
        [Required]
        public int PodId { get; set; }
        [Required]
        public string Container { get; set; }
        [Required]
        public int CommodityId { get; set; }

        public CarrierModel SLines { get; set; }
        [Required]
        public int SlinesId { get; set; }
        public CarrierModel Agent { get; set; }
        [Required]
        public int AgentId { get; set; }
        [Required]
        public int VesselId { get; set; }

        public PortModel Delivery { get; set; }
        [Required]
        public int DeliveryId { get; set; }

        [Required]
        public double Gw { get; set; }
        [Required]
        public double Cbm { get; set; }

        [Required]
        public bool IsFinish { get; set; }
        public string Notes { get; set; }

        public IList<SelectListItem> ContactItems { get; set; }
        public IList<SelectListItem> CarrierItems { get; set; }
        public IList<SelectListItem> PortItems { get; set; }
        public IList<SelectListItem> VesselItems { get; set; }
        public IList<SelectListItem> CommodityItems { get; set; }
        public IList<SelectListItem> MblItems { get; set; }
        public IList<SelectListItem> ShipmentItems { get; set; }
    }
}
