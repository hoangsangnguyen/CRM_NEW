using System.ComponentModel.DataAnnotations;

namespace Vino.Server.Web.Areas.Admin.Models.Message
{
    public class SendEmailTestModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [Required(ErrorMessage = "Vui lòng nhập email nhận")]
        public string SendMailTo { get; set; }
    }
}