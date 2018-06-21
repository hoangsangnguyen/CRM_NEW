using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentScheduler;

namespace Vino.Server.Services.MainServices.Tasks
{
	public class TaskRegistry:Registry
	{
		public TaskRegistry()
		{
			//Schedule<ValidateHospitalJob>().ToRunNow().AndEvery(1).Hours();
			Schedule<QueuedMessagesSendJob>().ToRunNow().AndEvery(5).Minutes();
		}
	}
}
