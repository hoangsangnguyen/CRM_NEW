﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vino.Server.Services.MainServices.System.Email.Models
{
	public class QueueEmailModel
	{
		public int Id { get; set; }
		/// <summary>
		/// Gets or sets the priority
		/// </summary>
		public int Priority { get; set; }

		/// <summary>
		/// Gets or sets the From property
		/// </summary>
		public string From { get; set; }

		/// <summary>
		/// Gets or sets the FromName property
		/// </summary>
		public string FromName { get; set; }

		/// <summary>
		/// Gets or sets the To property
		/// </summary>
		public string To { get; set; }

		/// <summary>
		/// Gets or sets the ToName property
		/// </summary>
		public string ToName { get; set; }

		/// <summary>
		/// Gets or sets the CC
		/// </summary>
		public string CC { get; set; }

		/// <summary>
		/// Gets or sets the Bcc
		/// </summary>
		public string Bcc { get; set; }

		/// <summary>
		/// Gets or sets the subject
		/// </summary>
		public string Subject { get; set; }

		/// <summary>
		/// Gets or sets the body
		/// </summary>
		public string Body { get; set; }

		/// <summary>
		/// Gets or sets the attachment file path (full file path)
		/// </summary>
		public string AttachmentFilePath { get; set; }

		/// <summary>
		/// Gets or sets the attachment file name. If specified, then this file name will be sent to a recipient. Otherwise, "AttachmentFilePath" name will be used.
		/// </summary>
		public string AttachmentFileName { get; set; }
		/// <summary>
		/// Gets or sets the date and time of item creation in UTC
		/// </summary>
		public DateTime CreatedOnUtc { get; set; }

		/// <summary>
		/// Gets or sets the send tries
		/// </summary>
		public int SentTries { get; set; }

		/// <summary>
		/// Gets or sets the sent date and time
		/// </summary>
		public DateTime? SentOn { get; set; }
	}
}
