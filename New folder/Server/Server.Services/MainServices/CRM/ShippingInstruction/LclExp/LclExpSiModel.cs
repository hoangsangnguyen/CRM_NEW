using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Web.Core.Auth;
using Vino.Server.Data.CRM;
using Vino.Server.Services.MainServices.BaseService;

namespace Vino.Server.Services.MainServices.CRM.ShippingInstruction.LclExp
{
    public class LclExpSiModel : BaseDto
    {
        [Required(ErrorMessage = "Vui lòng chọn MBL")]
        public int? LclExpId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Reference No")]
        public string ReferenceNo { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Booking number")]
        public string BookingNumber { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn hãng tàu")]
        public string Attn { get; set; }
        public string ShippingLines { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn shipper")]
        public int? ShipperId { get; set; }
        public string ShipperName { get; set; }
        public string ShipperInfo { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn real shipper")]
        public int? RealShipperId { get; set; }
        public string RealShipperName { get; set; }
        public string RealShipperInfo { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn consignee")]
        public int? ConsigneeId { get; set; }
        public string ConsigneeName { get; set; }
        public string ConsigneeInfo { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn real consignee")]
        public int? RealConsigneeId { get; set; }
        public string RealConsigneeName { get; set; }
        public string RealConsigneeInfo { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn notify party")]
        public int? NotifyPartyId { get; set; }
        public string NotifyPartyName { get; set; }
        public string NotifyPartyInfo { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn port of loading")]
        public int? PortofLoadingId { get; set; }
        public string PortOfLoadingName { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn port of discharge")]
        public int? PortofDischargeId { get; set; }
        public string PortOfDischargeName { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn place of delivery")]
        public int? PlaceOfDeliveryId { get; set; }
        public string PlaceOfDeliveryName { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn tên tàu")]
        public int? VesselId { get; set; }

        public string VesselName { get; set; }


        [Required(ErrorMessage = "Vui lòng nhập ngày Etd")]
        public string Etd { get; set; }

        public string Container { get; set; }

        public string DescriptionOfGoods { get; set; }

        public string QtyOfContainer { get; set; }

        public int Packages { get; set; }

        public double Gw { get; set; }

        public double Cbm { get; set; }

        public int? Remark { get; set; }

        public int? PaymentId { get; set; }

        public string UpdateName { get; set; }

        public string UpdateAt { get; set; }

        public string CreatedAt { get; set; }

        public int? CreatorId { get; set; }
        public string CreatorName { get; set; }

        public bool Preview { get; set; }

    }
}
