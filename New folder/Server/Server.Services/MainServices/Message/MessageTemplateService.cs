using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Falcon.Web.Core.Helpers;
using Vino.Server.Data.Common;
using Vino.Server.Services.Database;
using Vino.Server.Services.MainServices.Message.Models;

namespace Vino.Server.Services.MainServices.Message
{
    public class MessageTemplateService
    {
        private readonly DataContext _dataContext;

        public MessageTemplateService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Delete a message template
        /// </summary>
        /// <param name="messagetemplateId">Message template Id</param>
        public async Task DeleteMessageTemplate(int messagetemplateId)
        {
            if (messagetemplateId == 0)
                return;

            var messageTemplate = _dataContext.MessageTemplates.Find(messagetemplateId);
            if (messageTemplate == null || messageTemplate.Deleted)
                return;

            messageTemplate.Deleted = true;

            await _dataContext.SaveChangesAsync();
        }

        /// <summary>
        /// Inserts a message template
        /// </summary>
        /// <param name="messageTemplateModel">Message template Model</param>
        public virtual async Task InsertMessageTemplate(MessageTemplateModel messageTemplateModel)
        {
            if (messageTemplateModel == null)
                throw new ArgumentNullException(nameof(messageTemplateModel));

            var messageTemplate = messageTemplateModel.MapTo<MessageTemplate>();
            _dataContext.MessageTemplates.Add(messageTemplate);
            await _dataContext.SaveChangesAsync();
            messageTemplateModel.Id = messageTemplate.Id;   
        }

        /// <summary>
        /// Updates a message template
        /// </summary>
        /// <param name="messageTemplateModel">Message template Model</param>
        public virtual async Task UpdateMessageTemplate(MessageTemplateModel messageTemplateModel)
        {
            if (messageTemplateModel == null)
                throw new ArgumentNullException(nameof(messageTemplateModel));

            var messageTemplate = _dataContext.MessageTemplates.Find(messageTemplateModel.Id);
            if (messageTemplate == null || messageTemplate.Deleted)
                return;
            messageTemplateModel.MapTo(messageTemplate);
            await _dataContext.SaveChangesAsync();
        }

        /// <summary>
        /// Gets a message template
        /// </summary>
        /// <param name="messageTemplateId">Message template identifier</param>
        /// <returns>Message template</returns>
        public virtual MessageTemplate GetMessageTemplateById(int messageTemplateId)
        {
            if (messageTemplateId == 0)
                return null;

            var messageTemplate = _dataContext.MessageTemplates.Find(messageTemplateId);
            if (messageTemplate == null || messageTemplate.Deleted)
                return null;
            return messageTemplate;

        }

        /// <summary>
        /// Gets a message template
        /// </summary>
        /// <param name="messageTemplateName">Message template name</param>
        /// <returns>Message template</returns>
        public virtual MessageTemplate GetMessageTemplateByName(string messageTemplateName)
        {
            if (string.IsNullOrWhiteSpace(messageTemplateName))
                throw new ArgumentException("messageTemplateName");

            var messageTemplate = _dataContext.MessageTemplates.Where(d => d.Name == messageTemplateName && !d.Deleted);
            messageTemplate = messageTemplate.OrderBy(d => d.Id);
            return messageTemplate.FirstOrDefault();
        }

        /// <summary>
        /// Gets all message templates
        /// </summary>
        /// <returns>Message template list</returns>
        public virtual IList<MessageTemplate> GetAllMessageTemplates()
        {
            var messageTemplate = _dataContext.MessageTemplates.Where(d => !d.Deleted).OrderBy(d => d.Name);
            return messageTemplate.ToList();
        }

    }
}
