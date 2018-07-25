using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Vino.Server.Services.MainServices.BaseService;

namespace Vino.Server.Services.MainServices.CRM.AirImp.Models
{
    public class AirImpModel : BaseDto
    {
        public AirImpModel()
        {
        }

        [Required]
        public string JobId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngày khởi tạo")]
        public string Created { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngày ETA")]
        public string Eta { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn mawb number")]
        public string MawbNumber { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mã chuyến bay")]
        public string FlightNumber { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn ngày bay")]
        public string FLyDate { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn commodity hoặc thêm mới")]
        public int? CommodityId { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn shipment hoặc thêm mới")]
        public int? ShipmentId { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn loại bill")]
        public int? TypeOfBillId { get; set; }
        [Required]
        public bool IsFinish { get; set; }

        public string OpIcName { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn opic hoặc thêm mới")]
        public int? OpIcId { get; set; }

        public string Service { get; set; }

        public string  AolName { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn AOL hoặc thêm mới")]
        public int? AolId { get; set; }

        public string DeliveryName { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn delivery hoặc thêm mới")]
        public int? DeliveryId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số lượng")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn unit")]
        public int? UnitId { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập GW")]
        public double Gw { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập CW")]
        public double Cw { get; set; }

        public string AirlinesName { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn airline hoặc thêm mới")]
        public int? AirlineId { get; set; }

        public string AgentName { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn agent hoặc thêm mới")]
        public int? AgentId { get; set; }

        public string AodName { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn AOD hoặc thêm mới")]
        public int? AodId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Routing")]
        public string Routing { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập SCN")]
        public string Scn { get; set; }

        public string Notes { get; set; }

        /**
        * Creator
        */
        public string CreatedAt { get; set; }

        public int CreatorId { get; set; }

        /**
         * Update
         */
        public string UpdateName { get; set; }

        public string UpdateAt { get; set; }

    }
}
