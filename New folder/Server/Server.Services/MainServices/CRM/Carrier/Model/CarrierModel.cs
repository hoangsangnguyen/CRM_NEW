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
            CountryItems = new List<SelectListItem>();
        }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string FullEnglishName { get; set; }

        public string Contact { get; set; }

        public string Cell { get; set; }

        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public IList<SelectListItem> CountryItems { get; set; }
    }
}
