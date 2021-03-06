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
    public class Port : BaseEntity
    {
        [Required]
        public string PortCode { get; set; }

        [Required]
        public string PortName { get; set; }

        public int NationalityId { get; set; }

        public int ZoneId { get; set; }

        [Required]
        public string LocalZone { get; set; }
        public int ModeId { get; set; }

        public string UpdateName { get; set; }

        public DateTimeOffset? UpdateAt { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public int CreatorId { get; set; }
        public virtual User Creator { get; set; }

        #region Map to airExp
        public ICollection<AirExp> OriginPorts { get; set; }
        public ICollection<AirExp> TransitPorts { get; set; }
        public ICollection<AirExp> Destinations { get; set; }

        #endregion

        #region Map to FclExp
        public ICollection<FclExp> FclExpPols { get; set; }
        public ICollection<FclExp> FclExpPods { get; set; }
        #endregion

        #region Mapp to LclExp
        public ICollection<LclExp> LclExpPols { get; set; }
        public ICollection<LclExp> LclExpPods { get; set; }
        #endregion

        #region Map To AirImp
        public ICollection<AirImp> AirAols { get; set; }
        public ICollection<AirImp> AirDeliveries { get; set; }
        public ICollection<AirImp> AirAods { get; set; }

        #endregion

        #region Map to FclImp
        public ICollection<FclImp> FclImpPols { get; set; }
        public ICollection<FclImp> FclImpPods { get; set; }
        public ICollection<FclImp> FclImpDeliveries { get; set; }

        #endregion

        #region Map to Lcl Imp
        public ICollection<LclImp> LclImpPols { get; set; }
        public ICollection<LclImp> LclImpPods { get; set; }
        public ICollection<LclImp> LclImpDeliveries { get; set; }


        #endregion

        #region Map to Hbl Lcl
        public ICollection<HblLclExp> PlaceOfReceipts { get; set; }
        public ICollection<HblLclExp> PortOfLoaings { get; set; }
        public ICollection<HblLclExp> PortOfDischarges { get; set; }
        public ICollection<HblLclExp> TranshipmentPorts { get; set; }
        public ICollection<HblLclExp> FinalDestinations { get; set; }
        public ICollection<HblLclExp> PlaceOfDeliveries { get; set; }


        #endregion

        #region Map to Hbl Fcl
        public ICollection<HblFclExp> FclPlaceOfReceipts { get; set; }
        public ICollection<HblFclExp> FclPortOfLoaings { get; set; }
        public ICollection<HblFclExp> FclPortOfDischarges { get; set; }
        public ICollection<HblFclExp> FclTranshipmentPorts { get; set; }
        public ICollection<HblFclExp> FclFinalDestinations { get; set; }
        public ICollection<HblFclExp> FclPlaceOfDeliveries { get; set; }


        #endregion

        #region Map to LclExp SI
        public ICollection<LclExpSi> LclExpSiPortOfLoading { get; set; }
        public ICollection<LclExpSi> LclExpSiPortOfDischarge { get; set; }
        public ICollection<LclExpSi> LclExpSiPlaceOfDelivery { get; set; }

        #endregion
    }
}
