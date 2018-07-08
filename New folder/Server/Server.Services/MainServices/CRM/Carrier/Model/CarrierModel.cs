using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Vino.Server.Services.MainServices.BaseService;

namespace Vino.Server.Services.MainServices.CRM.Carrier.Model
{
    public class CarrierModel : BaseDto
    {
        public CarrierModel()
        {
        }

        [Required]
        public string Code { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng FullEnglishName")]
        public string FullEnglishName { get; set; }

        public string Contact { get; set; }

        public string Cell { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn counttry")]
        public int? CountryId { get; set; }
        public string CountryName { get; set; }

    }
}
