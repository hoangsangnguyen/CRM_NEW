using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vino.Server.Services.MainServices.Message.Models
{
    public class EmailAccountModel
    {
        public int Id { get; set; }
        [MaxLength(512, ErrorMessage = "Chiều dài không quá 512 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập email")]
        public string Email { get; set; }
        [MaxLength(512, ErrorMessage = "Chiều dài không quá 512 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập tên hiển thị email")]
        public string DisplayName { get; set; }
        [MaxLength(512, ErrorMessage = "Chiều dài không quá 512 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập máy chủ")]
        public string Host { get; set; }
        public int Port { get; set; }
        [MaxLength(512, ErrorMessage = "Chiều dài không quá 512 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập tài khoản email")]
        public string Username { get; set; }
        [MaxLength(512, ErrorMessage = "Chiều dài không quá 512 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu email")]
        public string Password { get; set; }
        public bool EnableSsl { get; set; }
        public bool UseDefaultCredentials { get; set; }

        public bool IsDefaultEmailAccount { get; set; }
        public bool ContinueEditing { get; set; }
        public bool ChangePassword { get; set; }
    }
}
