using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Vino.Server.Data.CRM;
using Vino.Server.Services.MainServices.BaseService;

namespace Vino.Server.Services.MainServices.CRM.HblLclExp.Models
{
    public class HblLclExpModel : BaseDto
    {
        public HblLclExpModel()
        {
            CustomerItems = new List<SelectListItem>();
            PortItems = new List<SelectListItem>();
            HblTypeItems = new List<SelectListItem>();
            CountryItems = new List<SelectListItem>();
            TypeOfMoveItems = new List<SelectListItem>();
            VesselItems = new List<SelectListItem>();
            UnitItems = new List<SelectListItem>();
            CommodityItems = new List<SelectListItem>();
            PlaceItems = new List<SelectListItem>();
        }

        [Required(ErrorMessage = "Vui lòng chọn LclExp")]
        public int? LclExpId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập BL Number")]
        public string BlNumber { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Booking number")]
        public string BookingNumber { get; set; }

        /*
         * Hbl type and name
         */
        [Required(ErrorMessage = "Vui lòng chọn HBL type")]
        public int? HblType { get; set; }

        public string HblTypeName { get; set; }

        /*
         * Shipper and name
         */
        [Required(ErrorMessage = "Vui lòng chọn Shipper hoặc tạo mới")]
        public int? ShipperId { get; set; }
        public string ShipperName { get; set; }

        /*
         * Consignee and name
         */
        [Required(ErrorMessage = "Vui lòng chọn Consignee hoặc tạo mới")]
        public int? ConsigneeId { get; set; }
        public string ConsigneeName { get; set; }

        /*
         * Notify party and name
         */
        public int? NotifyPartyId { get; set; }
        public string NotifyPartyName { get; set; }

        /*
         * Local vessel and name
         */
        [Required(ErrorMessage = "Vui lòng chọn Local Vessel hoặc tạo mới")]
        public int? LocalVessel { get; set; }
        public string LocalVesselName { get; set; }

        /*
         * Place of receipt and name
         */
        [Required(ErrorMessage = "Vui lòng chọn PlaceOfReceipt hoặc tạo mới")]
        public int? PlaceOfReceiptId { get; set; }
        public string PlaceOfReceiptName { get; set; }

        /*
         * Ocean vessel and name
         */
        public int? OceanVessel { get; set; }
        public string OceanVesselName { get; set; }

        /*
         * Port of loading and name
         */
        [Required(ErrorMessage = "Vui lòng chọn PortOfLoaing hoặc tạo mới")]
        public int? PortOfLoaingId { get; set; }
        public string PortOfLoaingName { get; set; }

        /*
         * Port of discharge and name
         */
        [Required(ErrorMessage = "Vui lòng chọn PortOfDischarge hoặc tạo mới")]
        public int? PortOfDischargeId { get; set; }
        public string PortOfDischargeName { get; set; }

        /*
         * Transhipment port and name
         */
        [Required(ErrorMessage = "Vui lòng chọn TranshipmentPort hoặc tạo mới")]
        public int? TranshipmentPortId { get; set; }
        public string TranshipmentPortName { get; set; }

        public string Container { get; set; }

        public int NumberOfPackage { get; set; }

        public int QtyOfContainer { get; set; }

        public string PoNumber { get; set; }

        public string DescriptionOfGoods { get; set; }

        public double GrossWeight { get; set; }

        /*
         * Unit and name
         */
        [Required(ErrorMessage = "Vui lòng chọn Unit")]
        public int? UnitId { get; set; }

        public string UnitName { get; set; }

        public double Measurement { get; set; }

        public string OnBoardStatus { get; set; }

        /*
         * Forwareding agent
         */
        [Required(ErrorMessage = "Vui lòng chọn Forwarding Agent")]
        public string ForwardingAgent { get; set; }


        public double FreightAmount { get; set; }
        public double ExRef { get; set; }
        public double ReferenceNumber { get; set; }

        /*
         * Final Destination and name
         */
        [Required(ErrorMessage = "Vui lòng chọng Final Destination")]
        public int? FinalDestinationId { get; set; }
        public string FinalDestinationName { get; set; }

        /*
         * Place of delivery and name
         */
        [Required(ErrorMessage = "Vui lòng chọng PlaceOfDelivery")]
        public int? PlaceOfDeliveryId { get; set; }
        public string PlaceOfDeliveryName { get; set; }

        /*
         * Country of origin and name
         */
        [Required(ErrorMessage = "Vui lòng nhập country of origin")]
        public int? CountryOfOriginId { get; set; }

        public string CountryOfOriginName { get; set; }

        public int? TypeOfMoveId { get; set; }
        public string TypeOfMoveName { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngày Closing")]
        public string ClosingDate { get; set; }

        public string FreightPayableAt { get; set; }

        public int NumberOfOriginal { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngày Selling")]
        public string SellingDate { get; set; }

        /*
         * Delivery of goods and name
         */
        [Required(ErrorMessage = "Vui lòng chọn Delivery Of Good hoặc thêm mới")]
        public int? DeliveryOfGoodsId { get; set; }

        public string DeliveryOfGoodsName { get; set; }

        /*
         * Commodity and name
         */
        [Required(ErrorMessage = "Vui lòng chọn Commodity hoặc thêm mới")]
        public int? CommodityId { get; set; }

        public string CommodityName { get; set; }

        /*
         * Place of issue and name
         */
        public int? PlaceOfIssueId { get; set; }
        public string PlaceOfIssueName { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngày Issue")]
        public string IssueDate { get; set; }

        public IList<SelectListItem> CustomerItems{ get; set; }
        public IList<SelectListItem> PortItems { get; set; }
        public IList<SelectListItem> HblTypeItems { get; set; }
        public IList<SelectListItem> CountryItems { get; set; }
        public IList<SelectListItem> TypeOfMoveItems { get; set; }
        public IList<SelectListItem> VesselItems { get; set; }
        public IList<SelectListItem> UnitItems { get; set; }
        public IList<SelectListItem> CommodityItems { get; set; }
        public IList<SelectListItem> PlaceItems { get; set; }


    }
}
