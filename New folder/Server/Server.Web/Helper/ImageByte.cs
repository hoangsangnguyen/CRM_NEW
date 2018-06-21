using System.IO;
using System.Web;
using Vino.Server.Web.Areas.Admin.Models.Common;

namespace Vino.Server.Web.Helper
{
    public static class ImageByte
    {
        public static ImageByteModel GetImageByte(HttpPostedFileBase file)
        {
            if (file == null) return null;

            Stream stream = file.InputStream;
            var fileName = Path.GetFileName(file.FileName);
            var contentType = file.ContentType;

            var fileBinary = new byte[stream.Length];
            stream.Read(fileBinary, 0, fileBinary.Length);
            return new ImageByteModel()
            {
                FileName = fileName,
                Image = fileBinary
            };
        }
    }
}