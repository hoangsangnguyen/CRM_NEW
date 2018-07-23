using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Falcon.Web.Core.Helpers;
using Vino.Server.Data.Common;
using Vino.Server.Services.Database;
using Vino.Server.Services.MainServices.BaseService;
using Vino.Server.Services.MainServices.CRM.Topic.Model;
using Vino.Server.Services.MainServices.Media;

namespace Vino.Server.Services.MainServices.CRM.Topic
{
    public class TopicService : GenericRepository<Data.CRM.Topic, TopicModel, TopicModel>, ITopicService
    {
        private readonly DataContext _context;
        private readonly ImageService _imageService;

        public TopicService(DataContext context, ImageService imageService) : base(context)
        {
            _context = context;
            _imageService = imageService;
        }

        public async Task<TopicModel> GetTopicByTopicType(string type)
        {
            var topic = await _context.Topics.FirstOrDefaultAsync(x => !x.Deleted
                                                         && x.Type.ToLower().Equals(type.ToLower()));
            var result = topic.MapTo<TopicModel>();
            result.ImagePath = _imageService.GetPathById(result.ImageId.GetValueOrDefault());
            return result;
        }

    }
}
