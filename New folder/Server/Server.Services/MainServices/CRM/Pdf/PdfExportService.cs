//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Falcon.Web.Core.Data;
//using Falcon.Web.Core.Helpers;
//using Vino.Server.Services.MainServices.BaseService;
//using Vino.Server.Services.MainServices.CRM.Pdf.Models;
//using WebSupergoo.ABCpdf8;
//using WebSupergoo.ABCpdf8.Objects;
//using Vino.Server.Services.Helper;

//namespace Vino.Server.Services.MainServices.CRM.Pdf
//{
//    public class PdfExportService<TEntity> : IPdfExportService<TEntity>
//    where TEntity : BaseEntity
//    {
//        //public byte[] GetPdfContent(TMappingConfig pdfModel, TEntity inputData)
//        //{
//        //    pdfModel.DocName = string.Format("LclImp_{0}_{1}", inputData.Id, DateTime.Now);
//        //}

//        public byte[] CreatePdfContent(PdfMappingConfig pdfConfig, TEntity mpaviewmodel)
//        {
//            Doc doc = new Doc();
//            doc.Read(pdfConfig.PdfTemplatePath);
//            doc.Form.MakeFieldsUnique();
//            IList<Fields> pdfFields = GetAllPdfFormFields(doc.Form.Fields);
//            //Get lisst file Mapping
//            DataSet dataSet = new DataSet();
//            dataSet.ReadXml(pdfConfig.XmlMappingPath);
//            List<PdfMappingViewModel> listMapping = dataSet.Tables[1].Select().CopyToDataTable().To();
//            PdfBindingData(pdfFields, listMapping, mpaviewmodel);
//            doc.Encryption.Type = 2;
//            doc.Encryption.OwnerPassword = DateTime.Now.ToString("YY-MM-DD");
//            doc.Encryption.CanFillForms = false;
//            doc.Encryption.CanChange = false;
//            doc.Encryption.CanEdit = false;
//            byte[] data = doc.GetData();
//            doc.Dispose();
//            return data;
//        }

//        public void PdfBindingData(IList<Fields> pdfFields, List<PdfMappingConfig> pdfMappings, TEntity viewModel)
//        {
//            throw new NotImplementedException();
//        }

//        public PdfMappingConfig GetConfigMapping()
//        {
//            throw new NotImplementedException();
//        }

//        public int FindIndex(string[] fieldOptions, string[] xmlOptions, string value)
//        {
//            throw new NotImplementedException();
//        }

//        public IList<Fields> GetAllPdfFormFields(Fields pdfFields, List<Fields> fields = null)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
