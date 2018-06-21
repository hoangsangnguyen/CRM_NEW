using System;
using System.Collections.Generic;
using System.Text;

namespace Vino.Shared.Dto
{
    public class QuestionItem
    {
	    public int Id { get; set; }
	    public int EmployeeId { get; set; }
	    public string App { get; set; }
	    public string Topic { get; set; }
	    public string Title { get; set; }
	    public string Content { get; set; }
	    public DateTimeOffset CreatedAt { get; set; }
	    public bool HasAnswer { get; set; }
	    public string AnsweredBy { get; set; }
		public string Answer { get; set; }
	    public DateTimeOffset AnsweredAt { get; set; }
		/// <summary>
		/// DS hinh cach nhau dau ;
		/// </summary>
	    public string ImageIds { get; set; }
	    public bool Published { get; set; }
	}
}
