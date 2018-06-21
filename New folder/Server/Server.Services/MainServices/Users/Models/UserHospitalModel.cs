namespace Vino.Server.Services.MainServices.Users.Models
{
    public class UserHospitalModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string Role { get; set; }

        public bool ContinueEditing { get; set; }
    }
}
