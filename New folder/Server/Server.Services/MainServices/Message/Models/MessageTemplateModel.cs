namespace Vino.Server.Services.MainServices.Message.Models
{
    public class MessageTemplateModel
    {
        public MessageTemplateModel()
        {
            IsActive = true;
        }

        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the BCC Email addresses
        /// </summary>
        public string BccEmailAddresses { get; set; }

        /// <summary>
        /// Gets or sets the subject
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the body
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the template is active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the delay before sending message
        /// </summary>
        public int? DelayBeforeSend { get; set; }
        
        /// <summary>
        /// Gets or sets the download identifier of attached file
        /// </summary>
        public int AttachedDownloadId { get; set; }

        ///// <summary>
        ///// Gets or sets the used email account identifier
        ///// </summary>
        //public int EmailAccountId { get; set; }
        
        /// <summary>
        /// Gets or sets the period of message delay
        /// </summary>
        public int DelayPeriod { get; set; }

        //public bool SendImmediately { get; set; }
        public bool HasAttachedDownload { get; set; }
        public bool ContinueEditing { get; set; }
    }
}
