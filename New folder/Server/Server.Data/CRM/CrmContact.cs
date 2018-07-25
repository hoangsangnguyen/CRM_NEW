using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Web.Core.Auth;
using Falcon.Web.Core.Data;

namespace Vino.Server.Data.CRM
{
    public class CrmContact : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string ContactId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string EnglishName { get; set; }

        public int PositionId { get; set; }

        public string HomeAddress { get; set; }

        public string CellPhone { get; set; }

        public string HomePhone { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string CompanyExt { get; set; }

        public string Signature { get; set; }

        public int DepartmentId { get; set; }

        public DateTimeOffset Birthday { get; set; }

        public bool MarriageStatus { get; set; }

        public string SpouseName { get; set; }

        public DateTimeOffset SpouseBirthday { get; set; }

        public string FieldInterested { get; set; }

        public string UpdateName { get; set; }

        public DateTimeOffset? UpdateAt { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public int CreatorId { get; set; }
        public virtual User Creator { get; set; }

    }
}
