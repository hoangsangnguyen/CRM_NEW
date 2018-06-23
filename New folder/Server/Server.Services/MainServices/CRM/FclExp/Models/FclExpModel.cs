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
using Vino.Server.Services.MainServices.CRM.Contact.Models;
using Vino.Server.Services.MainServices.CRM.Port.Model;

namespace Vino.Server.Services.MainServices.CRM.FclExp.Models
{
    public class FclExpModel : BaseDto
    {
        public FclExpModel()
        {
            CommodityItems = new List<SelectListItem>();
            ContactItems = new List<SelectListItem>();
            ShipmentItems = new List<SelectListItem>();
            PortItems = new List<SelectListItem>();
            CarrierItems = new List<SelectListItem>();
            MblTypesItems = new List<SelectListItem>();
            VesselItems = new List<SelectListItem>();
            FreightItems = new List<SelectListItem>();

        }

        [Required]
        public string JobId { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn ngày khởi tạo")]
        public string Created { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn ngày ETD")]
        public string Etd { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập bkg number")]
        public string BkgNumber { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập MBL")]
        public string Mbl { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn ngày ETA")]
        public string Eta { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập PO number")]
        public string PoNumber { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn MBL Type hoặc tạo mới")]
        public int? MblTypeId { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn Vessel hoặc tạo mới")]
        public int? VesselId { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn shipment hoặc tạo mới")]
        public int? ShipmentId { get; set; }

        public string PolName { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn POL")]
        public int? PolId { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn Freight hoặc tạo mới")]
        public int? FreightId { get; set; }
        public string OpIcName { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn OP.IC hoặc tạo mới")]
        public int? OpIcId { get; set; }
        [Required]
        public bool IsFinish { get; set; }
        public string SLinesName { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn S.Line")]
        public int? SlinesId { get; set; }
        public string AgentName { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn agent hoặc tạo mới")]
        public int? AgentId { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn container")]
        public int? ContainerId { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn commodity")]
        public int? CommodityId { get; set; }
        public string PodName { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn POD hoặc tạo mới")]
        public int? PodId { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập service")]
        public string Service { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập GW")]
        public double Gw { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập GW")]
        public double Cbm { get; set; }
        public string Notes { get; set; }

        public IList<SelectListItem> CommodityItems { get; set; }
        public IList<SelectListItem> ContactItems { get; set; }
        public IList<SelectListItem> ShipmentItems { get; set; }
        public IList<SelectListItem> PortItems { get; set; }
        public IList<SelectListItem> CarrierItems { get; set; }
        public IList<SelectListItem> MblTypesItems { get; set; }
        public IList<SelectListItem> VesselItems { get; set; }
        public IList<SelectListItem> FreightItems { get; set; }


    }
}
