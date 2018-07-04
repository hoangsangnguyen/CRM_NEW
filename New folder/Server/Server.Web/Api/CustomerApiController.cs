using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Falcon.Web.Core.Helpers;
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

        public async Task<List<NameValueModel>> GetAllCustomers(string name = "",
            bool withAll = false)
        {
            var models = (await _service.GetAllAsync()).Select(d => new NameValueModel()
            {
                Name = d.FullVietNamName,
                Value = d.Id.ToString()
            }).Where(p => p.Name.ToLower().Contains(name.IsNullOrEmpty() ? "" : name)).ToList();
            if (withAll)
                models.Insert(0, new NameValueModel() { Name = "Tất cả", Value = "0" });
            return models;
        }

    }
}
