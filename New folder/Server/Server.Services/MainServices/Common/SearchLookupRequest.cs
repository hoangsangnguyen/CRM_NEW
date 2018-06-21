namespace Vino.Server.Services.MainServices.Common
{
    public class SearchLookupRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int? LookupType { get; set; }
    }
}
