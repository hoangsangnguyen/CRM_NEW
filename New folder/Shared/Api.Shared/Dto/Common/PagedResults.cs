using System;
using System.Collections.Generic;
using System.Text;

namespace Vino.Shared.Dto.Common
{
    public class PagedResults<T>
    {
        /// <summary>
        /// The total number of filtered records.
        /// </summary>
        public int TotalNumberOfFilteredRecords { get; set; }

        /// <summary>
        /// The total number of records available.
        /// </summary>
        public int TotalNumberOfRecords { get; set; }

        /// <summary>
        /// The records this page represents.
        /// </summary>
        public IEnumerable<T> Results { get; set; }
    }
}
