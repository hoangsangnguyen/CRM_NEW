using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Web.Core.Data;

namespace Vino.Server.Data.CRM
{
    public class SIFclExp : BaseEntity
    {
        [Required(ErrorMessage = "Vui lòng nhập Refence No")]
        public string ReferenceNo { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Booking number")]
        public string BookingNumber { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngày")]
        public DateTimeOffset? Date { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn issue by")]
        public int IssueById { get; set; }
        public string IssueByName { get; set; }



    }
}
