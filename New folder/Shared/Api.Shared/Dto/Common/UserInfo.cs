using System;
using System.Collections.Generic;

namespace Vino.Shared.Dto.Common
{
    public class UserInfo
    {
        public string Name { get; set; }
        public string Avatar { get; set; }
        /// <summary>
        /// Membership expired date
        /// </summary>
        public DateTimeOffset ExpiredAt { get; set; }
        /// <summary>
        /// roles, rights
        /// </summary>
        public List<string> Claims { get; set; }
    }
}