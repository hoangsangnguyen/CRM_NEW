using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Threading.Tasks;
using Falcon.Web.Core.Auth;
using Falcon.Web.Core.Data;
using Falcon.Web.Core.Helpers;
using Falcon.Web.Core.Infrastructure;
using Falcon.Web.Core.Message;
using Falcon.Web.Core.Security;

using Vino.Server.Data.Common;
using Vino.Server.Services.Constants;
using Vino.Server.Services.Database;
using Vino.Server.Services.Framework;
using Vino.Server.Services.MainServices.Auth;
using Vino.Server.Services.MainServices.Users;
using Vino.Server.Services.Settings;
using Vino.Shared.Constants;
using Vino.Shared.Constants.Common;
using Vino.Shared.Constants.Producing;
using Vino.Shared.Constants.Warehouse;
using Vino.Shared.Dto.Employees;

namespace Vino.Server.Services.Installation
{
    public class Installer
    {
        private static bool _busy;

        public Installer()
        {
        }

        public async Task<string> Install()
        {
            if (_busy) return "Busy";
            _busy = true;
            //install basic data
            using (var scope = TransactionUtils.CreateSubScope())
            {
                //basic data
                await InstallSettings();
                await InstallRoles();
                await InstallAdminAccount();
                await InstallLookups();
                scope.Complete();
            }

            using (var scope = TransactionUtils.CreateSubScope())
            {
                scope.Complete();
            }
            _busy = false;
            return "Done";
        }

        public async Task InstallSettings()
        {
            var settingsService = EngineContext.Current.Resolve<SettingService>();
            await settingsService.SaveSetting(new SecuritySettings()
            {
                EncryptionKey = CommonHelper.GenerateRandomDigitCode(16),
                UniqueToken = true,
                TokenLifeTime = 24 * 60, //1 day
                CookieLifeTime = 24 * 356 //1 year
            });
            var now = DateTime.Now;
            await settingsService.SaveSetting(new SystemSettings()
            {
                CacheLong = 24 * 60, //1 ngay
                CacheNormal = 90, //90p
                CacheShort = 5, //5p
                Domain = "http://localhost:63198/"
            });

            await settingsService.SaveSetting(new EmailSettings()
            {
                EmailWelcomeTitle = "Chào mừng thành viên của Vino",
                EmailWelcomeTemplate = "<p><span style=\"font-size:medium;\"data-mce-mark=\"1\"><strong>Ch&agrave;o mừng {@*userName}&nbsp;<span style=\"color:inherit;font-family:inherit;\" data-mce-mark=\"1\">tham gia Vino</span></strong></span></p><p>&nbsp;</p><p>Cảm ơn bạn đ&atilde; đăng k&yacute; t&agrave;i khoản tr&ecirc;n Vino.&nbsp;</p><p>Mật khẩu của bạn l&agrave;{@*password}</p><p>Th&acirc;n mến,</p><p><strong style=\"font-size:medium;\"> BQT & nbsp; Vino</strong></p>",
                EmailResetPasswordTitle = "Thông báo v/v đặt lại mật khẩu trên Vino",
                EmailResetPasswordTemplate = "<p>Dear <strong>{@*userName}</strong> !</p>\r\n<p><br />Theo y&ecirc;u cầu của bạn, mật khẩu đăng nhập tr&ecirc;n <span style=\"color: #0000ff;\">Vino</span> đ&atilde; được cấp mới. Chi tiết t&agrave;i khoản của bạn hiện tại như sau:</p>\r\n<p>T&agrave;i khoản đăng nhập: {@*userName}</p>\r\n<p>T&ecirc;n hiển thị: {@*displayName}</p><p>&nbsp;</p>\r\n<p>Th&acirc;n mến,</p>\r\n<p><span style=\"font-size: medium;\"><strong>BQT Vino</strong></span></p>",
                SystemEmailAccount = new EmailAccount()
                {
                    Id = 1,
                    Email = "test@fsw.vn",
                    DisplayName = "Vino",
                    Host = "mail.fsw.vn",
                    EnableSsl = false,
                    Port = 25,
                    Password = "fsw#123@",
                    UseDefaultCredentials = false,
                    Username = "test@fsw.vn"
                }
            });
            await settingsService.SaveSetting(new MediaSettings()
            {
                TargetResize = 100
            });
            await settingsService.SaveSetting(new MetadataSettings()
            {
                PhoToMaxWidth = 1024,
                PhotoSizePercent = 5,
                UploadingFolder = "Uploads",
                ResizeMode = Shared.Dto.ImageResizeModes.ByMaxWidth,
                NumberOfDayGetNewsLatest = 7
            });
        }

        public async Task InstallRoles()
        {
            var roleService = EngineContext.Current.Resolve<RoleService>();
            await roleService.Create(new Role()
            {
                Active = true,
                Display = "Quản trị",
                SystemName = ServerPermissions.Admin,
                Permissons = string.Join(";", ServerPermissions.DefaultClaims.Where(x => x.Key == ServerPermissions.Admin).Select(x => x.Value))
            });
            await roleService.Create(new Role()
            {
                Active = true,
                Display = "Vận hành hệ thống",
                SystemName = ServerPermissions.Operator,
                Permissons = string.Join(";", ServerPermissions.DefaultClaims.Where(x => x.Key == ServerPermissions.Operator).Select(x => x.Value))
            });
            await roleService.Create(new Role()
            {
                Active = true,
                Display = "Quản lý Cấp cao",
                SystemName = ServerPermissions.Manager,
                Permissons = string.Join(";", ServerPermissions.DefaultClaims.Where(x => x.Key == ServerPermissions.Manager).Select(x => x.Value))
            });
            await roleService.Create(new Role()
            {
                Active = true,
                Display = "Nhân viên Sản xuất",
                SystemName = ServerPermissions.ProducingStaff,
                Permissons = string.Join(";", ServerPermissions.DefaultClaims.Where(x => x.Key == ServerPermissions.ProducingStaff).Select(x => x.Value))
            });
            await roleService.Create(new Role()
            {
                Active = true,
                Display = "Quản lý Sản xuất",
                SystemName = ServerPermissions.ProducingManager,
                Permissons = string.Join(";", ServerPermissions.DefaultClaims.Where(x => x.Key == ServerPermissions.ProducingManager).Select(x => x.Value))
            });
            await roleService.Create(new Role()
            {
                Active = true,
                Display = "Nhân viên",
                SystemName = ServerPermissions.Employee,
                Permissons = string.Join(";", ServerPermissions.DefaultClaims.Where(x => x.Key == ServerPermissions.Employee).Select(x => x.Value))
            });
        }

        public async Task InstallAdminAccount()
        {
            var userService = EngineContext.Current.Resolve<UserService>();
            await userService.Create("Admin", "123", new List<string>() { ServerPermissions.Admin });
            await userService.Create("manager", "123", new List<string>() { ServerPermissions.Manager });
            await userService.Create("operator", "123", new List<string>() { ServerPermissions.Operator });
            await userService.Create("employee", "123", new List<string>() { ServerPermissions.Employee });
            await userService.Create("user1", "123", new List<string>() { ServerPermissions.ProducingStaff });
        }


        #region Lookups
        public async Task InstallLookups()
        {
            var db = EngineContext.Current.Resolve<DataContext>();


            #region Gender
            db.Lookups.Add(new Lookup()
            {
                Code = "0",
                Title = "-",
                Type = LookupTypes.Gender
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "1",
                Title = "Nam",
                Type = LookupTypes.Gender
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "2",
                Title = "Nữ",
                Type = LookupTypes.Gender
            });


            #endregion

            #region Commodities
            db.Lookups.Add(new Lookup()
            {
                Code = "1",
                Title = "Seafood",
                Type = LookupTypes.CommoditiesType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "2",
                Title = "Electtronics & Electrical material",
                Type = LookupTypes.CommoditiesType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "3",
                Title = "Coffee",
                Type = LookupTypes.CommoditiesType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "4",
                Title = "Paper & Chemical Products",
                Type = LookupTypes.CommoditiesType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "5",
                Title = "Marble & Tiles",
                Type = LookupTypes.CommoditiesType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "6",
                Title = "Rice",
                Type = LookupTypes.CommoditiesType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "7",
                Title = "Funiture, Frames, Wood Articles",
                Type = LookupTypes.CommoditiesType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "8",
                Title = "Machinery, Utensils & Metalware",
                Type = LookupTypes.CommoditiesType
            });
           
            db.Lookups.Add(new Lookup()
            {
                Code = "9",
                Title = "Glass, Ceramic and Plasticware",
                Type = LookupTypes.CommoditiesType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "10",
                Title = "Textiles, Gaments and accessories",
                Type = LookupTypes.CommoditiesType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "11",
                Title = "Foods & Beverages",
                Type = LookupTypes.CommoditiesType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "12",
                Title = "Others",
                Type = LookupTypes.CommoditiesType
            });

            #endregion

            #region Positions

            db.Lookups.Add(new Lookup()
            {
                Code = "1",
                Title = "Oversea Manager",
                Type = LookupTypes.PositionType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "2",
                Title = "Nomination",
                Type = LookupTypes.PositionType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "3",
                Title = "Account Manager",
                Type = LookupTypes.PositionType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "4",
                Title = "General Director",
                Type = LookupTypes.PositionType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "5",
                Title = "Accountant",
                Type = LookupTypes.PositionType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "6",
                Title = "Staff",
                Type = LookupTypes.PositionType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "7",
                Title = "Operation Executive",
                Type = LookupTypes.PositionType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "8",
                Title = "Director",
                Type = LookupTypes.PositionType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "8",
                Title = "FLC",
                Type = LookupTypes.PositionType
            });

            #endregion

            #region Departments

            db.Lookups.Add(new Lookup()
            {
                Code = "DP001",
                Title = "BOD",
                Type = LookupTypes.DepartmentType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "DP002",
                Title = "Sales",
                Type = LookupTypes.DepartmentType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "DP003",
                Title = "Accounting",
                Type = LookupTypes.DepartmentType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "DP004",
                Title = "Operation",
                Type = LookupTypes.DepartmentType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "DP005",
                Title = "Oversea",
                Type = LookupTypes.DepartmentType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "DP006",
                Title = "HAN Office",
                Type = LookupTypes.DepartmentType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "DP007",
                Title = "FLC",
                Type = LookupTypes.DepartmentType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "DP008",
                Title = "Nomination",
                Type = LookupTypes.DepartmentType
            });
            #endregion

            #region Shipments
            db.Lookups.Add(new Lookup()
            {
                Code = "1",
                Title = "FREE-HAND",
                Type = LookupTypes.ShipmentType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "2",
                Title = "NOMINATED",
                Type = LookupTypes.ShipmentType
            });

            #endregion

            #region Payments
            db.Lookups.Add(new Lookup()
            {
                Code = "1",
                Title = "FREIGHT PREPAID",
                Type = LookupTypes.PaymentType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "2",
                Title = "FREIGHT COLLECT",
                Type = LookupTypes.PaymentType
            });

            #endregion

            #region TypeOfBills
            db.Lookups.Add(new Lookup()
            {
                Code = "1",
                Title = "COPY",
                Type = LookupTypes.TypeOfBill
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "2",
                Title = "ORIGINAL",
                Type = LookupTypes.TypeOfBill
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "3",
                Title = "SURRENDERED",
                Type = LookupTypes.TypeOfBill
            });

            #endregion

            #region Units

            db.Lookups.Add(new Lookup()
            {
                Code = "1",
                Title = "BAG",
                Type = LookupTypes.UnitType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "2",
                Title = "CBM",
                Type = LookupTypes.UnitType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "3",
                Title = "BOXES",
                Type = LookupTypes.UnitType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "4",
                Title = "BL",
                Type = LookupTypes.UnitType
            });
            #endregion

            #region Modes
            db.Lookups.Add(new Lookup()
            {
                Code = "1",
                Title = "DEPOT",
                Type = LookupTypes.ModeType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "2",
                Title = "SEA&AIR",
                Type = LookupTypes.ModeType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "3",
                Title = "SEA&AIR&INLAND&DEPOT",
                Type = LookupTypes.ModeType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "4",
                Title = "AIR&INLAND",
                Type = LookupTypes.ModeType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "5",
                Title = "INLAND&DEPOT",
                Type = LookupTypes.ModeType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "6",
                Title = "SEA&DEPOT",
                Type = LookupTypes.ModeType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "7",
                Title = "SEA",
                Type = LookupTypes.ModeType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "8",
                Title = "AIR",
                Type = LookupTypes.ModeType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "8",
                Title = "SEA&AIR&INLAND",
                Type = LookupTypes.ModeType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "9",
                Title = "EXPRESS",
                Type = LookupTypes.ModeType
            });

            #endregion

            #region Zones

            db.Lookups.Add(new Lookup()
            {
                Code = "1",
                Title = "AFRICA",
                Type = LookupTypes.ZoneType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "2",
                Title = "Central America",
                Type = LookupTypes.ZoneType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "3",
                Title = "Oceania",
                Type = LookupTypes.ZoneType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "4",
                Title = "South Asia",
                Type = LookupTypes.ZoneType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "5",
                Title = "EUROPE",
                Type = LookupTypes.ZoneType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "6",
                Title = "MIDDLE EAST",
                Type = LookupTypes.ZoneType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "7",
                Title = "North Asia",
                Type = LookupTypes.ZoneType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "8",
                Title = "North America",
                Type = LookupTypes.ZoneType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "9",
                Title = "South America",
                Type = LookupTypes.ZoneType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "10",
                Title = "ASIA",
                Type = LookupTypes.ZoneType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "11",
                Title = "OTHERS",
                Type = LookupTypes.ZoneType
            });

            #endregion

            #region Nationality
            db.Lookups.Add(new Lookup()
            {
                Code = "1",
                Title = "ARMENIA",
                Type = LookupTypes.NationalityType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "2",
                Title = "ARUBA",
                Type = LookupTypes.NationalityType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "3",
                Title = "AUSTRIA",
                Type = LookupTypes.NationalityType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "4",
                Title = "AZERBAIJAN",
                Type = LookupTypes.NationalityType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "5",
                Title = "BAHAMAS",
                Type = LookupTypes.NationalityType
            });
            #endregion

            #region MblType
            db.Lookups.Add(new Lookup()
            {
                Code = "1",
                Title = "COPY",
                Type = LookupTypes.MblType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "2",
                Title = "ORIGINAL",
                Type = LookupTypes.MblType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "3",
                Title = "SEAWAY B/L",
                Type = LookupTypes.MblType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "4",
                Title = "SURRENDERED",
                Type = LookupTypes.MblType
            });
            #endregion

            #region Vessel Type
            db.Lookups.Add(new Lookup()
            {
                Code = "1",
                Title = "BANI BHUM V.773S",
                Type = LookupTypes.VesselType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "2",
                Title = "EVER POWER V.0112-234S",
                Type = LookupTypes.VesselType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "3",
                Title = "HANSA HOMBURG V.163S",
                Type = LookupTypes.VesselType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "4",
                Title = "HEUNG-A JANICE V. 0072N",
                Type = LookupTypes.VesselType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "5",
                Title = "LEDA TRADER V.0021N",
                Type = LookupTypes.VesselType
            });
            #endregion

            #region Freight
            db.Lookups.Add(new Lookup()
            {
                Code = "1",
                Title = "COLLECT",
                Type = LookupTypes.FreightType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "1",
                Title = "PREPAID",
                Type = LookupTypes.FreightType
            });
            #endregion
            #region Voyage
            db.Lookups.Add(new Lookup()
            {
                Code = "1",
                Title = "0020S",
                Type = LookupTypes.VoyageType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "2",
                Title = "17004S",
                Type = LookupTypes.VoyageType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "3",
                Title = "17006S",
                Type = LookupTypes.VoyageType
            });
            #endregion

            #region Locations
            db.Lookups.Add(new Lookup()
            {
                Code = "domestic",
                Title = "Domestic",
                Type = LookupTypes.LocationType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "overseas",
                Title = "Overseas",
                Type = LookupTypes.LocationType
            });

            #endregion

            #region Categories
            db.Lookups.Add(new Lookup()
            {
                Code = "agent-domestic",
                Title = "AGENT - DOMESTIC",
                Type = LookupTypes.CategoryType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "agent-overseas",
                Title = "AGENT - OVERSEAS",
                Type = LookupTypes.CategoryType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "co-loader",
                Title = "CO-LOADER",
                Type = LookupTypes.CategoryType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "direct-consignee",
                Title = "DIRECT CONSIGNEE",
                Type = LookupTypes.CategoryType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "direct-customer",
                Title = "DIRECT CUSTOMER",
                Type = LookupTypes.CategoryType
            });
            db.Lookups.Add(new Lookup()
            {
                Code = "direct-shipper",
                Title = "DIRECT SHIPPER",
                Type = LookupTypes.CategoryType
            });
            #endregion
            await db.SaveChangesAsync();
        }


        #endregion

    }
}

