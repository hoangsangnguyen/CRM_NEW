using System.Threading.Tasks;
using System.Web.Http;
using Vino.Server.Services.MainServices.Auth;
using Vino.Shared.Dto.Common;
using Vino.Shared.Dto.Employees;

namespace Vino.Server.Api.Api
{
    [RoutePrefix("api/token")]
    public class TokenController : BaseApiController
    {
        private readonly UserAuthService _authService;
        public TokenController(UserAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        public async Task<TokenResponse> Post([FromBody]TokenRequest request)
        {
            var result = await _authService.Login(request);
            return result;
        }
        [HttpPost]
        [Route("refresh")]
        public async Task<TokenResponse> Refresh([FromBody] string refreshToken)
        {
            return await _authService.Refresh(refreshToken);
        }
	   
	}
}