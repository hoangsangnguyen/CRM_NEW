using System;
using System.Collections.Generic;
using System.Text;

namespace Vino.Shared.Dto
{
	public class UploadingFileRequest
    {
		//Kq tra ve
	    public bool IsSuccess { get; set; }
	    public int ImageId { get; set; }
	    public string Url { get; set; }
	    public string ErrorMessage { get; set; }
		//
		public string Mime { get; set; }
	    public byte[] Content { get; set; }
	}
}
