using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http;
using System.Windows.Forms.VisualStyles;
using Falcon.Web.Core.Helpers;
using iTextSharp.text.pdf;
using Vino.Server.Services.MainServices.Common.Models;
using Vino.Server.Services.MainServices.CRM.Customer;
using Vino.Server.Services.MainServices.Employees;

namespace Vino.Server.Web.Api
{
    public class CustomerApiController : BaseApiController
    {
        private readonly CrmCustomerService _service;

        public CustomerApiController(CrmCustomerService service)
        {
            _service = service;
        }

        public async Task<List<NameValueOptionalModel>> GetAllCustomers(string name = "",
            bool withAll = false, bool sameAsConsignee = false)
        {
            var models = (await _service.GetAllAsync()).Select(d => new NameValueOptionalModel
            {
                Name = d.FullVietNamName,
                Value = d.Id.ToString(),
                Optional = d.FullVietNamName + " - <br/>" + d.Address + " - " + d.FaxNo
            }).Where(p => p.Name.ToLower().Contains(name.IsNullOrEmpty() ? "" : name)).ToList();

            if (withAll)
                models.Insert(0, new NameValueOptionalModel { Name = "Tất cả", Value = "0", Optional = ""});
            else if (sameAsConsignee)
            {
                models.Insert(0, new NameValueOptionalModel () { Name = "SAME AS CONSIGNEE", Value = "0", Optional = ""});
            }
            return models;
        }

    }
}
