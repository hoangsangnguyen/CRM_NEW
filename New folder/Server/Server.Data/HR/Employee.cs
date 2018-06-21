using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Web.Core.Auth;
using Falcon.Web.Core.Data;
using Vino.Server.Data.Common;

namespace Vino.Server.Data.HR
{
    public class Employee : BaseEntity
    {
        public string DisplayName { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public int? ProvinceId { get; set; }
        public virtual Province Province { get; set; }
        public int? DistrictId { get; set; }
        public virtual District District { get; set; }
        public string Phone { get; set; }
        public DateTime? DayOfBirth { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        //the avatar
        public int? ImageRecordId { get; set; }
        public virtual ImageRecord ImageRecord { get; set; }
        //private ICollection<Patient> _patients;

        //public virtual ICollection<Patient> Patients => _patients ?? (_patients = new List<Patient>());

        public string RefreshToken { get; set; }
        /// <summary>
        /// Nhung app dang su dung, lookups
        /// </summary>
        public string Apps { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        /// <summary>
        /// Da xac nhan
        /// </summary>
        public bool IsValidated { get; set; }

    }
}
