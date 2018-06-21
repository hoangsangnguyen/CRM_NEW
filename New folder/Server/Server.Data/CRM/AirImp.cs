using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Web.Core.Data;
using Vino.Server.Data.Common;
using Vino.Server.Data.CRM;

namespace Vino.Server.Data.CRM
{
    public class AirImp : BaseEntity
    {
        [Required]
        public string JobId { get; set; }

        [Required]
        public DateTimeOffset Created { get; set; }

        [Required]
        public DateTimeOffset Eta { get; set; }
        [Required]
        public string MawbNumber { get; set; }
        [Required]
        public string FlightNumber { get; set; }
        [Required]
        public DateTimeOffset FLyDate { get; set; }

        [Required]
        public int CommodityId { get; set; }
        [Required]
        public int TypeOfBillId { get; set; }
        [Required]
        public int ShipmentId { get; set; }
        [Required]
        public bool IsFinish { get; set; }

        [ForeignKey("OpIcId")]
        public virtual CrmContact OpIc { get; set; }
        [Required]
        public int OpIcId { get; set; }

        public string Service { get; set; }

        [ForeignKey("AolId")]
        public virtual Port Aol { get; set; }
        [Required]
        public int AolId { get; set; }

        [ForeignKey("DeliveryId")]
        public virtual Port Delivery { get; set; }
        [Required]
        public int DeliveryId { get; set; }

        [Required]
        public int Quantity { get; set; }
        [Required]
        public int UnitId { get; set; }
        [Required]
        public double Gw { get; set; }
        public double Cw { get; set; }

        [ForeignKey("AirlineId")]
        public virtual Carrier Airlines { get; set; }
        public int AirlineId { get; set; }

        [ForeignKey("AgentId")]
        public virtual Carrier Agent { get; set; }
        [Required]
        public int AgentId { get; set; }


        [ForeignKey("aODID")]
        public virtual Port Aod { get; set; }

        [Required] public int AodId { get; set; }
        [Required]
        public string Routing { get; set; }
        [Required]
        public string Scn { get; set; }
        public string Notes { get; set; }
    }
}
