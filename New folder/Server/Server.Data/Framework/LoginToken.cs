using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Falcon.Web.Core.Data;

namespace Vino.Server.Data.Framework
{
    public class LoginToken : BaseEntity
    {
        public int UserId { get; set; }
        [MaxLength(1024)]
        public string Token { get; set; }
    }
}