using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Web.Http;
using Falcon.Web.Core.Auth;
using Vino.Server.Services.MainServices.Auth;

namespace Vino.Server.Api.Api
{
    [RoutePrefix("api/auth")]
    public class AuthController : BaseApiController
    {
        private readonly UserAuthService _authService;
        public AuthController(UserAuthService authService)
        {
            _authService = authService;
        }
      
      //TODO
		//[HttpPut]
		//[Route("{id}")]
		//public void Put(int id, [FromBody]LoginRequest value)
		//{
		//	Task.Run(async () =>
		//	{
		//		await _authService.ChangePassword(id, value.Password);
		//	}).GetAwaiter().GetResult();

		//}
	}
}