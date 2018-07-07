using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Falcon.Web.Core.Caching;
using Falcon.Web.Core.Helpers;
using Falcon.Web.Mvc.PageList;
using Vino.Server.Data.Common;
using Vino.Server.Services.Database;
using Vino.Server.Services.Helper;
using Vino.Server.Services.MainServices.Common.Models;
using Vino.Shared.Constants;
using Vino.Shared.Constants.Common;
using Vino.Shared.Dto;

namespace Vino.Server.Services.MainServices.Common
{
    public class LookupService
    {
        private const string LookupAllKey = "LookupService.All";
        private const string LookupByType = "LookupService.Type.{0}";
        private const string AllPlaceKey = "LookupService.AllPlace";
        private readonly ICacheManager _cacheManager;
        private readonly DataContext _dataContext;
        public LookupService(ICacheManager cacheManager
            , DataContext masterContext)
        {
            _cacheManager = cacheManager;
            _dataContext = masterContext;
        }
        public void ResetLookupCache()
        {
            _cacheManager.Remove(LookupAllKey);
            _cacheManager.RemoveByPattern(LookupByType);
        }
        public void ResetPlaceCache()
        {
            _cacheManager.Remove(AllPlaceKey);
        }
		public async Task<List<LookupDto>> GetAlLookups()
		{
			try
			{
				return await _cacheManager.GetAsync(LookupAllKey, async () =>
				{
					return (await _dataContext.Lookups.AsNoTracking()
						.Where(x => !x.Deleted)
						.ToListAsync()).MapTo<LookupDto>().ToList();
				});
			}
			catch (Exception ex)
			{
				return new List<LookupDto>();
			}
		}

		//public Task<List<LookupDto>> GetLookup(LookupTypes type)
		//{
		//    using (var scope = TransactionUtils.CreateTransactionScope())
		//    {
		//        return _cacheManager.GetAsync(string.Format(LookupByType, (int)type), async () =>
		//        {
		//            return (await _dataContext.Lookups.AsNoTracking()
		//                .Where(x => !x.Deleted && x.Type == type)
		//                .ToListAsync()).MapTo<LookupDto>().ToList();
		//        });
		//    }
		//}

		#region LookUp CURD

		public async Task<IPageList<LookupModel>> SearchLookup(SearchLookupRequest request)
        {
            var query = _dataContext.Lookups.AsNoTracking().Where(d => !d.Deleted);

            if (!string.IsNullOrEmpty(request.Title))
            {
                query = query.Where(d => d.Title.Contains(request.Title));
            }

            if (!string.IsNullOrEmpty(request.Code))
            {
                query = query.Where(d => d.Code.Contains(request.Code));
            }
            if (request.LookupType.HasValue)
                query = query.Where(d => d.Type == (LookupTypes) request.LookupType);

            query = query.OrderBy(d => d.Type).ThenBy(d => d.Code);
            
            var lookups = await query.Skip(request.Page * request.PageSize).Take(request.PageSize).ToListAsync();
            var pagelistLookupModel = new PageList<LookupModel>(lookups.MapTo<LookupModel>(), request.Page, request.PageSize, query.Count());
            return pagelistLookupModel;
        }

        public LookupModel GetLookupById(int id)
        {
            var lookup =  _dataContext.Lookups.Find(id);
            if (lookup == null || lookup.Deleted)
                return null;
            return lookup.MapTo<LookupModel>();
        }

        public async Task InsertLookup(LookupModel model)
        {
            var lookup = new Lookup()
            {
                Code = CreateSeoName(model.Code),
                Title = model.Title,
                Order = model.Order,
                Type = model.Type,
                App = model.App
            };
            _dataContext.Lookups.Add(lookup);
            await _dataContext.SaveChangesAsync();
            model.Id = lookup.Id;
        }

        public string CreateSeoName(string name, string additionString = "")
        {
            if (name == null)
                return "";
            var seoname = name.ConvertToUnSign();

            seoname = seoname.CreateSlug();

            if (string.IsNullOrEmpty(additionString)) return seoname;

            seoname += "-" + additionString;

            return seoname;

        }

        public async Task UpdateLookup(LookupModel model)
        {
            var lookupUpdate = _dataContext.Lookups.Find(model.Id);
            if (lookupUpdate == null || lookupUpdate.Deleted) return;

            lookupUpdate.Title = model.Title;
            lookupUpdate.Order = model.Order;
            lookupUpdate.Code = CreateSeoName(model.Code);
            lookupUpdate.App = model.App;
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteLookup(int id)
        {
            var lookup = _dataContext.Lookups.Find(id);
            if (lookup == null || lookup.Deleted) return;
            lookup.Deleted = true;
            await _dataContext.SaveChangesAsync();
        }
        public List<NameValueModel> GetLookupTypes()
        {
            var listLookupType = new List<NameValueModel>();
            foreach (LookupTypes type in Enum.GetValues(typeof(LookupTypes)))
            {
                listLookupType.Add(new NameValueModel()
                {
                    Name = type.ToString(),
                    Value = ((int)type).ToString()
                });
            }
            return listLookupType;
        }

        public List<LookupModel> GetLookupByLookupType(LookupTypes lookupTypes)
        {
            return _dataContext.Lookups.Where(d => d.Type == lookupTypes && !d.Deleted).ProjectTo<LookupModel>().ToList();
        }

	    public List<LookupModel> GetLookupByLookupCodes(List<string> lookupCodes)
	    {
		    var lookup = _dataContext.Lookups.Where(d => lookupCodes.Contains(d.Code) && !d.Deleted).ToList();
		    return lookup.MapTo<LookupModel>();
		}
		public LookupModel GetLookupByCode(LookupTypes type,string code)
		{
			return _dataContext.Lookups.FirstOrDefault(f => f.Type == type && f.Code == code).MapTo<LookupModel>();
		}
        #endregion
    }
}