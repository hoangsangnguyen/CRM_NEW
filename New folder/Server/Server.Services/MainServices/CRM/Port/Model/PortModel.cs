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

namespace Vino.Server.Services.MainServices.CRM.Port.Model
{
    public class PortModel : BaseDto
    {
        public PortModel()
        {
        }
        [Required]
        public string PortCode { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên")]
        public string PortName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập nationality hoặc tạo mới")]
        public int? NationalityId { get; set; }
        public string NationalityName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập zone hoặc tạo mới")]
        public int? ZoneId { get; set; }
        public string ZoneName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập local zone")]
        public string LocalZone { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn mode hoặc tạo mới")]
        public int? ModeId { get; set; }
        public string ModeName { get; set; }

    }
}
