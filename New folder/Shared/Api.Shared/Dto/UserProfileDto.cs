namespace Vino.Shared.Dto
{
    public class UserProfileDto:BaseDto
    {
        public string AuthUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePictureUri { get; set; }
        public int Rating { get; set; }
        public int Ranking { get; set; }
        public double TotalFarm { get; set; }
        public long HighestBenefit { get; set; }
    }
}