﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Web.Core.Auth;
using Falcon.Web.Core.Data;

namespace Vino.Server.Data.CRM
{
    public class LclImp : BaseEntity
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
        public string MblNumber { get; set; }
        [Required]
        public int MblTypeId { get; set; }

        [ForeignKey("PolId")]
        public virtual Port Pol { get; set; }
        [Required]
        public int PolId { get; set; }
        [Required]
        public int CommodityId { get; set; }
        [Required]
        public int ShipmentId { get; set; }
        [ForeignKey("OpIcId")]
        public virtual CrmContact OpIc { get; set; }

        [Required]
        public int OpIcId { get; set; }

        [Required]
        public string ScName { get; set; }
        [Required]
        public int VesselId { get; set; }
        [ForeignKey("PodId")]
        public virtual Port Pod { get; set; }

        [Required]
        public int PodId { get; set; }

        [Required]
        public int Packages { get; set; }

        [Required]
        public int UnitId { get; set; }

        [Required]
        public string Service { get; set; }

        [Required]
        public bool IsFinish { get; set; }


        [ForeignKey("SlinesId")]
        public virtual Carrier SLines { get; set; }
        [Required]
        public int SlinesId { get; set; }


        [ForeignKey("AgentId")]
        public virtual Carrier Agent { get; set; }

        [Required]
        public int AgentId { get; set; }

        [Required] public int VoyageId { get; set; }

        [ForeignKey("DeliveryId")]
        public virtual Port Delivery { get; set; }
        [Required]
        public int DeliveryId { get; set; }

        [Required]
        public double Gw { get; set; }
        [Required]
        public double Cbm { get; set; }

        public string Notes { get; set; }

        public string UpdateName { get; set; }

        public DateTimeOffset? UpdateAt { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public int? CreatorId { get; set; }
        public virtual User Creator { get; set; }
    }
}
