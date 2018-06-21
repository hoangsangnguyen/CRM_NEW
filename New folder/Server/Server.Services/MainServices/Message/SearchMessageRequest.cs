namespace Vino.Server.Services.MainServices.Message
{
    public class SearchMessageRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string Title { get; set; }
        public string SendDate { get; set; }
    }
}
