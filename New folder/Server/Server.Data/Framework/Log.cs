using System;
using System.ComponentModel.DataAnnotations.Schema;
using Falcon.Web.Core.Data;

namespace Vino.Server.Data.Framework
{
    public class Log : BaseEntity
    {
        /// <summary>
        /// Gets or sets the log level identifier
        /// </summary>
        public LogLevel LogLevel { get; set; }

        /// <summary>
        /// Gets or sets the short message
        /// </summary>
        public string ShortMessage { get; set; }

        /// <summary>
        /// Gets or sets the full exception
        /// </summary>
        public string FullMessage { get; set; }
        public string Context { get; set; }

        /// <summary>
        /// Gets or sets the date and time of instance creation
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }
    }
}

