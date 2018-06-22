using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Vino.Server.Data.CRM;
using Vino.Server.Services.MainServices.BaseService;
using Vino.Server.Services.MainServices.CRM.Carrier.Model;

namespace Vino.Server.Services.MainServices.CRM.AirExp.Models
{
    public class AirExpModel : BaseDto
    {
        public AirExpModel()
        {
            CommodityItems = new List<SelectListItem>();

            ContactItems = new List<SelectListItem>();
            ShipmentItems = new List<SelectListItem>();
            PaymentItems = new List<SelectListItem>();
            TypeOfBillItems = new List<SelectListItem>();
            UnitItems = new List<SelectListItem>();
            PortItems = new List<SelectListItem>();
            CarrierItems = new List<SelectListItem>();
        }

        [Required]
        public string JobId { get; set; }

        [Required]
        public string Created { get; set; }

        public string Service { get; set; }

        [Required]
        public string Etd { get; set; }

        [Required]
        public string Eta { get; set; }

        public int CommodityId { get; set; }

        public string MawbNumber { get; set; }

        public int TypeOfBillId { get; set; }

        public string FlightNumber { get; set; }

        public string FlyDate { get; set; }

        public int OpicId { get; set; }

        public int ShipmentId { get; set; }

        public int OriginPortId { get; set; }

        public int TransitPortId { get; set; }

        [Required]
        public int Quantity { get; set; }

        public int UnitId { get; set; }

        public int PaymentId { get; set; }

        public bool IsFinish { get; set; }

        public int CarrierId { get; set; }
        public string CarrierName { get; set; }

        public int AgentId { get; set; }
        public string AgentName { get; set; }

        public int DestinationId { get; set; }
        public double Gw { get; set; }
        public double Cw { get; set; }

        public string Notes { get; set; }

        public IList<SelectListItem> CommodityItems { get; set; }
        public IList<SelectListItem> ContactItems { get; set; }
        public IList<SelectListItem> ShipmentItems { get; set; }
        public IList<SelectListItem> PaymentItems { get; set; }
        public IList<SelectListItem> TypeOfBillItems { get; set; }
        public IList<SelectListItem> UnitItems { get; set; }
        public IList<SelectListItem> PortItems { get; set; }
        public IList<SelectListItem> CarrierItems { get; set; }


    }
}
