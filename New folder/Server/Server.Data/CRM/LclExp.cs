using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Web.Core.Auth;
using Falcon.Web.Core.Data;
using Vino.Server.Data.Common;
using Vino.Server.Data.HR;

namespace Vino.Server.Data.CRM
{
    public class LclExp : BaseEntity
    {
        [Required]
        public string JobId { get; set; }

        [Required]
        public DateTimeOffset Created { get; set; }

        [Required]
        public DateTimeOffset Etd { get; set; }

        [Required]
        public DateTimeOffset Eta { get; set; }

        [Required]
        public string BkgNumber { get; set; }

        [Required]
        public string MblNumber { get; set; }

        [Required]
        public int MblTypeId { get; set; }

        [Required]
        public bool IsFinish { get; set; }

        [ForeignKey("OpIcId")]
        public virtual CrmContact OpIc { get; set; }

        [Required]
        public int OpIcId { get; set; }

        [Required]
        public int VesselId { get; set; }

        [Required]
        public int ShipmentId { get; set; }

        [ForeignKey("OolId")]
        public virtual Port Pol { get; set; }

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

        [ForeignKey("CoLoaderId")]
        public virtual Carrier CoLoader { get; set; }

        [Required]
        public int CoLoaderId { get; set; }

        [ForeignKey("AgentId")]
        public virtual Carrier Agent { get; set; }

        [Required]
        public int AgentId { get; set; }

        [Required]
        public int CommodityId { get; set; }

        [ForeignKey("PodId")]
        public virtual Port Pod { get; set; }

        [Required]
        public int PodId { get; set; }

        [Required]
        public int FreightId { get; set; }

        public string Notes { get; set; }

        public string UpdateName { get; set; }

        public DateTimeOffset? UpdateAt { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public int? CreatorId { get; set; }
        public virtual User Creator{ get; set; }

        private ICollection<HblLclExp> _hblLclExps;

        public virtual ICollection<HblLclExp> HblLclExps
        {
            get => _hblLclExps ?? (_hblLclExps = new List<HblLclExp>());
            set => _hblLclExps = value;
        }
    }
}
