using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Vino.Server.Services.MainServices.Common.Models;
using Vino.Server.Services.MainServices.CRM.LclExp;

namespace Vino.Server.Web.Api
{
    public class LclExpApiController : BaseApiController
    {
        private readonly LclExpService _service;

        public LclExpApiController(LclExpService service)
        {
            _service = service;
        }

        public async Task<List<NameValueModel>> GetAll()
        {
            var models = (await _service.GetAllAsync()).Select(d => new NameValueModel()
            {
                Name = d.JobId,
                Value = d.Id.ToString()
            }).ToList();
            return models;
        }
    }
}
