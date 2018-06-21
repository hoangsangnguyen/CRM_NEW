using System;
using System.Collections.Generic;
using System.Text;

namespace Vino.Shared.Dto
{
	public class ActionDto
    {
	    public ActionDto()
	    {
		    Factors=new List<FactorDto>();
		}
	    public string Name { get; set; }
	    public string Instruction { get; set; }
		public bool Positive { get; set; }
	    public List<FactorDto> Factors { get; set; }
	}
}
