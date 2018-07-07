using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vino.Server.Services.MainServices.BaseService;
using Vino.Server.Services.MainServices.CRM.Port.Model;
using Vino.Server.Services.MainServices.CRM.Topic.Model;

namespace Vino.Server.Services.MainServices.CRM.Topic
{
    public interface ITopicService : IGenericRepository<Data.CRM.Topic, TopicModel, TopicModel>
    {
    }
}
