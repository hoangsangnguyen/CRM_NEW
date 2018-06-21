using System.Web.Http;
using Falcon.Web.Api.ExceptionHandle;

namespace Vino.Server.Api.Api
{
    [ApiExceptionFilter]
    public class BaseApiController : ApiController
    {
    }
}
