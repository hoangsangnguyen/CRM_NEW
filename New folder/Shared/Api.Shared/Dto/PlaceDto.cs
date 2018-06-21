namespace Vino.Shared.Dto
{
    public class PlaceDto : BaseDto
    {
       
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
        public int OwnerId { get; set; }
    }
}