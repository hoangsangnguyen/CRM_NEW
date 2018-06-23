using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Vino.Server.Data.CRM;
using Vino.Server.Services.MainServices.BaseService;
using Vino.Server.Services.MainServices.CRM.Carrier.Model;
using Vino.Server.Services.MainServices.CRM.Contact.Models;
using Vino.Server.Services.MainServices.CRM.Port.Model;

namespace Vino.Server.Services.MainServices.CRM.FclImp.Models
{
    public class FclImpModel : BaseDto
    {
        public FclImpModel()
        {
            CommodityItems = new List<SelectListItem>();
            ContactItems = new List<SelectListItem>();
            ShipmentItems = new List<SelectListItem>();
            PortItems = new List<SelectListItem>();
            CarrierItems = new List<SelectListItem>();
            VesselItems = new List<SelectListItem>();
            ShipmentItems = new List<SelectListItem>();
            VoyageItems = new List<SelectListItem>();
        }

        [Required]
        public string JobId { get; set; }

        [Required]
        public string Created { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngày ETA")]
        public string Eta { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập MBL Number")]
        public string MblNumber { get; set; }

        public string PolName { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn POL hoặc tạo mới")]
        public int? PolId { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Service")]
        public string Service { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn MBL Type")]
        public int? MblTypeId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn shipment")]
        public int? ShipmentId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngày ETD")]
        public string Etd { get; set; }

        public string OpIcName { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn OP.IC")]
        public int? OpIcId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ScName")]
        public string ScName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập PoNumber")]
        public string PoNumber { get; set; }

        public string PodName { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn POD hoặc tạo mới")]
        public int? PodId { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Container")]
        public string Container { get; set; }
        [Required(ErrorMessage = "Vui lòng commodity hoặc tạo mới")]
        public int? CommodityId { get; set; }

        public string SLinesName { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn S.Line hoặc tạo mới")]
        public int? SlinesId { get; set; }
        public string AgentName { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn agent hoặc tạo mới")]
        public int? AgentId { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn vessel hoặc tạo mới")]
        public int? VesselId { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn Voyage hoặc tạo mới")]
        public int? VoyageId { get; set; }


        public string DeliveryName { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn delivery hoặc tạo mới")]
        public int? DeliveryId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập GW")]
        public double Gw { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập CBM")]
        public double Cbm { get; set; }

        [Required]
        public bool IsFinish { get; set; }
        public string Notes { get; set; }

        public IList<SelectListItem> ContactItems { get; set; }
        public IList<SelectListItem> CarrierItems { get; set; }
        public IList<SelectListItem> PortItems { get; set; }
        public IList<SelectListItem> VesselItems { get; set; }
        public IList<SelectListItem> CommodityItems { get; set; }
        public IList<SelectListItem> MblItems { get; set; }
        public IList<SelectListItem> ShipmentItems { get; set; }
        public IList<SelectListItem> VoyageItems { get; set; }

    }
}
