using System;
using System.Collections.Generic;
using System.Text;

namespace Vino.Shared.Dto
{
    public class MobileDeviceDto : BaseDto
    {
        public string Uuid { get; set; }
        public string App { get; set; }
        public string PhoneOs { get; set; }
        public string DeviceToken { get; set; }
    }
}