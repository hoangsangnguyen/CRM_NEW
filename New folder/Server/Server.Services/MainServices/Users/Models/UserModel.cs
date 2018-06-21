using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Falcon.Web.Mvc.HtmlExtensions;

namespace Vino.Server.Services.MainServices.Users.Models
{
    public class UserModel
    {
        public UserModel()
        {
            RoleList = new List<string>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [NoTrim]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string Password { get; set; }
        public string Roles { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn quyền hệ thống")]
        public IList<string> RoleList { get; set; }
        public string DisplayName { get; set; }
        public bool Active { get; set; }
        public bool ChangePassword { get; set; }
        public bool ContinueEditing { get; set; }
    }
}
