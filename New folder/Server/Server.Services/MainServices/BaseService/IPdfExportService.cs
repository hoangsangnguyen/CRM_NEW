using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vino.Server.Services.MainServices.CRM.Pdf.Models;
using WebSupergoo.ABCpdf8.Objects;

namespace Vino.Server.Services.MainServices.BaseService
{
    public interface IPdfExportService<TEntity>
    {
        //byte[] GetPdfContent(TMappingConfig pdfModel, TEntity inputData);
        byte[] CreatePdfContent(PdfMappingConfig pdfConfig, TEntity mpaviewmodel);
        void PdfBindingData(IList<Fields> pdfFields, List<PdfMappingConfig> pdfMappings, TEntity viewModel);
        PdfMappingConfig GetConfigMapping();

        int FindIndex(string[] fieldOptions, string[] xmlOptions, string value);
        IList<Fields> GetAllPdfFormFields(Fields pdfFields, List<Fields> fields = null);

    }
}
