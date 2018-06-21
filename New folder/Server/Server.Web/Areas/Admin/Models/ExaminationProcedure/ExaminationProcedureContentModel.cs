using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Vino.Server.Web.Areas.Admin.Models.ExaminationProcedure
{
    public class ExaminationProcedureContentModel
    {
        public ExaminationProcedureContentModel()
        {
            Published = true;
        }
        public int Id { get; set; }
        public string SystemName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tiêu đề")]
        public string Title { get; set; }
        [AllowHtml]
        [Required(ErrorMessage = "Vui lòng nhập nội dung")]
        public string Body { get; set; }
        public bool Published { get; set; }
        public string CreatedAt { get; set; }
        public int DisplayOrder { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn bệnh viện")]
        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
        public bool ContinueEditing { get; set; }
    }
}