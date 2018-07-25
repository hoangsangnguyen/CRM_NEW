using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Vino.Server.Services.MainServices.BaseService;
using Vino.Server.Services.MainServices.CRM.Carrier.Model;
using Vino.Server.Services.MainServices.CRM.HblLclExp.Models;
using Vino.Server.Services.MainServices.CRM.Port.Model;

namespace Vino.Server.Services.MainServices.CRM.LclExp.Models
{
    public class LclExpModel : BaseDto
    {
        public LclExpModel()
        {
            Items = new List<HblLclExpModel>();
        }

        [Required]
        public string JobId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngày khởi tạo")]
        public string Created { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngày ETD")]
        public string Etd { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngày ETA")]
        public string Eta { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập bkg number")]
        public string BkgNumber { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập MBL number")]
        public string MblNumber { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn MblType hoặc thêm mới")]
        public int? MblTypeId { get; set; }

        [Required]
        public bool IsFinish { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn OP.IC hoặc thêm mới")]
        public int? OpIcId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn Vessel hoặc thêm mới")]
        public int? VesselId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn shipment hoặc thêm mới")]
        public int? ShipmentId { get; set; }

        public string PolName { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn POL")]
        public int? PolId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Gw")]
        public double Gw { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Cbm")]
        public double Cbm { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập package")]
        public int Packages { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn unit")]
        public int? UnitId { get; set; }

        public string CoLoaderName { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn coloader")]
        public int? CoLoaderId { get; set; }

        public string AgentName { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn agent")]
        public int? AgentId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn commodity")]
        public int? CommodityId { get; set; }

        public string PodName { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn pod")]
        public int? PodId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn Freight")]
        public int? FreightId { get; set; }

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

        public List<HblLclExpModel> Items { get; set; }
    }
}
