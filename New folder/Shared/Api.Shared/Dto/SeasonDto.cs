using System;

namespace Vino.Shared.Dto
{
    public class SeasonDto:BaseDto
    {
        public DateTimeOffset StartDt { get; set; }
        public DateTimeOffset? EstimatedEndDt { get; set; }
        public string Seed { get; set; }
        public int PlaceId { get; set; }
        /// <summary>
        /// Data time stamp cua nhat ky
        /// </summary>
        public DateTimeOffset DataUpdatedAt { get; set; }
       
    }

}
