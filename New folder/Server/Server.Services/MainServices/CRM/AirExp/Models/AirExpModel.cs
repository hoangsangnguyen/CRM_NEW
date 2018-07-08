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
        }

        [Required]
        public string JobId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngày tạo")]
        public string Created { get; set; }

        public string Service { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngày ETD")]
        public string Etd { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngày ETA")]
        public string Eta { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn commodity hoặc thêm mới")]
        public int? CommodityId { get; set; }

        public string MawbNumber { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn loại bill hoặc thêm mới")]
        public int? TypeOfBillId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn mã chuyến bay")]
        public string FlightNumber { get; set; }

        public string FlyDate { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn OP.IC hoặc thêm mới")]
        public int? OpicId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn shipment hoặc thêm mới")]
        public int? ShipmentId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn origin port hoặc thêm mới")]
        public int? OriginPortId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn transit porthoặc thêm mới")]
        public int? TransitPortId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số lượng")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn unit hoặc thêm mới")]
        public int? UnitId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn payment hoặc thêm mới")]
        public int? PaymentId { get; set; }

        public bool IsFinish { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn carrier hoặc thêm mới")]
        public int? CarrierId { get; set; }
        public string CarrierName { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn agent hoặc thêm mới")]
        public int? AgentId { get; set; }
        public string AgentName { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn destination port hoặc thêm mới")]
        public int? DestinationId { get; set; }
        public double Gw { get; set; }
        public double Cw { get; set; }

        public string Notes { get; set; }

    }
}
