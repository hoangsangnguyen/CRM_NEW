using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vino.Server.Services.MainServices.System.Email.Models
{
	public class EmailModel
	{
		public string Body { get; set; }
		public string From { get; set; }
		public string FromName { get; set; }
		public string To { get; set; }
		public string Subject { get; set; }
		public List<string> CC { get; set; }
		public List<string> Bcc { get; set; }
	}
}
