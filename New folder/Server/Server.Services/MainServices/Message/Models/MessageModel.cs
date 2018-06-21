using System;

namespace Vino.Server.Services.MainServices.Message.Models
{
    public class MessageModel
    {
        public MessageModel()
        {
            SendNow = true;
        }
        /// <summary>
        /// guid
        /// </summary>
        public string Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public bool SendNow { get; set; }
        public string SendDate { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public bool ContinueEditing { get; set; }
    }
}
