﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AutoMapper;
using Falcon.Web.Core.Auth;
using Falcon.Web.Core.Helpers;
using Falcon.Web.Core.Message;
using Falcon.Web.Core.Settings;
using Newtonsoft.Json;
using Vino.Server.Data.Common;
using Vino.Server.Data.CRM;
using Vino.Server.Data.Framework;
using Vino.Server.Services.MainServices.Auth.Models;
using Vino.Server.Services.MainServices.Common.Models;
using Vino.Server.Services.MainServices.CRM.AirExp.Models;
using Vino.Server.Services.MainServices.CRM.AirImp.Models;
using Vino.Server.Services.MainServices.CRM.Carrier.Model;
using Vino.Server.Services.MainServices.CRM.Contact.Models;
using Vino.Server.Services.MainServices.CRM.Customer.Models;
using Vino.Server.Services.MainServices.CRM.FclExp.Models;
using Vino.Server.Services.MainServices.CRM.FclImp.Models;
using Vino.Server.Services.MainServices.CRM.HblLclExp.Models;
using Vino.Server.Services.MainServices.CRM.LclExp.Models;
using Vino.Server.Services.MainServices.CRM.LclImp.Models;
using Vino.Server.Services.MainServices.CRM.Port.Model;
using Vino.Server.Services.MainServices.CRM.Topic.Model;
using Vino.Server.Services.MainServices.Media.Models;
using Vino.Server.Services.MainServices.Message.Models;
using Vino.Server.Services.MainServices.System.Email.Models;
using Vino.Server.Services.MainServices.System.Log.Models;
using Vino.Server.Services.MainServices.System.Setting.Models;
using Vino.Server.Services.MainServices.Users.Models;
using Vino.Shared.Constants.Producing;
using Vino.Shared.Entities.Producing;
using Vino.Shared.Dto;

namespace Vino.Server.Services.Infrastructure
{
    public class AutoMapperWebProfile : Profile
    {
        public AutoMapperWebProfile()
        {
            //common
            CreateMap<Lookup, LookupModel>().ReverseMap();
            CreateMap<Lookup, LookupDto>().ReverseMap();
            CreateMap<Setting, SettingModel>().ReverseMap();
            CreateMap<OrderGenCode, OrderGenCodeModel>().ReverseMap();

            //logs
            CreateMap<Log, LogModel>()
                .ForMember(d => d.CreatedAt, opt => opt.MapFrom(x => x.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss")));
            CreateMap<LogModel, Log>();
            //role
            CreateMap<Role, RoleModel>();
            CreateMap<RoleModel, Role>();

            //image record
            CreateMap<ImageRecord, ImageModel>()
                .ForMember(d => d.CreatedAt, opt => opt.MapFrom(x => x.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss")));
            CreateMap<ImageModel, ImageRecord>()
                .ForMember(d => d.CreatedAt,
                    opt => opt.MapFrom(x => DateTimeOffset.Parse(x.CreatedAt, new CultureInfo("vi-VN"))));

            //user
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>()
                .ForMember(d => d.UserClaims, opt => opt.Ignore());
            //email account
            CreateMap<EmailAccount, EmailAccountModel>()
                .ForMember(d => d.Password, opt => opt.Ignore());
            CreateMap<EmailAccountModel, EmailAccount>();
            //message template
            CreateMap<MessageTemplate, MessageTemplateModel>();
            CreateMap<MessageTemplateModel, MessageTemplate>();

            // CRM
            // Airexp
            CreateMap<AirExp, AirExpModel>()
                .ForMember(d => d.Created, opt => opt.MapFrom(x =>
                    x.Created.ToString("dd/MM/yyyy HH:mm:ss")))
                .ForMember(d => d.Etd, opt => opt.MapFrom(x =>
                    x.Etd.ToString("dd/MM/yyyy HH:mm:ss")))
                .ForMember(d => d.Eta, opt => opt.MapFrom(x =>
                    x.Eta.ToString("dd/MM/yyyy HH:mm:ss")))
                .ForMember(d => d.FlyDate, opt => opt.MapFrom(x =>
                    x.FlyDate.ToString("dd/MM/yyyy HH:mm:ss")))
                .ForMember(d => d.AgentName, opt => opt.MapFrom(
                    x => x.Agent.FullEnglishName))
                .ForMember(d => d.CarrierName, opt => opt.MapFrom(
                    x => x.Carrier.FullEnglishName))
                ;
            CreateMap<AirExpModel, AirExp>()
                .ForMember(d => d.Created,
                    opt => opt.MapFrom(x =>
                        string.IsNullOrEmpty(x.Created) ? (DateTimeOffset?)null : DateTimeOffset.ParseExact(x.Created, "dd/MM/yyyy", new CultureInfo("vi-VN"))))
                .ForMember(d => d.Eta,
                    opt => opt.MapFrom(x =>
                        string.IsNullOrEmpty(x.Eta) ? (DateTimeOffset?)null : DateTimeOffset.ParseExact(x.Eta, "dd/MM/yyyy", new CultureInfo("vi-VN"))))
                .ForMember(d => d.Etd,
                    opt => opt.MapFrom(x =>
                        string.IsNullOrEmpty(x.Etd) ? (DateTimeOffset?)null : DateTimeOffset.ParseExact(x.Etd, "dd/MM/yyyy", new CultureInfo("vi-VN"))))
                .ForMember(d => d.FlyDate,
                    opt => opt.MapFrom(x =>
                        string.IsNullOrEmpty(x.FlyDate) ? (DateTimeOffset?)null : DateTimeOffset.ParseExact(x.FlyDate, "dd/MM/yyyy", new CultureInfo("vi-VN"))))
                ;

            // Contacts
            CreateMap<CrmContact, CrmContactModel>()
                .ForMember(d => d.Birthday, opt => opt.MapFrom(x => x.Birthday.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(d => d.SpouseBirthday, opt => opt.MapFrom(x => x.SpouseBirthday.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(d => d.FullName, opt => opt.MapFrom(
                    src => src.FirstName + " " + src.LastName));

            CreateMap<CrmContactModel, CrmContact>()
                .ForMember(d => d.Birthday,
                    opt => opt.MapFrom(x =>
                        string.IsNullOrEmpty(x.Birthday)
                            ? (DateTimeOffset?) null
                            : DateTimeOffset.ParseExact(x.Birthday, "dd/MM/yyyy", new CultureInfo("vi-VN"))))
                .ForMember(d => d.SpouseBirthday,
                    opt => opt.MapFrom(x =>
                        string.IsNullOrEmpty(x.SpouseBirthday)
                            ? (DateTimeOffset?) null
                            : DateTimeOffset.ParseExact(x.SpouseBirthday, "dd/MM/yyyy", new CultureInfo("vi-VN"))));

            // ports
            CreateMap<Port, PortModel>();
            CreateMap<PortModel, Port>();

            // carrier
            CreateMap<Carrier, CarrierModel>();
            CreateMap<CarrierModel, Carrier>();

            CreateMap<CrmCustomer, CrmCustomerModel>()
                .ForMember(d => d.LocationName, opt => opt.MapFrom(
                    x => x.Location.Title))
                .ForMember(d => d.ContactName, opt => opt.MapFrom(
                    x => x.Contact.EnglishName))
                .ForMember(d => d.CategoryName, opt => opt.MapFrom(
                    x => x.Category.Title));
            CreateMap<CrmCustomerModel, CrmCustomer>();


            // FclExp
            CreateMap<FclExp, FclExpModel>()
                .ForMember(d => d.Created, opt => opt.MapFrom(x => x.Created.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(d => d.Etd, opt => opt.MapFrom(x => x.Etd.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(d => d.Eta, opt => opt.MapFrom(x => x.Eta.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(d => d.PolName, opt => opt.MapFrom(
                    x => x.Pol.PortName))
                .ForMember(d => d.OpIcName, opt => opt.MapFrom(
                    x => x.OpIc.EnglishName))
                .ForMember(d => d.SLinesName, opt => opt.MapFrom(
                    x => x.SLines.FullEnglishName))
                .ForMember(d => d.AgentName, opt => opt.MapFrom(
                    x => x.Agent.FullEnglishName))
                .ForMember(d => d.PodName, opt => opt.MapFrom(
                    x => x.Pod.PortName));
            CreateMap<FclExpModel, FclExp>()
                .ForMember(d => d.Created,
                    opt => opt.MapFrom(x => DateTimeOffset.ParseExact(x.Created, "dd/MM/yyyy", new CultureInfo("vi-VN"))))
                .ForMember(d => d.Eta,
                    opt => opt.MapFrom(x => DateTimeOffset.ParseExact(x.Eta, "dd/MM/yyyy", new CultureInfo("vi-VN"))))
                .ForMember(d => d.Etd,
                    opt => opt.MapFrom(x => DateTimeOffset.ParseExact(x.Etd, "dd/MM/yyyy", new CultureInfo("vi-VN"))));


            // LclExp
            CreateMap<LclExp, LclExpModel>()
                .ForMember(d => d.Created, opt => opt.MapFrom(x => x.Created.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(d => d.Eta, opt => opt.MapFrom(x => x.Eta.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(d => d.Etd, opt => opt.MapFrom(x => x.Etd.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(d => d.PodName, opt => opt.MapFrom(
                    x => x.Pod.PortName))
                .ForMember(d => d.PolName, opt => opt.MapFrom(
                    x => x.Pol.PortName))
                .ForMember(d => d.CoLoaderName, opt => opt.MapFrom(
                    x => x.CoLoader.FullEnglishName))
                .ForMember(d => d.AgentName, opt => opt.MapFrom(
                    x => x.Agent.FullEnglishName))
                ;

            CreateMap<LclExpModel, LclExp>()
                .ForMember(d => d.Created,
                    opt => opt.MapFrom(x => DateTimeOffset.ParseExact(x.Created, "dd/MM/yyyy", new CultureInfo("vi-VN"))))
                .ForMember(d => d.Eta,
                    opt => opt.MapFrom(x => DateTimeOffset.ParseExact(x.Eta, "dd/MM/yyyy", new CultureInfo("vi-VN"))))
                .ForMember(d => d.Etd,
                    opt => opt.MapFrom(x => DateTimeOffset.ParseExact(x.Etd, "dd/MM/yyyy", new CultureInfo("vi-VN"))));

            // AirImp
            CreateMap<AirImp, AirImpModel>()
                .ForMember(d => d.Created, opt => opt.MapFrom(x => x.Created.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(d => d.Eta, opt => opt.MapFrom(x => x.Eta.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(d => d.FLyDate, opt => opt.MapFrom(x => x.FLyDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(d => d.OpIcName, opt => opt.MapFrom(
                    x => x.OpIc.EnglishName))
                .ForMember(d => d.AodName, opt => opt.MapFrom(
                    x => x.Aol.PortName))
                .ForMember(d => d.DeliveryName, opt => opt.MapFrom(
                    x => x.Delivery.PortName))
                .ForMember(d => d.AirlinesName, opt => opt.MapFrom(
                    x => x.Airlines.FullEnglishName))
                .ForMember(d => d.AgentName, opt => opt.MapFrom(
                    x => x.Agent.FullEnglishName))
                .ForMember(d => d.AodName, opt => opt.MapFrom(
                    x => x.Aod.PortName));
            CreateMap<AirImpModel, AirImp>()
                .ForMember(d => d.Created,
                    opt => opt.MapFrom(x => DateTimeOffset.ParseExact(x.Created, "dd/MM/yyyy", new CultureInfo("vi-VN"))))
                .ForMember(d => d.Eta,
                    opt => opt.MapFrom(x => DateTimeOffset.ParseExact(x.Eta, "dd/MM/yyyy", new CultureInfo("vi-VN"))))
                .ForMember(d => d.FLyDate,
                    opt => opt.MapFrom(x => DateTimeOffset.ParseExact(x.FLyDate, "dd/MM/yyyy", new CultureInfo("vi-VN"))));

            // FclImp
            CreateMap<FclImp, FclImpModel>()
                .ForMember(d => d.Created,
                    opt => opt.MapFrom(x => x.Created.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(d => d.Eta,
                    opt => opt.MapFrom(x => x.Eta.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(d => d.Etd,
                    opt => opt.MapFrom(x => x.Etd.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(d => d.PolName, opt => opt.MapFrom(
                    x => x.Pol.PortName))
                .ForMember(d => d.OpIcName, opt => opt.MapFrom(
                    x => x.OpIc.EnglishName))
                .ForMember(d => d.PodName, opt => opt.MapFrom(
                    x => x.Pod.PortName))
                .ForMember(d => d.AgentName, opt => opt.MapFrom(
                    x => x.Agent.FullEnglishName))
                .ForMember(d => d.DeliveryName, opt => opt.MapFrom(
                    x => x.Delivery.PortName));
            CreateMap<FclImpModel, FclImp>()
                .ForMember(d => d.Created,
                    opt => opt.MapFrom(x => DateTimeOffset.ParseExact(x.Created, "dd/MM/yyyy", new CultureInfo("vi-VN"))))
                .ForMember(d => d.Eta,
                    opt => opt.MapFrom(x => DateTimeOffset.ParseExact(x.Eta, "dd/MM/yyyy", new CultureInfo("vi-VN"))))
                .ForMember(d => d.Etd,
                    opt => opt.MapFrom(x => DateTimeOffset.ParseExact(x.Etd, "dd/MM/yyyy", new CultureInfo("vi-VN"))));

            // LclImp
            CreateMap<LclImp, LclImpModel>()
                .ForMember(d => d.Created,
                    opt => opt.MapFrom(x => x.Created.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(d => d.Eta,
                    opt => opt.MapFrom(x => x.Eta.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(d => d.Etd,
                    opt => opt.MapFrom(x => x.Etd.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(d => d.PolName, opt => opt.MapFrom(
                    x => x.Pol.PortName))
                .ForMember(d => d.OpIcName, opt => opt.MapFrom(
                    x => x.OpIc.EnglishName))
                .ForMember(d => d.PodName, opt => opt.MapFrom(
                    x => x.Pod.PortName))
                .ForMember(d => d.SLinesName, opt => opt.MapFrom(
                    x => x.SLines.FullEnglishName))
                .ForMember(d => d.AgentName, opt => opt.MapFrom(
                    x => x.Agent.FullEnglishName))
                .ForMember(d => d.DeliveryName, opt => opt.MapFrom(
                    x => x.Delivery.PortName));

            CreateMap<LclImpModel, LclImp>()
                .ForMember(d => d.Created,
                    opt => opt.MapFrom(x => DateTimeOffset.ParseExact(x.Created, "dd/MM/yyyy", new CultureInfo("vi-VN"))))
                .ForMember(d => d.Eta,
                    opt => opt.MapFrom(x => DateTimeOffset.ParseExact(x.Eta, "dd/MM/yyyy", new CultureInfo("vi-VN"))))
                .ForMember(d => d.Etd,
                    opt => opt.MapFrom(x => DateTimeOffset.ParseExact(x.Etd, "dd/MM/yyyy", new CultureInfo("vi-VN"))));

            // HblLclExp
            CreateMap<HblLclExp, HblLclExpModel>()
                .ForMember(d => d.ShipperName, opt => opt.MapFrom(
                    x => x.Shipper.Name))
                .ForMember(d => d.ConsigneeName, opt => opt.MapFrom(
                    x => x.Consignee.Name))
                .ForMember(d => d.NotifyPartyName, opt => opt.MapFrom(
                    x => x.NotifyParty.Name))
                .ForMember(d => d.PlaceOfReceiptName, opt => opt.MapFrom(
                    x => x.PlaceOfReceipt.PortName))
                .ForMember(d => d.PortOfLoaingName, opt => opt.MapFrom(
                    x => x.PortOfLoaing.PortName))
                .ForMember(d => d.PortOfDischargeName, opt => opt.MapFrom(
                    x => x.PortOfDischarge.PortName))
                .ForMember(d => d.TranshipmentPortName, opt => opt.MapFrom(
                    x => x.TranshipmentPort.PortName))
                .ForMember(d => d.FinalDestinationName, opt => opt.MapFrom(
                    x => x.FinalDestination.PortName))
                .ForMember(d => d.PlaceOfDeliveryName, opt => opt.MapFrom(
                    x => x.PlaceOfDelivery.PortName))
                .ForMember(d => d.DeliveryOfGoodsName, opt => opt.MapFrom(
                    x => x.DeliveryOfGoods.Name))
                .ForMember(d => d.NotifyPartyName, opt => opt.MapFrom(
                    x => x.NotifyParty.Name))
                .ForMember(d => d.ClosingDate,
                    opt => opt.MapFrom(x => x.ClosingDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(d => d.SailingDate,
                    opt => opt.MapFrom(x => x.SailingDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(d => d.ExRef,
                    opt => opt.MapFrom(x =>
                        x.ExRef.HasValue ? x.ExRef.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) : ""))
                .ForMember(d => d.IssueDate,
                    opt => opt.MapFrom(x => x.IssueDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(d => d.CreatedAt,
                    opt => opt.MapFrom(x => x.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture)));
            CreateMap<HblLclExpModel, HblLclExp>()
                .ForMember(d => d.ClosingDate,
                    opt => opt.MapFrom(x => DateTimeOffset.ParseExact(x.ClosingDate, "dd/MM/yyyy", new CultureInfo("vi-VN"))))
                .ForMember(d => d.SailingDate,
                    opt => opt.MapFrom(x => DateTimeOffset.ParseExact(x.SailingDate, "dd/MM/yyyy", new CultureInfo("vi-VN"))))
                .ForMember(d => d.IssueDate,
                    opt => opt.MapFrom(x => DateTimeOffset.ParseExact(x.IssueDate, "dd/MM/yyyy", new CultureInfo("vi-VN"))))
                .ForMember(d => d.CreatedAt,
                opt => opt.MapFrom(x => DateTimeOffset.ParseExact(x.CreatedAt, "dd/MM/yyyy HH:mm:ss", new CultureInfo("vi-VN"))));

            // Topic
            CreateMap<Topic, TopicModel>()
                .ForMember(d => d.ImagePath, opt => opt.MapFrom(
                    x => x.Image.RelativePath));
            CreateMap<TopicModel, Topic>();

        }
    }
}


