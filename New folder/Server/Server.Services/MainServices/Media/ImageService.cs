using System;
using System.IO;
using System.Threading.Tasks;
using System.Web.Hosting;
using Falcon.Web.Core.Helpers;
using Vino.Server.Data.Common;
using Vino.Server.Services.Database;
using Vino.Server.Services.MainServices.Media.Models;
using System.Drawing;
using Falcon.Web.Core.Log;
using Falcon.Web.Core.Settings;
using ImageResizer;
using Vino.Server.Services.Settings;

namespace Vino.Server.Services.MainServices.Media
{
    public class ImageService
    {
        const string SubPath = "\\Upload\\Image";

        private readonly DataContext _dataContext;
        private readonly ILogger _logger;
        private readonly ISettingService _settingService;
        public ImageService(DataContext dataContext, ILogger logger, ISettingService settingService)
        {
            _dataContext = dataContext;
            _logger = logger;
            _settingService = settingService;
        }

        public string GetPathById(int id)
        {
            return _dataContext.ImageRecords.Find(id)?.RelativePath ?? string.Empty;
        }

        public ImageModel GetById(int id)
        {
            var image = _dataContext.ImageRecords.Find(id);
            if (image == null || image.Deleted) return null;
            return image.MapTo<ImageModel>();
        }


        public async Task<ImageResponse> InsertImage(byte[] pictureBinary, string filename)
        {
            if (!Directory.Exists(LocalMapPath(SubPath)))
                Directory.CreateDirectory(LocalMapPath(SubPath));

            if (pictureBinary == null || pictureBinary.Length < 0) return new ImageResponse() { Message = "File empty" };
            if (string.IsNullOrEmpty(filename)) return new ImageResponse() { Message = "File" };
            filename = Path.GetFileName(filename);

            if (!CheckImageFileType(filename))
                return new ImageResponse() { Message = "Image file type: .gif, .jpg, .jpeg, .png" };

            var localImageFilePath = GetLocalImageFilePath(filename);
            File.WriteAllBytes(localImageFilePath, pictureBinary);

            var imageName = Path.GetFileName(localImageFilePath);
           
            var relativePath = Path.Combine(SubPath, imageName);
            var image = new ImageRecord()
            {
                AbsolutePath = GenAbsolutePath(relativePath),
                RelativePath = relativePath,
                IsUsed = true,
                IsExternal = false,
                CreatedAt = DateTimeOffset.Now,
                FileName = imageName,

            };
            _dataContext.ImageRecords.Add(image);
            await _dataContext.SaveChangesAsync();

            return new ImageResponse()
            {
                IsOk = true,
                Message = "Success",
                Image = image.MapTo<ImageModel>()
            };
        }

        public string GenAbsolutePath(string relativePath)
        {
            var systemSettings = _settingService.LoadSetting<SystemSettings>();
            var path = systemSettings.Domain + relativePath.Replace("\\", "/");
            path = path.Replace("//", "/");
            return path;
        }
        public async Task DeleteImage(int id)
        {
            var image = await _dataContext.ImageRecords.FindAsync(id);
            if (image == null || image.Deleted) return;

            image.Deleted = true;
            await _dataContext.SaveChangesAsync();
            var imageFilePath = image.RelativePath;
            if (string.IsNullOrEmpty(imageFilePath)) return;
            var path = LocalMapPath(imageFilePath);
            if (!File.Exists(path)) return;

            File.Delete(path);
        }

        public bool CheckImageFileType(string fileName)
        {
            var ext = Path.GetExtension(fileName);
            if (ext == null) return false;
            switch (ext.ToLower())
            {
                case ".gif":
                    return true;
                case ".jpg":
                    return true;
                case ".jpeg":
                    return true;
                case ".png":
                    return true;
                default:
                    return false;
            }
        }

        public string GetLocalImageFilePath(string fileName)
        {
            var imageName = $"img_{DateTime.Now.Ticks}{Path.GetFileName(fileName)}";
            var filePath = Path.Combine(LocalMapPath(SubPath), imageName);
            return filePath;
        }

        private string LocalMapPath(string path)
        {
            if (HostingEnvironment.IsHosted)
            {
                //hosted
                return HostingEnvironment.MapPath(path);
            }

            //not hosted. For example, run in unit tests
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            path = path.Replace("~/", "").TrimStart('/').Replace('/', '\\');
            return Path.Combine(baseDirectory, path);
        }

        public ImageResponse SaveThumbnail(int id)
        {
            var image = _dataContext.ImageRecords.Find(id);
            if (image == null || image.Deleted) return new ImageResponse()
            {
                Message = "Image not found"
            };

            var filePath = Path.Combine(LocalMapPath(SubPath), image.FileName);
           
            if (!File.Exists(filePath))
                return new ImageResponse()
                {
                    Message = "Image not found"
                };
            
            var fileImage  =  File.ReadAllBytes(filePath);
            var thumbnailName = ThumbnailName(image.FileName);
            var thumbnailPath = Path.Combine(LocalMapPath(SubPath), thumbnailName);
            using (var stream = new MemoryStream(fileImage))
            {
                Bitmap b = null;
                try
                {
                    //try-catch to ensure that picture binary is really OK. Otherwise, we can get "Parameter is not valid" exception if binary is corrupted for some reasons
                    b = new Bitmap(stream);
                }
                catch (ArgumentException exc)
                {
                    _logger.Error($"Error generating picture thumb. ID={image.Id}", exc.Message);
                }
                if (b == null)
                {
                    //bitmap could not be loaded for some reasons
                    _logger.Error("bitmap could not be loaded for some reasons", "bitmap could not be loaded for some reasons");
                    throw new ArgumentNullException(nameof(b));
                }
                using (var destStream = new MemoryStream())
                {
                    var mediaSettings = _settingService.LoadSetting<MediaSettings>();
                    var newSize = CalculateDimensions(b.Size, mediaSettings.TargetResize);
                    ImageBuilder.Current.Build(b, destStream, new ResizeSettings
                    {
                        Width = newSize.Width,
                        Height = newSize.Height,
                        Scale = ScaleMode.Both,
                        Quality = 80
                    });
                    var destBinary = destStream.ToArray();
                    File.WriteAllBytes(thumbnailPath, destBinary);
                    
                    b.Dispose();
                }
            }
          
            var relativePath = Path.Combine(SubPath, thumbnailName);
            var thumb = new ImageRecord()
            {
                AbsolutePath = GenAbsolutePath(relativePath),
                RelativePath = relativePath,
                IsUsed = true,
                IsExternal = false,
                CreatedAt = DateTimeOffset.Now,
                FileName = thumbnailName,
            };
            _dataContext.ImageRecords.Add(thumb);
            _dataContext.SaveChanges();
            return new ImageResponse()
            {
                IsOk = true,
                Message = "Success",
                Image = thumb.MapTo<ImageModel>()
            };
        }

        public string ThumbnailName(string nameImage)
        {
            return $"thumb_{nameImage}";
        }

        public Size CalculateDimensions(Size originalSize, int targetSize, bool ensureSizePositive = true)
        {
            float width, height;
            if (originalSize.Height > originalSize.Width)
            {
                // portrait
                width = originalSize.Width * (targetSize / (float)originalSize.Height);
                height = targetSize;
            }
            else
            {
                // landscape or square
                width = targetSize;
                height = originalSize.Height * (targetSize / (float)originalSize.Width);
            }
            if (ensureSizePositive)
            {
                if (width < 1)
                    width = 1;
                if (height < 1)
                    height = 1;
            }
            return new Size((int)Math.Round(width), (int)Math.Round(height));
        }

        public async Task ResizeImage(int imageId, int size = 0)
        {
            var image = await _dataContext.ImageRecords.FindAsync(imageId);
            if (image == null || image.Deleted) return;
            if (size <= 0)
            {
                var mediaSettings = _settingService.LoadSetting<MediaSettings>();
                size = mediaSettings.TargetResize;
            }
            var filePath = Path.Combine(LocalMapPath(SubPath), image.FileName);
            var fileImage = File.ReadAllBytes(filePath);
            using (var stream = new MemoryStream(fileImage))
            {
                Bitmap b = null;
                try
                {
                    //try-catch to ensure that picture binary is really OK. Otherwise, we can get "Parameter is not valid" exception if binary is corrupted for some reasons
                    b = new Bitmap(stream);
                }
                catch (ArgumentException exc)
                {
                    _logger.Error($"Error generating picture thumb. ID={image.Id}", exc.Message);
                }
                if (b == null)
                {
                    //bitmap could not be loaded for some reasons
                    _logger.Error("bitmap could not be loaded for some reasons", "bitmap could not be loaded for some reasons");
                    throw new ArgumentNullException(nameof(b));
                }
                if (b.Size.Width == size)
                    return;
                
                using (var destStream = new MemoryStream())
                {
                    var newSize = CalculateDimensions(b.Size, size);
                    ImageBuilder.Current.Build(b, destStream, new ResizeSettings
                    {
                        Width = newSize.Width,
                        Height = newSize.Height,
                        Scale = ScaleMode.Both,
                        Quality = 80
                    });
                    var destBinary = destStream.ToArray();
                    File.WriteAllBytes(filePath, destBinary);

                    b.Dispose();
                }
            }
        }
    }
}
