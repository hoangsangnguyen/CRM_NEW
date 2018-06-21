namespace Vino.Server.Services.MainServices.Users
{
    public class SearchUserRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        /// <summary>
        /// check UserHospital
        /// </summary>
        public int HospitalId { get; set; }
    }
}
