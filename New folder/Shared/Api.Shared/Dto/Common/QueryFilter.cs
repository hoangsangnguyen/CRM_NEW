using System;
using System.Collections.Generic;
using System.Text;

namespace Vino.Shared.Dto.Common
{
    /// <summary>
    /// common filter parameters for requests
    /// </summary>
    public class QueryFilter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset From { get; set; }
        public DateTimeOffset To { get; set; }
    }
}
