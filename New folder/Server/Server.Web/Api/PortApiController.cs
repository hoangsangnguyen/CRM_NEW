using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Vino.Server.Services.Helper;
using Vino.Server.Services.MainServices.Common.Models;
using Vino.Server.Services.MainServices.CRM.Port;

namespace Vino.Server.Web.Api
{
    public class PortApiController : BaseApiController
    {
        private readonly PortService _service;

        public PortApiController(PortService service)
        {
            _service = service;
        }
            
        public async Task<List<NameValueModel>> GetAll(string name = "", bool withAll = false)
        {
            var models = (await _service.GetAllAsync()).Select(d => new NameValueModel()
            {
                Name = d.PortName,
                Value = d.Id.ToString()
            }).Where(p => p.Name.ToLower().Contains(name.IsNullOrEmpty() ? "" : name)).ToList();
            if (withAll)
                models.Insert(0, new NameValueModel(){Name = "Tất cả", Value = "0"});
            return models;
        }
    }
}
