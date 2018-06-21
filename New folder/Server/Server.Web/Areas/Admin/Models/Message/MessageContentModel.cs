using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vino.Server.Web.Areas.Admin.Models.Message
{
    public class MessageContentModel
    {
        public MessageContentModel()
        {
            SendNow = true;
        }
        /// <summary>
        /// guid
        /// </summary>
        public string Id { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        public string Body { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public bool SendNow { get; set; }
        public string SendDate { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public bool ContinueEditing { get; set; }
    }
}