using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Falcon.Web.Core.Helpers;
using Vino.Server.Services.Database;
using Vino.Server.Services.MainServices.BaseService;
using Vino.Server.Services.MainServices.CRM.Topic.Model;

namespace Vino.Server.Services.MainServices.CRM.Topic
{
    public class TopicService : GenericRepository<Data.CRM.Topic, TopicModel, TopicModel>, ITopicService
    {
        private readonly DataContext _context;

        public TopicService(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<TopicModel> GetTopicByTopicType(string type)
        {
            var topic = await _context.Topics.FirstOrDefaultAsync(x => !x.Deleted
                                                         && x.Type.ToLower().Equals(type.ToLower()));
            var result = topic.MapTo<TopicModel>();
            return result;
        }
    }
}
