using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Web.Core.Data;

namespace Vino.Server.Data.CRM
{
    public class HblLclExp : BaseEntity
    {
        [Required(ErrorMessage = "Vui lòng chọn Lcl export")]
        public int? LclExpId { get; set; }
        public virtual LclExp LclExp { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập BL Number")]
        public string BlNumber { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Booking number")]
        public string BookingNumber { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn HBL type")]
        public int? HblType { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn Shipper hoặc tạo mới")]
        public int? ShipperId { get; set; }
        public virtual CrmCustomer Shipper{ get; set; }

        [Required(ErrorMessage = "Vui lòng chọn Consignee hoặc tạo mới")]
        public int? ConsigneeId { get; set; }
        public virtual CrmCustomer Consignee { get; set; }

        public int? NotifyPartyId { get; set; }
        public virtual CrmCustomer NotifyParty { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn Local Vessel hoặc tạo mới")]
        public int? LocalVessel { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn PlaceOfReceipt hoặc tạo mới")]
        public int? PlaceOfReceiptId { get; set; }
        public virtual Port PlaceOfReceipt{ get; set; }

        public int? OceanVessel { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn PortOfLoaing hoặc tạo mới")]
        public int? PortOfLoaingId { get; set; }
        public virtual Port PortOfLoaing { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn PortOfDischarge hoặc tạo mới")]
        public int? PortOfDischargeId { get; set; }
        public virtual Port PortOfDischarge { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn TranshipmentPort hoặc tạo mới")]
        public int? TranshipmentPortId { get; set; }
        public virtual Port TranshipmentPort { get; set; }

        public string Container { get; set; }

        public int NumberOfPackage { get; set; }

        public int QtyOfContainer { get; set; }

        public string PoNumber { get; set; }

        public string DescriptionOfGoods { get; set; }

        public double GrossWeight { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn Unit")]
        public int? UnitId { get; set; }

        public double Measurement { get; set; }

        public string OnBoardStatus { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn Forwarding Agent")]
        public string ForwardingAgent { get; set; }

        public double FreightAmount { get; set; }
        public DateTimeOffset? ExRef { get; set; }
        public double ReferenceNumber { get; set; }

        [Required(ErrorMessage = "Vui lòng chọng Final Destination")]
        public int? FinalDestinationId { get; set; }
        public virtual Port FinalDestination { get; set; }

        [Required(ErrorMessage = "Vui lòng chọng PlaceOfDelivery")]
        public int? PlaceOfDeliveryId { get; set; }
        public virtual Port PlaceOfDelivery { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập country of origin")]
        public int? CountryOfOriginId { get; set; }

        public int? TypeOfMoveId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngày Closing")]
        public DateTimeOffset ClosingDate { get; set; }

        public int? FreightPayableId { get; set; }

        public int NumberOfOriginal { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngày Selling")]
        public DateTimeOffset SellingDate { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn Delivery Of Good hoặc thêm mới")]
        public int? DeliveryOfGoodsId { get; set; }

        public virtual CrmCustomer DeliveryOfGoods { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn Commodity hoặc thêm mới")]
        public int? CommodityId { get; set; }

        public int? PlaceOfIssueId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngày Issue")]
        public DateTimeOffset IssueDate { get; set; }

    }
}
