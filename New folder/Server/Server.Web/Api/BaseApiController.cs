using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Falcon.Web.Api.ExceptionHandle;
using Falcon.Web.Core.Infrastructure;
using Vino.Server.Web.Api;

namespace Vino.Server.Web.Api
{
    [ApiExceptionFilter]
    [Authorize]
    public class BaseApiController : ApiController
    {
    }
}
