﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.WebPages;
using Falcon.Web.Core.Helpers;
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
                Name = "Tất cả"
            });
            return lookupTypes;
        }

        public List<NameValueModel> GetLookupsByType(LookupTypes type)
        {
            var lookups = _lookupService.GetLookupByLookupType(type).Select(d => new NameValueModel()
            {
                Name = d.Title,
                Value = d.Code
            }).ToList();
            return lookups;
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

        public List<NameValueModel> GetLookupWithCode(LookupTypes type, bool withAll = false)
        {
            var lookups = _lookupService.GetLookupByLookupType(type).Select(d => new NameValueModel()
            {
                Name = d.Title,
                Value = d.Code
            }).ToList();
            if (withAll)
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

        public List<NameValueModel> GetShipments(string name = "", bool withAll = false)
        {
            var shipments = _lookupService.GetLookupByLookupType(LookupTypes.ShipmentType).Select(d => new NameValueModel()
            {
                Name = d.Title,
                Value = d.Id.ToString()
            }).Where(p => p.Name.ToLower().Contains(name.IsNullOrEmpty() ? "" : name.ToLower())).ToList();
            if (withAll)
                shipments.Insert(0, new NameValueModel() { Name = "Tất cả", Value = "0" });

            return shipments;
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

        public List<NameValueModel> GetTypeOfBillWithIds(string name = "", bool withAll = false)
        {
            var typeOfBills = _lookupService.GetLookupByLookupType(LookupTypes.TypeOfBill)
                .Select(d => new NameValueModel()
                {
                    Name = d.Title,
                    Value = d.Id.ToString()
                }).Where(x => x.Name.ToLower().Contains(name.IsNullOrEmpty() ? "" : name)).ToList();

            if (withAll)
                typeOfBills.Insert(0, new NameValueModel() { Name = "Tất cả", Value = "0" });

            return typeOfBills;
        }
        #endregion

        #region Payment
        public List<NameValueModel> GetPayments(string name = "", bool withAll = false)
        {
            var payments = _lookupService.GetLookupByLookupType(LookupTypes.PaymentType).Select(d => new NameValueModel()
            {
                Name = d.Title,
                Value = d.Id.ToString()
            }).Where(p => p.Name.ToLower().Contains(name.IsNullOrEmpty() ? "" : name.ToLower())).ToList();
            if (withAll)
                payments.Insert(0, new NameValueModel() { Name = "Tất cả", Value = "0" });

            return payments;
        }


        #endregion

        #region Countries
        public List<NameValueModel> GetCountries(string name = "", bool withAll = false)
        {
            var countries = _lookupService.GetLookupByLookupType(LookupTypes.NationalityType).Select(d => new NameValueModel()
            {
                Name = d.Title,
                Value = d.Id.ToString()
            }).Where(p => p.Name.ToLower().Contains(name.IsNullOrEmpty() ? "" : name.ToLower())).ToList();
            if (withAll)
                countries.Insert(0, new NameValueModel() { Name = "Tất cả", Value = "0" });

            return countries;
        }
        #endregion

        #region Type of move
        public List<NameValueModel> GetTypeOfMove(string name = "", bool withAll = false)
        {
            var types = _lookupService.GetLookupByLookupType(LookupTypes.TypeOfMove).Select(d => new NameValueModel()
            {
                Name = d.Title,
                Value = d.Id.ToString()
            }).Where(p => p.Name.ToLower().Contains(name.IsNullOrEmpty() ? "" : name.ToLower())).ToList();
            if (withAll)
                types.Insert(0, new NameValueModel() { Name = "Tất cả", Value = "0" });

            return types;
        }
        #endregion

        #region Vessels
        public List<NameValueModel> GetVessels(string name = "", bool withAll = false)
        {
            var vessels = _lookupService.GetLookupByLookupType(LookupTypes.VesselType).Select(d => new NameValueModel()
            {
                Name = d.Title,
                Value = d.Id.ToString()
            }).Where(p => p.Name.ToLower().Contains(name.IsNullOrEmpty() ? "" : name.ToLower())).ToList();
            if (withAll)
                vessels.Insert(0, new NameValueModel() { Name = "Tất cả", Value = "0" });

            return vessels;
        }
        #endregion

        #region Commodities
        public List<NameValueModel> GetCommodities(string name = "", bool withAll = false)
        {
            var commodities = _lookupService.GetLookupByLookupType(LookupTypes.CommoditiesType).Select(d => new NameValueModel()
            {
                Name = d.Title,
                Value = d.Id.ToString()
            }).Where(p => p.Name.ToLower().Contains(name.IsNullOrEmpty() ? "" : name.ToLower())).ToList();
            if (withAll)
                commodities.Insert(0, new NameValueModel() { Name = "Tất cả", Value = "0" });

            return commodities;
        }
        #endregion

        #region Unit
        public List<NameValueModel> GetUnitTypes(string name = "", bool withAll = false)
        {
            var units = _lookupService.GetLookupByLookupType(LookupTypes.UnitType).Select(d => new NameValueModel()
            {
                Name = d.Title,
                Value = d.Id.ToString()
            }).Where(p => p.Name.ToLower().Contains(name.IsNullOrEmpty() ? "" : name.ToLower())).ToList();
            if (withAll)
                units.Insert(0, new NameValueModel() { Name = "Tất cả", Value = "0" });

            return units;
        }
        #endregion

        #region Places
        public List<NameValueModel> GetPlaces(string name = "", bool withAll = false)
        {
            var places = _lookupService.GetLookupByLookupType(LookupTypes.PlaceType).Select(d => new NameValueModel()
            {
                Name = d.Title,
                Value = d.Id.ToString()
            }).Where(p => p.Name.ToLower().Contains(name.IsNullOrEmpty() ? "" : name.ToLower())).ToList();
            if (withAll)
                places.Insert(0, new NameValueModel() { Name = "Tất cả", Value = "0" });

            return places;
        }
        #endregion

        #region Location
        public List<NameValueModel> GetLocations(string name = "", bool withAll = false)
        {
            var locations = _lookupService.GetLookupByLookupType(LookupTypes.LocationType).Select(d => new NameValueModel()
            {
                Name = d.Title,
                Value = d.Id.ToString()
            }).Where(p => p.Name.ToLower().Contains(name.IsNullOrEmpty() ? "" : name.ToLower())).ToList();
            if (withAll)
                locations.Insert(0, new NameValueModel() { Name = "Tất cả", Value = "0" });

            return locations;
        }


        #endregion

        #region Categories
        public List<NameValueModel> GetCategories(string name = "", bool withAll = false)
        {
            var categories = _lookupService.GetLookupByLookupType(LookupTypes.CategoryType).Select(d => new NameValueModel()
            {
                Name = d.Title,
                Value = d.Id.ToString()
            }).Where(p => p.Name.ToLower().Contains(name.IsNullOrEmpty() ? "" : name.ToLower())).ToList();
            if (withAll)
                categories.Insert(0, new NameValueModel() { Name = "Tất cả", Value = "0" });

            return categories;
        }


        #endregion

        #region Zones
        public List<NameValueModel> GetZones(string name = "", bool withAll = false)
        {
            var zones = _lookupService.GetLookupByLookupType(LookupTypes.ZoneType).Select(d => new NameValueModel()
            {
                Name = d.Title,
                Value = d.Id.ToString()
            }).Where(p => p.Name.ToLower().Contains(name.IsNullOrEmpty() ? "" : name.ToLower())).ToList();
            if (withAll)
                zones.Insert(0, new NameValueModel() { Name = "Tất cả", Value = "0" });

            return zones;
        }


        #endregion

        #region Modes
        public List<NameValueModel> GetModes(string name = "", bool withAll = false)
        {
            var modes = _lookupService.GetLookupByLookupType(LookupTypes.ModeType).Select(d => new NameValueModel()
            {
                Name = d.Title,
                Value = d.Id.ToString()
            }).Where(p => p.Name.ToLower().Contains(name.IsNullOrEmpty() ? "" : name.ToLower())).ToList();
            if (withAll)
                modes.Insert(0, new NameValueModel() { Name = "Tất cả", Value = "0" });

            return modes;
        }


        #endregion

        #region Topic
        public List<NameValueModel> GetTopicTypes(string name = "", bool withAll = false)
        {
            var topics = _lookupService.GetLookupByLookupType(LookupTypes.TopicType).Select(d => new NameValueModel()
            {
                Name = d.Title,
                Value = d.Id.ToString()
            }).Where(p => p.Name.ToLower().Contains(name.IsNullOrEmpty() ? "" : name.ToLower())).ToList();
            if (withAll)
                topics.Insert(0, new NameValueModel() { Name = "Tất cả", Value = "0" });

            return topics;
        }


        #endregion

        #region Position
        public List<NameValueModel> GetPositions(string name = "", bool withAll = false)
        {
            var positions = _lookupService.GetLookupByLookupType(LookupTypes.PositionType).Select(d => new NameValueModel()
            {
                Name = d.Title,
                Value = d.Id.ToString()
            }).Where(p => p.Name.ToLower().Contains(name.IsNullOrEmpty() ? "" : name.ToLower())).ToList();
            if (withAll)
                positions.Insert(0, new NameValueModel() { Name = "Tất cả", Value = "0" });

            return positions;
        }


        #endregion

        #region Department
        public List<NameValueModel> GetDepartments(string name = "", bool withAll = false)
        {
            var departments = _lookupService.GetLookupByLookupType(LookupTypes.DepartmentType).Select(d => new NameValueModel()
            {
                Name = d.Title,
                Value = d.Id.ToString()
            }).Where(p => p.Name.ToLower().Contains(name.IsNullOrEmpty() ? "" : name.ToLower())).ToList();
            if (withAll)
                departments.Insert(0, new NameValueModel() { Name = "Tất cả", Value = "0" });

            return departments;
        }


        #endregion

        #region Remark
        public List<NameValueModel> GetRemarks(string name = "", bool withAll = false)
        {
            var remark = _lookupService.GetLookupByLookupType(LookupTypes.Remark).Select(d => new NameValueModel()
            {
                Name = d.Title,
                Value = d.Id.ToString()
            }).Where(p => p.Name.ToLower().Contains(name.IsNullOrEmpty() ? "" : name.ToLower())).ToList();
            if (withAll)
                remark.Insert(0, new NameValueModel() { Name = "Tất cả", Value = "0" });

            return remark;
        }


        #endregion

        #region Freight
        public List<NameValueModel> GetFreights(string name = "", bool withAll = false)
        {
            var freights = _lookupService.GetLookupByLookupType(LookupTypes.FreightType).Select(d => new NameValueModel()
            {
                Name = d.Title,
                Value = d.Id.ToString()
            }).Where(p => p.Name.ToLower().Contains(name.IsNullOrEmpty() ? "" : name.ToLower())).ToList();
            if (withAll)
                freights.Insert(0, new NameValueModel() { Name = "Tất cả", Value = "0" });

            return freights;
        }


        #endregion

        #region Mbl type
        public List<NameValueModel> GetMblTypes(string name = "", bool withAll = false)
        {
            var mblTypes = _lookupService.GetLookupByLookupType(LookupTypes.MblType).Select(d => new NameValueModel()
            {
                Name = d.Title,
                Value = d.Id.ToString()
            }).Where(p => p.Name.ToLower().Contains(name.IsNullOrEmpty() ? "" : name.ToLower())).ToList();
            if (withAll)
                mblTypes.Insert(0, new NameValueModel() { Name = "Tất cả", Value = "0" });

            return mblTypes;
        }


        #endregion

        #region Voyage
        public List<NameValueModel> GetVoyages(string name = "", bool withAll = false)
        {
            var mblTypes = _lookupService.GetLookupByLookupType(LookupTypes.VoyageType).Select(d => new NameValueModel()
            {
                Name = d.Title,
                Value = d.Id.ToString()
            }).Where(p => p.Name.ToLower().Contains(name.IsNullOrEmpty() ? "" : name.ToLower())).ToList();
            if (withAll)
                mblTypes.Insert(0, new NameValueModel() { Name = "Tất cả", Value = "0" });

            return mblTypes;
        }


        #endregion
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

    }
}