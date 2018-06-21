using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using Falcon.Web.Core.Helpers;
using Falcon.Web.Core.Settings;
using Vino.Server.Data.Common;
using Vino.Server.Services.Database;
using Vino.Server.Services.Settings;

namespace Vino.Server.Services.ApiServices.Core
{
	public class ImageApiService
	{
		private readonly DataContext _dataContext;
		private readonly ISettingService _settingService;
		public ImageApiService(DataContext dataContext,
			ISettingService settingService)
		{
			_dataContext = dataContext;
			_settingService = settingService;
		}
		/// <summary>
		/// Write byte[] to disk
		/// </summary>
		/// <param name="host">server host</param>
		/// <param name="fileName">file name only. ie. image.jpg</param>
		/// <param name="content"></param>
		/// <param name="path">relative path</param>
		/// <returns>relative url</returns>
		public async Task<ImageRecord> WriteImageFile(string host, string fileName, byte[] content, string path = "")
		{
			var now = DateTime.Now;
			var imageSettings = _settingService.LoadSetting<MetadataSettings>();
			var relPath = "/" + Path.Combine(imageSettings.UploadingFolder,
				              path.IsNullOrEmpty() ? (now.Year.ToString()) + now.Month.ToString() : path).Replace('\\', '/');
			var fullPath = LocalMapPath(relPath);
			Directory.CreateDirectory(fullPath);
			if (File.Exists(Path.Combine(fullPath, fileName)))
			{
				fileName = DateTime.Now.Ticks + fileName;
			}
			//Save file to Image uploading folder
			File.WriteAllBytes(Path.Combine(fullPath, fileName), content);
			var img = new ImageRecord()
			{
				CreatedAt = DateTime.Now,
				FileName = fileName,
				RelativePath = relPath + "/" + fileName,
				IsUsed = true
			};
			img.AbsolutePath = host + img.RelativePath.Substring(host.EndsWith("/") ? 1 : 0);
			_dataContext.ImageRecords.Add(img);
			await _dataContext.SaveChangesAsync();
			return img;
		}
		public async Task<ImageRecord> SaveNewPhoto(string host, byte[] content, string mime, string path = "")
		{
			var img =await InsertImageRecord(host, mime, path);
			await SaveUploadPhoto(img.Id, content, path);
			return img;
		}
		public async Task<ImageRecord> InsertImageRecord(string host, string imageType, string path)
		{
			var now = DateTime.Now;
			var fileName = now.Ticks + "." + imageType;
			var imageSettings = _settingService.LoadSetting<MetadataSettings>();
			var relPath = "/" + Path.Combine(imageSettings.UploadingFolder,
				              path.IsNullOrEmpty() ? (now.Year.ToString()) + now.Month.ToString() : path).Replace('\\', '/');
			var fullPath = LocalMapPath(relPath);
			Directory.CreateDirectory(fullPath);
			if (File.Exists(Path.Combine(fullPath, fileName)))
				fileName = DateTime.Now.Ticks + fileName;
			var img = new ImageRecord()
			{
				CreatedAt = DateTime.Now,
				FileName = fileName,
				RelativePath = relPath + "/" + fileName,
				IsUsed = true
			};
			img.AbsolutePath = host + img.RelativePath.Substring(host.EndsWith("/") ? 1 : 0);
			_dataContext.ImageRecords.Add(img);
			await _dataContext.SaveChangesAsync();
			return img;
		}
		public async Task SaveUploadPhoto(int imageId, byte[] content, string path)
		{
			if (imageId <= 0)
				throw new ArgumentNullException(nameof(imageId));
			if (content == null)
				throw new ArgumentNullException(nameof(content));

			var imageRc =await _dataContext.ImageRecords.FindAsync(imageId);
			if (imageRc==null) return;
			var now = DateTime.Now;
			var imageSettings = _settingService.LoadSetting<MetadataSettings>();
			var relPath = "/" + Path.Combine(imageSettings.UploadingFolder,
				              path.IsNullOrEmpty() ? (now.Year.ToString()) + now.Month.ToString() : path).Replace('\\', '/');
			var fullPath = LocalMapPath(relPath);
			Directory.CreateDirectory(fullPath);
			var fullFileName = Path.Combine(fullPath, imageRc.FileName);
			if (File.Exists(fullFileName))
				File.Delete(fullFileName);
			//Save file to Image uploading folder
			File.WriteAllBytes(fullFileName, content);
		}
		public async Task<string> GetImageUrlById(int id)
		{
			var imageRecord =await _dataContext.ImageRecords.FindAsync(id);
			return imageRecord != null ? imageRecord.IsExternal ? imageRecord.AbsolutePath : imageRecord.RelativePath : "";
		}

		public async Task<ImageRecord> GetImageById(int id)
		{
			var imageRecord = await _dataContext.ImageRecords.FindAsync(id);
			if (imageRecord == null || imageRecord.Deleted)
				return null;
			return imageRecord;
		}

		public async Task UpdateUsed(int newPictureId, int? oldImageId)
		{
			var newImage = await _dataContext.ImageRecords.FindAsync(newPictureId);
			if (newImage!=null)
				newImage.IsUsed = true;
			await _dataContext.SaveChangesAsync();
			if (oldImageId.HasValue)
			{
				var oldImage = await _dataContext.ImageRecords.FindAsync(oldImageId);
				if(oldImage!=null)
					oldImage.IsUsed = false;
				await _dataContext.SaveChangesAsync();
			}
		}
		public async Task DeleteImage(int id)
		{
			var img = await _dataContext.ImageRecords.FindAsync(id);
			if(img==null) return;
			img.Deleted = true;
			img.IsUsed = false;
			await _dataContext.SaveChangesAsync();
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
	}
}
