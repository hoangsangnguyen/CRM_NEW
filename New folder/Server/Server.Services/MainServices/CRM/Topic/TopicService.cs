using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vino.Server.Services.Database;
using Vino.Server.Services.MainServices.BaseService;
using Vino.Server.Services.MainServices.CRM.Port;
using Vino.Server.Services.MainServices.CRM.Port.Model;
using Vino.Server.Services.MainServices.CRM.Topic.Model;

namespace Vino.Server.Services.MainServices.CRM.Topic
{
    public class TopicService : GenericRepository<Data.CRM.Topic, TopicModel, TopicModel>, ITopicService
    {
        private DataContext _context;

        public TopicService(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
