﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using Falcon.Web.Core.Helpers;

namespace Vino.Server.Web.Areas.Admin.Controllers
{
    public class JbimagesController :BaseController 
    {

        [NonAction]
        protected virtual IList<string> GetAllowedFileTypes()
        {
            return new List<string> { ".gif", ".jpg", ".jpeg", ".png", ".bmp" };
        }

        [HttpPost]
        public virtual ActionResult Upload()
        {
            //if (!_permissionService.Authorize(StandardPermissionProvider.HtmlEditorManagePictures))
            //{
            //    ViewData["resultCode"] = "failed";
            //    ViewData["result"] = "No access to this functionality";
            //    return View();
            //}

            if (Request.Files.Count == 0)
                throw new Exception("No file uploaded");

            var uploadFile = Request.Files[0];
            if (uploadFile == null)
            {
                ViewData["resultCode"] = "failed";
                ViewData["result"] = "No file name provided";
                return View();
            }

            var fileName = Path.GetFileName(uploadFile.FileName);
            if (String.IsNullOrEmpty(fileName))
            {
                ViewData["resultCode"] = "failed";
                ViewData["result"] = "No file name provided";
                return View();
            }

            var directory = "~/content/images/uploaded/";
            var filePath = Path.Combine(Server.MapPath(directory), fileName);

            var fileExtension = Path.GetExtension(filePath);
            if (!GetAllowedFileTypes().Contains(fileExtension))
            {
                ViewData["resultCode"] = "failed";
                ViewData["result"] = string.Format("Files with {0} extension cannot be uploaded", fileExtension);
                return View();
            }

            uploadFile.SaveAs(filePath);

            ViewData["resultCode"] = "success";
            ViewData["result"] = "success";
            ViewData["filename"] = this.Url.Content(string.Format("{0}{1}", directory, fileName));
            return View();
        }
    }
}