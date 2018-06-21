using System.ComponentModel.DataAnnotations;
using Vino.Shared.Constants;
using Vino.Shared.Constants.Common;

namespace Vino.Server.Services.MainServices.Common.Models
{
    public class LookupModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn loại lookup")]
        public LookupTypes Type { get; set; }
        public string TypeName => Type.ToString();
        /// <summary>
        /// Dung lam khoa de so sanh member trong 1 type, thay cho Id
        /// </summary>
        [MaxLength(32)]
        [Required(ErrorMessage = "Vui lòng nhập mã số")]
        public string Code { get; set; }
        public int Order { get; set; }
        [MaxLength(256)]
        public string Title { get; set; }
        [MaxLength(3, ErrorMessage = "Không quá 3 ký tự")]
        public string App { get; set; }
        public bool ContinueEditing { get; set; }
    }
}
