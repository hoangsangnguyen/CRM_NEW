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
            NationalityItems = new List<SelectListItem>();
            ZoneItems = new List<SelectListItem>();
            ModeItems = new List<SelectListItem>();
        }
        [Required]
        public string PortCode { get; set; }

        [Required]
        public string PortName { get; set; }

        public int NationalityId { get; set; }

        public int ZoneId { get; set; }

        [Required]
        public string LocalZone { get; set; }
        public int ModeId { get; set; }
        public IList<SelectListItem> NationalityItems { get; set; }
        public IList<SelectListItem> ZoneItems { get; set; }
        public IList<SelectListItem> ModeItems { get; set; }

    }
}
