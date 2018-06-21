using System;
using System.Collections.Generic;
using System.Text;

namespace Vino.Shared.Dto.Common
{
    public class FilterDto
    {
        public DateTimeOffset FromDate { get; set; }
        public DateTimeOffset ToDate { get; set; }
    }
}
