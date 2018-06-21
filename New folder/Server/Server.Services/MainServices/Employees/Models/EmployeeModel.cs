using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Web.Mvc.HtmlExtensions;

namespace Vino.Server.Services.MainServices.Employees.Models
{
    public class EmployeeModel
    {
        public EmployeeModel()
        {
            ListApp = new List<string>();
        }
        public int Id { get; set; }
        public string DisplayName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên")]
        public string FullName { get; set; }
        public string Address { get; set; }
        public int? ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public int? DistrictId { get; set; }
        public string DistricName { get; set; }
        public string Phone { get; set; }
        public string DayOfBirth { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tài khoản")]
        [NoTrim]
        [RegularExpression(@"^\S*$", ErrorMessage = "Tài khoản không chứ khoảng trắng")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [NoTrim]
        public string Password { get; set; }
        //the avatar
        public int? ImageRecordId { get; set; }
        public string ImageRecordUrl { get; set; }
        //private ICollection<Patient> _patients;

        //public virtual ICollection<Patient> Patients => _patients ?? (_patients = new List<Patient>());

        public string RefreshToken { get; set; }
        /// <summary>
        /// Nhung app dang su dung, lookups
        /// </summary>
        public string Apps { get; set; }
        public List<string> ListApp { get; set; }
        public string CreatedAt { get; set; }
        /// <summary>
        /// Da xac nhan
        /// </summary>
        public bool IsValidated { get; set; }

        /// <summary>
        /// có thiết bị ở bảng MobileDevice
        /// </summary>
        public bool HasDevice { get; set; }


        /// <summary>
        /// Active của user
        /// </summary>
        public bool Active { get; set; }

        public bool ContinueEditing { get; set; }
        public bool ChangePassword { get; set; }
    }
}
