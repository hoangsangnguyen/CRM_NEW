using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Vino.Server.Services.MainServices.BaseService;

namespace Vino.Server.Services.MainServices.CRM.AirImp.Models
{
    public class AirImpModel : BaseDto
    {
        public AirImpModel()
        {
            CommodityItems = new List<SelectListItem>();
            ContactItems = new List<SelectListItem>();
            ShipmentItems = new List<SelectListItem>();
            PortItems = new List<SelectListItem>();
            CarrierItems = new List<SelectListItem>();
            TypeOfBillItems = new List<SelectListItem>();
            UnitItems = new List<SelectListItem>();

        }

        [Required]
        public string JobId { get; set; }

        [Required]
        public string Created { get; set; }

        [Required]
        public string Eta { get; set; }
        [Required]
        public string MawbNumber { get; set; }
        [Required]
        public string FlightNumber { get; set; }
        [Required]
        public string FLyDate { get; set; }

        [Required]
        public int CommodityId { get; set; }
        [Required]
        public int ShipmentId { get; set; }
        [Required]
        public int TypeOfBillId { get; set; }
        [Required]
        public bool IsFinish { get; set; }

        public string OpIcName { get; set; }
        [Required]
        public int OpIcId { get; set; }

        public string Service { get; set; }

        public string  AolName { get; set; }
        [Required]
        public int AolId { get; set; }

        public string DeliveryName { get; set; }
        [Required]
        public int DeliveryId { get; set; }

        [Required]
        public int Quantity { get; set; }
        [Required]
        public int UnitId { get; set; }
        [Required]
        public double Gw { get; set; }
        public double Cw { get; set; }

        public string AirlinesName { get; set; }
        public int AirlineId { get; set; }

        public string AgentName { get; set; }
        [Required]
        public int AgentId { get; set; }

        public string AodName { get; set; }

        [Required] public int AodId { get; set; }

        [Required]
        public string Routing { get; set; }

        [Required]
        public string Scn { get; set; }

        public string Notes { get; set; }

        public IList<SelectListItem> CommodityItems { get; set; }
        public IList<SelectListItem> ContactItems { get; set; }
        public IList<SelectListItem> ShipmentItems { get; set; }
        public IList<SelectListItem> PortItems { get; set; }
        public IList<SelectListItem> CarrierItems { get; set; }
        public IList<SelectListItem> TypeOfBillItems { get; set; }
        public IList<SelectListItem> UnitItems { get; set; }


    }
}
