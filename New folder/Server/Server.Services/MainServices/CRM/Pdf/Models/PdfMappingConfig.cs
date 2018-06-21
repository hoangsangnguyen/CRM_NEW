using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vino.Server.Services.MainServices.CRM.Pdf.Models
{
    public class PdfMappingConfig
    {
        #region Properties
        public string PdfTemplateId { get; set; }
        public string PdfTemplatePath { get; set; }
        public string XmlMappingPath { get; set; }
        public string SaveLocalPath { get; set; }
        public string DocId { get; set; }
        public string DocName { get; set; }
        #endregion
    }
}
