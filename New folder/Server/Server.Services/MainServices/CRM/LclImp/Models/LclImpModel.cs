using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Falcon.Web.Core.Data;
using Vino.Server.Data.CRM;
using Vino.Server.Services.MainServices.BaseService;
using Vino.Server.Services.MainServices.CRM.Carrier.Model;
using Vino.Server.Services.MainServices.CRM.Contact.Models;
using Vino.Server.Services.MainServices.CRM.Port.Model;

namespace Vino.Server.Services.MainServices.CRM.LclImp.Models
{
    public class LclImpModel : BaseDto
    {
        public LclImpModel()
        {
            CommodityItems = new List<SelectListItem>();
            ContactItems = new List<SelectListItem>();
            ShipmentItems = new List<SelectListItem>();
            PortItems = new List<SelectListItem>();
            CarrierItems = new List<SelectListItem>();
            VesselItems = new List<SelectListItem>();
            MblItems = new List<SelectListItem>();
            UnitItems = new List<SelectListItem>();
            VoyageItems = new List<SelectListItem>();

        }

        [Required]
        public string JobId { get; set; }

        [Required]
        public string Created { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngày ETD")]
        public string Etd { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngày ETA")]
        public string Eta { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập MBL Number")]
        public string MblNumber { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn MBL Type")]
        public int? MblTypeId { get; set; }

        public string PolName { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn POL hoặc tạo mới")]
        public int? PolId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn commodity")]
        public int? CommodityId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn shipment hoặc tạo mới")]
        public int? ShipmentId { get; set; }

        public string OpIcName { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn OP.IC hoặc tạo mới")]
        public int? OpIcId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ScName")]
        public string ScName { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn Vessel hoặc tạo mới")]
        public int? VesselId { get; set; }

        public string PodName { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn POD hoặc tạo mới")]
        public int? PodId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập package")]
        public int Packages { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn unit hoặc tạo mới")]
        public int? UnitId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập service")]
        public string Service { get; set; }

        [Required]
        public bool IsFinish { get; set; }

        public string SLinesName { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn S.Line hoặc tạo mới")]
        public int? SlinesId { get; set; }

        public string AgentName { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn agent hoặc tạo mới")]
        public int? AgentId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn voyage hoặc tạo mới")]
        public int? VoyageId { get; set; }

        public string DeliveryName { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn delivery hoặc tạo mới")]
        public int? DeliveryId { get; set; }

        [Required]
        public double Gw { get; set; }
        [Required]
        public double Cbm { get; set; }

        public string Notes { get; set; }

        public IList<SelectListItem> ContactItems { get; set; }
        public IList<SelectListItem> CarrierItems { get; set; }
        public IList<SelectListItem> PortItems { get; set; }
        public IList<SelectListItem> VesselItems { get; set; }
        public IList<SelectListItem> CommodityItems { get; set; }
        public IList<SelectListItem> MblItems { get; set; }
        public IList<SelectListItem> ShipmentItems { get; set; }
        public IList<SelectListItem> UnitItems { get; set; }
        public IList<SelectListItem> VoyageItems { get; set; }


    }
}
