using System.Web.Http;

namespace Vino.Server.Api.Api
{
    [Authorize]
    public class SecureApiController : BaseApiController
    {
    }
}