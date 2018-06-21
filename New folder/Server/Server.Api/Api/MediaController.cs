using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vino.Server.Services.ApiServices.Core;
using Vino.Shared.Dto;

namespace Vino.Server.Api.Api
{
	[RoutePrefix("api/media")]
	public class MediaController : BaseApiController
	{
		private readonly ImageApiService _imageService;
		public MediaController(ImageApiService imageService)
		{
			_imageService = imageService;
		}

		[HttpPost]
		public async Task<UploadingResponse> UploadNewImage(UploadingFileRequest request)
		{
			var img = await _imageService.SaveNewPhoto(Url.Content("~/"), request.Content, request.Mime);
			return new UploadingResponse()
			{
				ImageId = img.Id,
				IsSuccess = true,
				Url = Url.Content(img.RelativePath)
			};
		}
	}
}