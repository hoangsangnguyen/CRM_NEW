using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Web.Core.Helpers;
using Falcon.Web.Mvc.PageList;
using Vino.Server.Data.CRM;
using Vino.Server.Services.Database;
using Vino.Server.Services.MainServices.BaseService;
using Vino.Server.Services.MainServices.CRM.Contact;
using Vino.Server.Services.MainServices.CRM.Contact.Models;
using Vino.Server.Services.MainServices.CRM.Port.Model;
using SearchingRequest = Vino.Server.Services.MainServices.CRM.Port.Model.SearchingRequest;

namespace Vino.Server.Services.MainServices.CRM.Port
{
    public class PortService : GenericRepository<Data.CRM.Port, PortModel, PortModel>, IPortService
    {
        private readonly DataContext _context;

        public PortService(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IPageList<PortModel>> SearchModels(SearchingRequest request)
        {
            var query = _context.Ports.AsNoTracking().Where(w => !w.Deleted);

            if (!string.IsNullOrEmpty(request.PortName))
                query = query.Where(w => w.PortName.ToLower().Contains(request.PortName.ToLower()));

            if (!string.IsNullOrEmpty(request.PortCode))
                query = query.Where(w => w.PortCode.ToLower().Contains(request.PortCode.ToLower()));

            if (request.NationalityId.HasValue && request.NationalityId > 0)
                query = query.Where(w => w.NationalityId == request.NationalityId);

            if (request.ModeId.HasValue && request.ModeId > 0)
                query = query.Where(w => w.ModeId == request.ModeId);

            query = query.OrderBy(x => x.PortCode);
            var receives = await query.Skip(request.Page * request.PageSize)
                .Take(request.PageSize).ToListAsync();
            var models = receives.MapTo<PortModel>();
            return new PageList<PortModel>(models, request.Page, request.PageSize, query.Count());
        }
    }
}
