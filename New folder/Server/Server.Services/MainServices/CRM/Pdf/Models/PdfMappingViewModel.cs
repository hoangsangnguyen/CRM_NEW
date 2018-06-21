using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vino.Server.Services.MainServices.CRM.Pdf.Models
{
    public class PdfMappingViewModel
    {
        public string Name { get; set; }
        public string Mapping { get; set; }
        public string Template { get; set; }
        public object Default { get; set; }
        //public AsFormat {get;set;}
        public string Options { get; set; }

    }
}
