using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Web.Core.Data;

namespace Vino.Server.Data.CRM
{
    public class AirExp : BaseEntity
    {
        [Required]
        public string JobId { get; set; }

        [Required]
        public DateTimeOffset Created { get; set; }

        public string Service { get; set; }

        [Required]
        public DateTimeOffset Etd { get; set; }

        [Required]
        public DateTimeOffset Eta { get; set; }

        public int CommodityId { get; set; }

        public string MawbNumber { get; set; }

        public int TypeOfBillId { get; set; }

        public string FlightNumber { get; set; }

        public DateTimeOffset FlyDate { get; set; }

        [ForeignKey("OpicId")]
        public virtual CrmContact Opic { get; set; }
        public int OpicId { get; set; }

        public int ShipmentId { get; set; }

        [ForeignKey("OriginPortId")]
        public virtual Port OriginPort { get; set; }
        public int OriginPortId { get; set; }

        [ForeignKey("TransitPortId")]
        public virtual Port TransitPort { get; set; }
        public int TransitPortId { get; set; }

        [Required]
        public int Quantity { get; set; }

        public int UnitId { get; set; }

        public int PaymentId { get; set; }

        [Required]
        public bool IsFinish { get; set; }

        [ForeignKey("CarrierId")]
        public virtual Carrier Carrier { get; set; }
        public int CarrierId { get; set; }

        [ForeignKey("AgentId")]
        public virtual Carrier Agent { get; set; }
        public int AgentId { get; set; }

        [ForeignKey("DestinationId")]
        public virtual Port Destination { get; set; }
        public int DestinationId { get; set; }

        public double Gw { get; set; }
        public double Cw { get; set; }

        public string Notes { get; set; }
    }
}
