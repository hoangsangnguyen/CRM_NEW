using System;
using System.Collections.Generic;
using System.Text;

namespace Vino.Shared.Dto
{
    public class CalendarDto
    {
	    public CalendarDto()
	    {
		    Actions=new List<ActionDto>();
		}
	    public int Day { get; set; }
	    public List<ActionDto> Actions { get; set; }
	}
}
