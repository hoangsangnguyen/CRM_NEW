using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Vino.Server.Data.Common;
using Vino.Server.Data.CRM;
using Vino.Server.Services.MainServices.BaseService;

namespace Vino.Server.Services.MainServices.CRM.Customer.Models
{
    public class CrmCustomerModel : BaseDto
    {
        public CrmCustomerModel()
        {
            ContactItems = new List<SelectListItem>();
            LocationItems = new List<SelectListItem>();
            CategoriesItems = new List<SelectListItem>();
        }

        [MaxLength(100)]
        [Index(IsUnique = true)]
        [Required]
        public string CustomerId { get; set; }

        /**
         * Name
         */
        [Required(ErrorMessage = "Vui lòng nhập tên")]
        public string Name { get; set; }
        /**
         * Full English Name
         */
        [Required(ErrorMessage = "Vui lòng nhập English Name")]
        public string FullEngishName { get; set; }

        /**
        * Full Viet Nam Name
        */
        [Required(ErrorMessage = "Vui lòng nhập Full English Name")]
        public string FullVietNamName { get; set; }

        /**
        * Address
        */
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        public string Address { get; set; }

        /**
        * Contact
        */
        [Required(ErrorMessage = "Vui lòng chọn contact")]
        public int? ContactId { get; set; }
        public string ContactName { get; set; }

        /**
       * Work phone
       */
        [Required(ErrorMessage = "Vui lòng nhập work phone")]
        public string WorkPhone { get; set; }

        /**
       * Home Phone
       */
        public string HomePhone { get; set; }

        /**
       * Fax No
       */
        [Required(ErrorMessage = "Vui lòng nhập Fax number")]
        public string FaxNo { get; set; }

        /**
       *Location
       */
        [Required(ErrorMessage = "Vui lòng chọn location")]
        public int? LocationId { get; set; }
        public string LocationName { get; set; }

        /**
        * Taxcode
        */
        [Required] public string Taxcode { get; set; }

        /**
         *Category
         */
        [Required(ErrorMessage = "Vui lòng chọn category")] public int? CategoryId { get; set; }
        public string CategoryName { get; set; }

        /**
         * Website
         */
        public string Website { get; set; }

        /**
         * Email
         */
        [EmailAddress]
        [Required(ErrorMessage = "Vui lòng nhập email")]
        public string Email { get; set; }

        public IList<SelectListItem> ContactItems { get; set; }
        public IList<SelectListItem> LocationItems { get; set; }
        public IList<SelectListItem> CategoriesItems { get; set; }

    }
}
