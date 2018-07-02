using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Falcon.Web.Core.Helpers;
using Vino.Server.Services.MainServices.Common.Models;
using Vino.Server.Services.MainServices.CRM.Contact;

namespace Vino.Server.Web.Api
{
    public class CrmContactApiController : BaseApiController
    {
        private readonly ContactService _service;

        public CrmContactApiController(ContactService service)
        {
            _service = service;
        }

        public async Task<List<NameValueModel>> GetAll(string name = "", bool withAll = false)
        {
            var models = (await _service.GetAllAsync()).Select(d => new NameValueModel()
            {
                Name = d.EnglishName,
                Value = d.Id.ToString()
            }).Where(p => p.Name.ToLower().Contains(name.IsNullOrEmpty() ? "" : name)).ToList();
            if (withAll)
                models.Insert(0, new NameValueModel() { Name = "Tất cả", Value = "0" });
            return models;
        }
    }
}
