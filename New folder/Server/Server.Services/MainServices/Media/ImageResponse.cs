using Vino.Server.Services.MainServices.Media.Models;

namespace Vino.Server.Services.MainServices.Media
{
    public class ImageResponse
    {
        public bool IsOk { get; set; }
        public string Message { get; set; }

        public ImageModel Image { get; set; }
    }
}
