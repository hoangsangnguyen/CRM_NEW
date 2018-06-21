using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Falcon.Web.Core.Helpers;
using Vino.Server.Services.MainServices.Common;
using Vino.Shared.Dto;

namespace Vino.Server.Api.Api
{
    [RoutePrefix("api/lookups")]
    public class LookupsController : BaseApiController
    {
        private readonly LookupService _lookupService;

        public LookupsController(LookupService lookupService)
        {
            _lookupService = lookupService;
        }
		// GET: api/Lookups
		[Route("")]
		public async Task<IEnumerable<LookupDto>> Get()
		{
			return await _lookupService.GetAlLookups();
		}
	}
}
