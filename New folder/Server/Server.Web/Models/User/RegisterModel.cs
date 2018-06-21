using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vino.Server.Web.Models.User
{
    public class RegisterModel
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}