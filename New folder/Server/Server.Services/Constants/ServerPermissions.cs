using System.Collections.Generic;

namespace Vino.Server.Services.Constants
{
    public sealed class ServerPermissions
    {
        #region Admin
        public const string Admin = "Admin";
        public const string Operator = "Operator";
        public const string Manager = "Manager";
        public const string Employee = "Employee";
        public const string ProducingManager = "ProducingManager";
        public const string ProducingStaff = "ProducingStaff";
        public const string SalesManager = "SalesManager";
        public const string SalesStaff = "SalesStaff";
        public const string StorageManager = "StorageManager";
        public const string StorageStaff = "StorageStaff";
        public const string ResearchingManager = "ResearchingManager";
        public const string ResearchingStaff = "ResearchingStaff";
        public const string AccountingManager = "AccountingManager";
        public const string AccountingStaff = "AccountingStaff";
        //admin area permissions
        public const string AccessAdminPanel = "AccessAdminPanel";
        public const string ManageFalconUsers = "ManageFalconUsers";
        public const string ManageExaminationProcedure = "ManageExaminationProcedure";
        public const string ManageMessageTemplates = "ManageMessageTemplates";
        public const string ManageSettings = "ManageSettings";
        public const string ManageActivityLog = "ManageActivityLog";
        public const string ManageEmailAccounts = "ManageEmailAccounts";
        public const string ManageSystemLog = "ManageSystemLog";
        public const string ManageMessageQueue = "ManageMessageQueue";
        public const string ManageMaintenance = "ManageMaintenance";
        public const string ManageScheduleTasks = "ManageScheduleTasks";
        public const string ManageHospital = "ManageHospital";
        public const string ManageRole = "ManageRole";
        public const string ManageLookup = "ManageLookup";
        public const string ManageUserHospital = "ManageUserHospital";
        public const string ManageCategory = "ManageCategory";
        public const string ManageOrder = "ManageOrder";
        public const string ManageSensorType = "ManageSensorType";
        public const string ManageDevice = "ManageDevice";
        public const string ManageDeviceSeri = "ManageDeviceSeri";
        public const string ManageCalendar = "ManageCalendar";
        public const string ManageFact = "ManageFact";
        public const string ManageAction = "ManageAction";
        public const string ManageActionFact = "ManageActionFact";
        public const string ManageFactSensor = "ManageFactSensor";
        public const string ManageProvince = "ManageProvince";
        public const string ManageGateway = "ManageGateway";
        public const string ManageNewsFeed = "ManageNewsFeed";
        public const string ManageMessage = "ManageMessage";
        public const string ManageQuestion = "ManageQuestion";
        public const string ManageTopic = "ManageTopic";
        public const string ManageContact = "ManageContact";
        public const string ManageWaitingRegister = "ManageWaitingRegister";
        public const string ManageSubscription = "ManageSubscription";
        public const string ManageSupplier = "ManageSupplier";
        public const string ManageWarehouse = "ManageWarehouse";
        public const string ManageGrowingZone = "ManageGrowingZone";
        public const string ManageBreed = "ManageBreed";
        public const string ManageCustomer = "ManageCustomer";

        public const string ManageNews = "ManageNews";
        public const string ManageFeedback = "ManageFeedback";
        public const string ManageMap = "ManageMap";
        public const string ManageRoom = "ManageRoom";
        public const string ManageShift = "ManageShift";
        public const string ManageProduct = "ManageProduct";
        public const string ManageMasterItem = "ManageMasterItem";
        public const string ManageReserved = "ManageReserved";
        public const string ManageEmployee = "ManageEmployee";
        public const string ManageCalendarException = "ManageCalendarException";

        public const string ManageNewsHospital = "ManageNewsHospital";
        public const string ManageFeedbackHospital = "ManageFeedbackHospital";
        public const string ManageMapHospital = "ManageMapHospital";
        public const string ManageExaminationProcedureHospital = "ManageExaminationProcedureHospital";
        public const string ManageRoomHospital = "ManageRoomHospital";
        public const string ManageShiftHospital = "ManageShiftHospital";
        public const string ManageProductHospital = "ManageProductHospital";
        public const string ManageMasterItemHospital = "ManageMasterItemHospital";
        public const string ManageReservedHospital = "ManageReservedHospital";
        public const string ManageCalendarExceptionHospital = "ManageCalendarExceptionHospital";
        public const string ManageOperator = "ManageOperator";




        #endregion
        public static List<KeyValuePair<string, string>> DefaultClaims => new List<KeyValuePair<string, string>>()
        {
            //web admin
            new KeyValuePair<string,string>(Admin,ServerPermissions.AccessAdminPanel),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageFalconUsers),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageExaminationProcedure),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageMessageTemplates),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageSettings),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageActivityLog),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageSystemLog),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageMessageQueue),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageMaintenance),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageNews),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageHospital),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageFeedback),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageRole),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageLookup),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageRoom),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageShift),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageProduct),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageMasterItem),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageMap),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageFeedback),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageUserHospital),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageReserved),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageEmployee),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageCalendarException),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageCategory),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageOrder),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageSensorType),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageDevice),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageDeviceSeri),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageCalendar),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageFact),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageAction),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageActionFact),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageFactSensor),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageProvince),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageGateway),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageNewsFeed),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageMessage),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageQuestion),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageTopic),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageContact),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageWaitingRegister),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageSubscription),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageSupplier),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageWarehouse),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageGrowingZone),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageBreed),
            new KeyValuePair<string,string>(Admin,ServerPermissions.ManageCustomer),

            new KeyValuePair<string,string>(Manager,ServerPermissions.AccessAdminPanel),
            //new KeyValuePair<string,string>(Manager,ServerPermissions.ManageExaminationProcedureHospital),
            //new KeyValuePair<string,string>(Manager,ServerPermissions.ManageRoomHospital),
            //new KeyValuePair<string,string>(Manager,ServerPermissions.ManageShiftHospital),
            //new KeyValuePair<string,string>(Manager,ServerPermissions.ManageProductHospital),
            //new KeyValuePair<string,string>(Manager,ServerPermissions.ManageMasterItemHospital),
            //new KeyValuePair<string,string>(Manager,ServerPermissions.ManageMapHospital),
            //new KeyValuePair<string,string>(Manager,ServerPermissions.ManageFeedbackHospital),
            //new KeyValuePair<string,string>(Manager,ServerPermissions.ManageNewsHospital),
            //new KeyValuePair<string,string>(Manager,ServerPermissions.ManageReservedHospital),
            //new KeyValuePair<string,string>(Manager,ServerPermissions.ManageCalendarExceptionHospital), 
            //new KeyValuePair<string,string>(Manager,ServerPermissions.ManageOperator),
            new KeyValuePair<string,string>(Manager,ServerPermissions.ManageCategory),
            new KeyValuePair<string,string>(Manager,ServerPermissions.ManageProduct),
            new KeyValuePair<string,string>(Manager,ServerPermissions.ManageOrder),
            new KeyValuePair<string,string>(Manager,ServerPermissions.ManageNewsFeed),
            new KeyValuePair<string,string>(Manager,ServerPermissions.ManageNews),
            new KeyValuePair<string,string>(Manager,ServerPermissions.ManageTopic),
            new KeyValuePair<string,string>(Manager,ServerPermissions.ManageContact),
            new KeyValuePair<string,string>(Manager,ServerPermissions.ManageEmployee),

            new KeyValuePair<string,string>(Operator,ServerPermissions.AccessAdminPanel),
            //new KeyValuePair<string,string>(Operator,ServerPermissions.ManageReservedHospital),

            new KeyValuePair<string,string>(ProducingStaff,ServerPermissions.AccessAdminPanel),
            
        };
    }
}

