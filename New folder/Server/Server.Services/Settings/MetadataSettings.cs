using System;
using Falcon.Web.Core.Settings;
using Vino.Shared.Dto;

namespace Vino.Server.Services.Settings
{
    public class MetadataSettings : ISettings
    {
        //core
        public DateTimeOffset LastUpdatedLookup { get; set; }
		//
	    public string UploadingFolder { get; set; }
	    /// <summary>
	    /// 1 - 100%, default value 25% use for <see cref="ImageResizeModes.ByPercent"/>
	    /// </summary>
	    public int PhotoSizePercent { get; set; }
	    /// <summary>
	    /// Default value 1024px, use for <see cref="ImageResizeModes.ByMaxWidth"/> 
	    /// </summary>
	    public int PhoToMaxWidth { get; set; }
	    public ImageResizeModes ResizeMode { get; set; }
		//So ngay gan nhat de lay tin
	    public int NumberOfDayGetNewsLatest { get; set; }
	}
}