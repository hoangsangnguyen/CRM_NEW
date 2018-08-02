using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Web.Core.Auth;
using Falcon.Web.Core.Data;

namespace Vino.Server.Data.CRM
{
    public class LclExpSi : BaseEntity
    {
        [Required(ErrorMessage = "Vui lòng chọn MBL")]
        public int? LclExpId { get; set; }
        public virtual LclExp LclExp { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Reference No")]
        public string ReferenceNo { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Booking number")]
        public string BookingNumber { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn hãng tàu")]
        public string Attn { get; set; }

        public string ShippingLines { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngày")]
        public DateTimeOffset? Date { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn shipper")]
        public int? ShipperId { get; set; }
        public virtual CrmCustomer Shipper { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn real shipper")]
        public int? RealShipperId { get; set; }
        public virtual CrmCustomer RealShipper { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn consignee")]
        public int? ConsigneeId { get; set; }
        public virtual CrmCustomer Consignee { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn real consignee")]
        public int? RealConsigneeId { get; set; }
        public virtual CrmCustomer RealConsignee { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn notify party")]
        public int? NotifyPartyId { get; set; }
        public virtual CrmCustomer NotifyParty { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn port of loading")]
        public int? PortofLoadingId { get; set; }
        public virtual Port PortOfLoading { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn port of discharge")]
        public int? PortofDischargeId { get; set; }
        public virtual Port PortOfDischarge { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn place of delivery")]
        public int? PlaceOfDeliveryId { get; set; }
        public virtual Port PlaceOfDelivery { get; set; }

        [Required (ErrorMessage = "Vui lòng chọn tên tàu")]
        public int? VesselId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ngày Etd")]
        public DateTimeOffset Etd { get; set; }

        public string Container { get; set; }

        public string DescriptionOfGoods { get; set; }

        public string QtyOfContainer { get; set; }

        public int Packages { get; set; }

        public double Gw { get; set; }

        public double Cbm { get; set; }

        public string Remark { get; set; }

        public int? PaymentId { get; set; }

        public string UpdateName { get; set; }

        public DateTimeOffset? UpdateAt { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public int? CreatorId { get; set; }
        public virtual User Creator { get; set; }


    }
}
