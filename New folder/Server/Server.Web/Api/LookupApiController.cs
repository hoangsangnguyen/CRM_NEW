using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Vino.Server.Services.MainServices.Common;
using Vino.Server.Services.MainServices.Common.Models;
using Vino.Shared.Constants;
using Vino.Shared.Constants.Common;
using Vino.Shared.Constants.Producing;

namespace Vino.Server.Web.Api
{
    public class LookupApiController : BaseApiController
    {
        private readonly LookupService _lookupService;

        public LookupApiController(LookupService lookupService)
        {
            _lookupService = lookupService;
        }

        public List<NameValueModel> GetLookupType()
        {
            return _lookupService.GetLookupTypes();
        }
        public List<NameValueModel> GetAllLookupType()
        {
            var lookupTypes = _lookupService.GetLookupTypes();
            lookupTypes.Insert(0, new NameValueModel()
            {
                Name =  "Tất cả"
            });
            return lookupTypes;
        }

        public List<NameValueModel> GetLookupWithId(LookupTypes type)
        {
            var lookups = _lookupService.GetLookupByLookupType(type).Select(d => new NameValueModel()
            {
                Name = d.Title,
                Value = d.Id.ToString()
            }).ToList();
            lookups.Insert(0, new NameValueModel() { Name = "Tất cả" });
            return lookups;
        }

        public List<NameValueModel> GetLookupWithCode(LookupTypes type)
        {
            var lookups = _lookupService.GetLookupByLookupType(type).Select(d => new NameValueModel()
            {
                Name = d.Title,
                Value = d.Code
            }).ToList();
            lookups.Insert(0, new NameValueModel() { Name = "Tất cả" });
            return lookups;
        }

        public async Task<List<NameValueModel>> GetAllGatewayType()
        {
            var gatewayType = _lookupService.GetLookupByLookupType(LookupTypes.GatewayType).Select(d => new NameValueModel()
            {
                Name = d.Title,
                Value = d.Id.ToString()
            }).ToList();
            gatewayType.Insert(0, new NameValueModel() { Name = "Tất cả" });
            return gatewayType;
        }
        public List<NameValueModel> GetGatewayType()
        {
            var gatewayType = _lookupService.GetLookupByLookupType(LookupTypes.GatewayType).Select(d => new NameValueModel()
            {
                Name = d.Title,
                Value = d.Code.ToString()
            }).ToList();
            gatewayType.Insert(0, new NameValueModel() { Name = "----" });
            return gatewayType;
        }

        public List<NameValueModel> GetApp()
        {
            var apps = _lookupService.GetLookupByLookupType(LookupTypes.App).Select(d => new NameValueModel()
            {
                Name = d.Title,
                Value = d.Id.ToString()
            }).ToList();
            return apps;
        }
        public List<NameValueModel> GetAppCode()
        {
            var apps = _lookupService.GetLookupByLookupType(LookupTypes.App).Select(d => new NameValueModel()
            {
                Name = d.Title,
                Value = d.Code
            }).ToList();
            return apps;
        }
        public List<NameValueModel> GetAllAppCode()
        {
            var apps = _lookupService.GetLookupByLookupType(LookupTypes.App).Select(d => new NameValueModel()
            {
                Name = d.Title,
                Value = d.Code
            }).ToList();
            
            apps.Insert(0, new NameValueModel()
            {
                Name = "Tất cả"
            });
            return apps;
        }

        public List<NameValueModel> GetAllCustomerType()
        {
            var gatewayType = _lookupService.GetLookupByLookupType(LookupTypes.CustomerType).Select(d => new NameValueModel()
            {
                Name = d.Title,
                Value = d.Id.ToString()
            }).ToList();
            gatewayType.Insert(0, new NameValueModel() { Name = "Tất cả" });
            return gatewayType;
        }
        public List<NameValueModel> GetCustomerType()
        {
            var gatewayType = _lookupService.GetLookupByLookupType(LookupTypes.CustomerType).Select(d => new NameValueModel()
            {
                Name = d.Title,
                Value = d.Id.ToString()
            }).ToList();
            return gatewayType;
        }

        #region Shipment

        public List<NameValueModel> GetShipments()
        {
            var items = _lookupService.GetLookupByLookupType(LookupTypes.ShipmentType).Select(d => new NameValueModel()
            {
                Name = d.Title,
                Value = d.Code
            }).ToList();
            return items;
        }

        #endregion

        #region Commodities
        public List<NameValueModel> GetCommodities()
        {
            var items = _lookupService.GetLookupByLookupType(LookupTypes.CommoditiesType).Select(d => new NameValueModel()
            {
                Name = d.Title,
                Value = d.Code
            }).ToList();
            return items;
        }


        #endregion
        #region Type of bill
        public List<NameValueModel> GetTypeOfBill()
        {
            var items = _lookupService.GetLookupByLookupType(LookupTypes.TypeOfBill).Select(d => new NameValueModel()
            {
                Name = d.Title,
                Value = d.Code
            }).ToList();
            return items;
        }


        #endregion

        #region Payment
        public List<NameValueModel> GetPayments()
        {
            var items = _lookupService.GetLookupByLookupType(LookupTypes.PaymentType).Select(d => new NameValueModel()
            {
                Name = d.Title,
                Value = d.Code
            }).ToList();
            return items;
        }



        #endregion
        public List<NameValueModel> GetUnitTypes()
	    {
		    var units = _lookupService.GetLookupByLookupType(LookupTypes.UnitType).Select(d => new NameValueModel()
		    {
			    Name = d.Title,
			    Value = d.Code
		    }).ToList();
		    return units;
	    }

	    public List<NameValueModel> GetStandardEvents()
	    {
		    var units = _lookupService.GetLookupByLookupType(LookupTypes.ProducingEvents).Select(d => new NameValueModel()
		    {
			    Name = d.Title,
			    Value = d.Code
		    }).ToList();
		    return units;
	    }

	    public List<NameValueModel> GetAllBookTypes()
	    {
		    var bookTypes = _lookupService.GetLookupByLookupType(LookupTypes.BookType).Select(d => new NameValueModel()
		    {
			    Name = d.Title,
			    Value = d.Code.ToString()
		    }).ToList();
		    return bookTypes;
	    }
		public List<NameValueModel> GetAllSessionTypes()
		{
			var bookTypes = _lookupService.GetLookupByLookupType(LookupTypes.SessionType).Select(d => new NameValueModel()
			{
				Name = d.Title,
				Value = d.Code.ToString()
			}).ToList();
			return bookTypes;
		}
		public async Task<List<NameValueModel>> GetProductGroupForBreeds()
	    {
		    var lookups = await _lookupService.GetAlLookups();

			var res= lookups.Where(w=>w.Type==LookupTypes.ProductGroup && 
			              w.Code== ProductGroups.VatTu || 
			              w.Code== ProductGroups.PhanBon ||
			              w.Code== ProductGroups.ThuocBvtv)
			    .Select(d => new NameValueModel()
			    {
				    Name = d.Title,
				    Value = d.Id.ToString()
			    }).ToList();
			res.Insert(0,new NameValueModel
			{
				Name = "Tất cả",
				Value = "0"
			});
		    return res;
	    }
	}
}