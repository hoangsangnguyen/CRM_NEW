using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Vino.Server.Services.MainServices.Common.Models;
using Vino.Server.Services.MainServices.CRM.Carrier;

namespace Vino.Server.Web.Api
{
    public class CarrierApiController : BaseApiController
    {
        private readonly CarrierService _service;

        public CarrierApiController(CarrierService service)
        {
            _service = service;
        }

        public async Task<List<NameValueModel>> GetAll(string name = "")
        {
            var models = (await _service.GetAllAsync()).Select(d => new NameValueModel()
            {
                Name = d.FullEnglishName,
                Value = d.Id.ToString()
            }).ToList();
            return models;
        }
    }
}
