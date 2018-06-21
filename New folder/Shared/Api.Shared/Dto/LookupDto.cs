using System;
using System.Collections.Generic;
using System.Text;
using Vino.Shared.Constants;
using Vino.Shared.Constants.Common;

namespace Vino.Shared.Dto
{
    public class LookupDto
    {
	    public int Id { get; set; }
	    public LookupTypes Type { get; set; }
	    /// <summary>
	    /// Dung lam khoa de so sanh member trong 1 type, thay cho Id
	    /// </summary>
	    public string Code { get; set; }
	    public int Order { get; set; }

	    public string Title { get; set; }
	}
}
