using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Web.Core.Data;
using Vino.Server.Services.MainServices.CRM.Pdf.Models;
using WebSupergoo.ABCpdf8;
using WebSupergoo.ABCpdf8.Objects;
using Vino.Server.Services.Helper;

namespace Vino.Server.Services.MainServices.BaseService
{
    public class PdfExportService<TEntity> where TEntity : BaseEntity
    {
        public byte[] GetLclImpPdfContent(PdfMappingConfig lclPdfModel, TEntity inputData)
        {
            // bind data to model export
            //crm_LcLImp exportModel = new crm_LcLImp();
            //exportModel.ContactId = "xxx";
            //exportModel.SCName = "helo";
            string className = inputData.GetType().Name;
            lclPdfModel.DocName = string.Format("{0}_{1}_{2}", className, inputData.Id, DateTime.Now);
            return CreatePdfContent(lclPdfModel, inputData);
        }

        private byte[] CreatePdfContent(PdfMappingConfig pdfConfig, TEntity mpaviewmodel)
        {
            Doc doc = new Doc();
            doc.Read(pdfConfig.PdfTemplatePath);
            doc.Form.MakeFieldsUnique();
            List<Field> pdfFields = GetAllPdfFormFields(doc.Form.Fields);
            //Get lisst file Mapping
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(pdfConfig.XmlMappingPath);
            List<PdfMappingViewModel> listMapping = dataSet.Tables[1].Select().CopyToDataTable().To<PdfMappingViewModel>();
            PdfBindingData(pdfFields, listMapping, mpaviewmodel);
            doc.Encryption.Type = 2;
            doc.Encryption.OwnerPassword = DateTime.Now.ToString("YY-MM-DD");
            doc.Encryption.CanFillForms = false;
            doc.Encryption.CanChange = false;
            doc.Encryption.CanEdit = false;
            byte[] data = doc.GetData();
            doc.Dispose();
            return data;
        }

        private void PdfBindingData(List<Field> pdfFields, List<PdfMappingViewModel> pdfMappings, TEntity viewModel)
        {
            int pdfFieldsCount = pdfFields.Count;
            IEnumerable<Field> pdfItems = pdfFields.Where(x => x.FieldType != FieldType.Unknown);
            foreach (Field pdfField in pdfItems)
            {
                pdfField.Focus();
                PdfMappingViewModel pdfMapping = pdfMappings.FirstOrDefault(x => x.Name == pdfField.Name);
                if (pdfMapping == null)
                {
                    continue;
                }
                object valueOf = null;
                string value = string.Empty;
                if (!string.IsNullOrEmpty(pdfMapping.Mapping))
                {
                    valueOf = viewModel.ValueOf(pdfMapping.Mapping);
                    value = valueOf != null ? valueOf.ToString() : string.Empty;
                }
                switch (pdfField.FieldType)
                {
                    case FieldType.Pushbutton:
                        break;
                    case FieldType.Checkbox:
                        if (value.ToLower().Equals("true"))
                        {
                            pdfField.Value = "On";
                        }
                        else if (value.ToLower().Equals("false"))
                        {
                            pdfField.Value = "Off";
                        }
                        else
                        {
                            pdfField.Value = value;
                        }
                        break;
                    case FieldType.Radio:
                        if (!string.IsNullOrEmpty(value))
                        {
                            string[] options = pdfMapping.Options != null ?
                                pdfMapping.Options.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries) : new string[] { };
                            int idx = FindIndex(pdfField.Options, options, value.ToLower());
                            if (idx != -1 && idx < pdfField.Options.Length)
                            {
                                pdfField.Value = pdfField.Options[idx];
                            }
                            else
                            {
                                pdfField.Value = "Off";
                            }

                        }
                        else
                        {
                            pdfField.Value = "Off";
                        }
                        break;
                    case FieldType.Text:
                        if (!string.IsNullOrEmpty(value))
                        {
                            pdfField.Value = value;

                        }
                        else
                        {
                            pdfField.Value = string.Empty;
                        }
                        break;
                    case FieldType.List:
                        break;
                    case FieldType.Combo:
                        break;
                    case FieldType.Unknown:
                        break;

                }
            }
        }

        private int FindIndex(string[] fieldOptions, string[] xmlOptions, string value)
        {
            string xmlValueOption = "";
            foreach (string item in xmlOptions)
            {
                string[] arr = item.Split('=');
                if (arr.Length >= 2 && arr[1].Equals(value, StringComparison.OrdinalIgnoreCase))
                {
                    xmlValueOption = arr[0];
                }
            }
            for (int i = 0; i < fieldOptions.Length; i++)
            {
                if (xmlValueOption.Equals(fieldOptions[i], StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }
            return -1;
        }

        private List<Field> GetAllPdfFormFields(Fields pdfFields, List<Field> fields = null)
        {
            if (fields == null)
            {
                fields = new List<Field>();
            }
            foreach (Field pdfField in pdfFields)
            {
                if (pdfField.FieldType != FieldType.Unknown)
                {
                    fields.Add(pdfField);
                }
                else
                {
                    GetAllPdfFormFields(pdfField.Kids, fields);
                }
            }
            return fields;
        }

    }
}

