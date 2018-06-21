using System.Web.Mvc;

namespace Vino.Server.Web.Areas.Admin.Models.ExaminationProcedure
{
    public class ArticleModel
    {
        public int Id { get; set; }
        public string SystemName { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        public string Body { get; set; }
        public bool Published { get; set; }
        public string CreatedAt { get; set; }
        public int DisplayOrder { get; set; }

        //public int SourceId { get; set; }
        //public string HospitalName { get; set; }
        //public bool ContinueEditing { get; set; }
    }
}