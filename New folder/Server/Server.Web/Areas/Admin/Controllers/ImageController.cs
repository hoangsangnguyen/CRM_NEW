using System;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using Vino.Server.Services.MainServices.Media;
using Vino.Server.Web.Areas.Admin.Models.RoxyFileman;

namespace Vino.Server.Web.Areas.Admin.Controllers
{
    public class ImageController : BaseController
    {
        private readonly ImageService _imageService;

        public ImageController(ImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost]
        ////do not validate request token (XSRF)
        //[AdminAntiForgery(true)]
        public async Task<ActionResult> AsyncUpload()
        {
            //if (!_permissionService.Authorize(StandardPermissionProvider.UploadPictures))
            //    return Json(new { success = false, error = "You do not have required permissions" }, "text/plain");

            //we process it distinct ways based on a browser
            //find more info here http://stackoverflow.com/questions/4884920/mvc3-valums-ajax-file-upload
            Stream stream = null;
            var fileName = "";
            var contentType = "";
            if (string.IsNullOrEmpty(Request["qqfile"]))
            {
                // IE
                var httpPostedFile = Request.Files[0];
                stream = httpPostedFile?.InputStream ?? throw new ArgumentException("No file uploaded");
                fileName = Path.GetFileName(httpPostedFile.FileName);
                contentType = httpPostedFile.ContentType;
            }
            else
            {
                //Webkit, Mozilla
                stream = Request.InputStream;
                fileName = Request["qqfile"];
            }

            var fileBinary = new byte[stream.Length];
            stream.Read(fileBinary, 0, fileBinary.Length);

            var fileExtension = Path.GetExtension(fileName);
            if (!string.IsNullOrEmpty(fileExtension))
                fileExtension = fileExtension.ToLowerInvariant();
            //contentType is not always available 
            //that's why we manually update it here
            //http://www.sfsu.edu/training/mimetype.htm
            if (String.IsNullOrEmpty(contentType))
            {
                switch (fileExtension)
                {
                    case ".bmp":
                        contentType = MimeTypes.ImageBmp;
                        break;
                    case ".gif":
                        contentType = MimeTypes.ImageGif;
                        break;
                    case ".jpeg":
                    case ".jpg":
                    case ".jpe":
                    case ".jfif":
                    case ".pjpeg":
                    case ".pjp":
                        contentType = MimeTypes.ImageJpeg;
                        break;
                    case ".png":
                        contentType = MimeTypes.ImagePng;
                        break;
                    case ".tiff":
                    case ".tif":
                        contentType = MimeTypes.ImageTiff;
                        break;
                    default:
                        break;
                }
            }

            var image = await _imageService.InsertImage(fileBinary, fileName);
            //when returning JSON the mime-type must be set to text/plain
            //otherwise some browsers will pop-up a "Save As" dialog.
            return Json(new
            {
                success = true,
                pictureId = image.Image.Id,
                imageUrl = image.Image.RelativePath
            },
                MimeTypes.TextPlain);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteImage(int id)
        {
            await _imageService.DeleteImage(id);
            return Content("success");
        }
    }
}