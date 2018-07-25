using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Vino.Server.Data.CRM;
using Vino.Server.Services.MainServices.BaseService;

namespace Vino.Server.Services.MainServices.CRM.Contact.Models
{
    public class CrmContactModel : BaseDto
    {
        public CrmContactModel()
        {
        }

        [Required]
        [MaxLength(50)]
        public string ContactId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập First Name")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Last Name")]
        [MaxLength(50)]
        public string LastName { get; set; }

        public string FullName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập English Name")]
        [MaxLength(50)]
        public string EnglishName { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn position")]
        public int? PositionId { get; set; }
        public string PositionName { get; set; }

        public string HomeAddress { get; set; }

        public string CellPhone { get; set; }

        public string HomePhone { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string CompanyExt { get; set; }

        public string Signature { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn department")]
        public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public string Birthday { get; set; }

        public bool MarriageStatus { get; set; }

        public string SpouseName { get; set; }

        public string SpouseBirthday { get; set; }

        public string FieldInterested { get; set; }

        /**
        * Creator
        */
        public string CreatedAt { get; set; }

        public int CreatorId { get; set; }

        /**
         * Update
         */
        public string UpdateName { get; set; }

        public string UpdateAt { get; set; }
    }
}
