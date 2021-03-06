﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Falcon.Web.Core.Auth;
using Falcon.Web.Core.Message;
using Falcon.Web.Core.Settings;
using Vino.Server.Data.Common;
using Vino.Server.Data.CRM;
using Vino.Server.Data.Framework;
using Vino.Server.Data.HR;
using Vino.Server.Services.Helper;

namespace Vino.Server.Services.Database
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DataContext")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region CRM

            #region AirExp
            modelBuilder.Entity<AirExp>().HasRequired(aa => aa.OriginPort)
                .WithMany(m => m.OriginPorts)
                .HasForeignKey(m => m.OriginPortId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AirExp>().HasRequired(aa => aa.TransitPort)
                .WithMany(m => m.TransitPorts)
                .HasForeignKey(m => m.TransitPortId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AirExp>().HasRequired(aa => aa.Destination)
                .WithMany(m => m.Destinations)
                .HasForeignKey(m => m.DestinationId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AirExp>().HasRequired(aa => aa.Carrier)
                .WithMany(m => m.Carriers)
                .HasForeignKey(m => m.CarrierId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AirExp>().HasRequired(aa => aa.Agent)
                .WithMany(m => m.Agents)
                .HasForeignKey(m => m.AgentId)
                .WillCascadeOnDelete(false);

            #endregion

            #region FclExp
            modelBuilder.Entity<FclExp>().HasRequired(aa => aa.Pol)
                .WithMany(m => m.FclExpPols)
                .HasForeignKey(m => m.PolId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FclExp>().HasRequired(aa => aa.Pod)
                .WithMany(m => m.FclExpPods)
                .HasForeignKey(m => m.PodId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FclExp>().HasRequired(aa => aa.SLines)
                .WithMany(m => m.FclExpSlines)
                .HasForeignKey(m => m.SlinesId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FclExp>().HasRequired(aa => aa.Agent)
                .WithMany(m => m.FclExpAgents)
                .HasForeignKey(m => m.AgentId)
                .WillCascadeOnDelete(false);

            #endregion

            #region LclExp
            modelBuilder.Entity<LclExp>().HasRequired(aa => aa.Pol)
                .WithMany(m => m.LclExpPols)
                .HasForeignKey(m => m.PolId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LclExp>().HasRequired(aa => aa.Pod)
                .WithMany(m => m.LclExpPods)
                .HasForeignKey(m => m.PodId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LclExp>().HasRequired(aa => aa.Agent)
                .WithMany(m => m.LclExpAgents)
                .HasForeignKey(m => m.AgentId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LclExp>().HasRequired(aa => aa.CoLoader)
                .WithMany(m => m.LclExpCoLoaders)
                .HasForeignKey(m => m.CoLoaderId)
                .WillCascadeOnDelete(false);
            #endregion

            #region AirImp
            modelBuilder.Entity<AirImp>().HasRequired(aa => aa.Aol)
                .WithMany(m => m.AirAols)
                .HasForeignKey(m => m.AolId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AirImp>().HasRequired(aa => aa.Aod)
                .WithMany(m => m.AirAods)
                .HasForeignKey(m => m.AodId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AirImp>().HasRequired(aa => aa.Delivery)
                .WithMany(m => m.AirDeliveries)
                .HasForeignKey(m => m.DeliveryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AirImp>().HasRequired(aa => aa.Airlines)
                .WithMany(m => m.AirImpAirlines)
                .HasForeignKey(m => m.AirlineId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AirImp>().HasRequired(aa => aa.Agent)
                .WithMany(m => m.AirImpAgents)
                .HasForeignKey(m => m.AgentId)
                .WillCascadeOnDelete(false);

            #endregion

            #region FclImp
            modelBuilder.Entity<FclImp>().HasRequired(aa => aa.Agent)
                .WithMany(m => m.FclImpAgents)
                .HasForeignKey(m => m.AgentId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FclImp>().HasRequired(aa => aa.SLines)
                .WithMany(m => m.FclImpSlines)
                .HasForeignKey(m => m.SlinesId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FclImp>().HasRequired(aa => aa.Pol)
                .WithMany(m => m.FclImpPols)
                .HasForeignKey(m => m.PolId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FclImp>().HasRequired(aa => aa.Pod)
                .WithMany(m => m.FclImpPods)
                .HasForeignKey(m => m.PodId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FclImp>().HasRequired(aa => aa.Delivery)
                .WithMany(m => m.FclImpDeliveries)
                .HasForeignKey(m => m.DeliveryId)
                .WillCascadeOnDelete(false);
            #endregion

            #region LclImp
            modelBuilder.Entity<LclImp>().HasRequired(aa => aa.Pol)
                .WithMany(m => m.LclImpPols)
                .HasForeignKey(m => m.PolId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<LclImp>().HasRequired(aa => aa.Pod)
                .WithMany(m => m.LclImpPods)
                .HasForeignKey(m => m.PodId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LclImp>().HasRequired(aa => aa.Delivery)
                .WithMany(m => m.LclImpDeliveries)
                .HasForeignKey(m => m.DeliveryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LclImp>().HasRequired(aa => aa.SLines)
                .WithMany(m => m.LclImpSlines)
                .HasForeignKey(m => m.SlinesId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LclImp>().HasRequired(aa => aa.Agent)
                .WithMany(m => m.LclImpAgents)
                .HasForeignKey(m => m.AgentId)
                .WillCascadeOnDelete(false);


            #endregion

            #region Customer
            modelBuilder.Entity<CrmCustomer>().HasRequired(aa => aa.Location)
                .WithMany(m => m.Locations)
                .HasForeignKey(m => m.LocationId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CrmCustomer>().HasRequired(aa => aa.Category)
                .WithMany(m => m.Categories)
                .HasForeignKey(m => m.CategoryId)
                .WillCascadeOnDelete(false);

           
            #endregion

            #region HBL Lcl

            // port
            modelBuilder.Entity<HblLclExp>().HasRequired(aa => aa.Shipper)
                .WithMany(m => m.Shippers)
                .HasForeignKey(m => m.ShipperId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<HblLclExp>().HasRequired(aa => aa.Consignee)
                .WithMany(m => m.Consignees)
                .HasForeignKey(m => m.ConsigneeId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<HblLclExp>().HasRequired(aa => aa.NotifyParty)
                .WithMany(m => m.NotifyParties)
                .HasForeignKey(m => m.NotifyPartyId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<HblLclExp>().HasRequired(aa => aa.DeliveryOfGoods)
                .WithMany(m => m.DeliveryOfGoods)
                .HasForeignKey(m => m.DeliveryOfGoodsId)
                .WillCascadeOnDelete(false);

            // port
            modelBuilder.Entity<HblLclExp>().HasRequired(aa => aa.PlaceOfReceipt)
                .WithMany(m => m.PlaceOfReceipts)
                .HasForeignKey(m => m.PlaceOfReceiptId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HblLclExp>().HasRequired(aa => aa.PortOfLoaing)
                .WithMany(m => m.PortOfLoaings)
                .HasForeignKey(m => m.PortOfLoaingId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HblLclExp>().HasRequired(aa => aa.PortOfDischarge)
                .WithMany(m => m.PortOfDischarges)
                .HasForeignKey(m => m.PortOfDischargeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HblLclExp>().HasRequired(aa => aa.TranshipmentPort)
                .WithMany(m => m.TranshipmentPorts)
                .HasForeignKey(m => m.TranshipmentPortId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HblLclExp>().HasRequired(aa => aa.FinalDestination)
                .WithMany(m => m.FinalDestinations)
                .HasForeignKey(m => m.FinalDestinationId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HblLclExp>().HasRequired(aa => aa.PlaceOfDelivery)
                .WithMany(m => m.PlaceOfDeliveries)
                .HasForeignKey(m => m.PlaceOfDeliveryId)
                .WillCascadeOnDelete(false);

            #endregion

            #region HBL Fcl

            // Customer
            modelBuilder.Entity<HblFclExp>().HasRequired(aa => aa.Shipper)
                .WithMany(m => m.FclShippers)
                .HasForeignKey(m => m.ShipperId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<HblFclExp>().HasRequired(aa => aa.Consignee)
                .WithMany(m => m.FclConsignees)
                .HasForeignKey(m => m.ConsigneeId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<HblFclExp>().HasRequired(aa => aa.NotifyParty)
                .WithMany(m => m.FclNotifyParties)
                .HasForeignKey(m => m.NotifyPartyId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<HblFclExp>().HasRequired(aa => aa.DeliveryOfGoods)
                .WithMany(m => m.FclDeliveryOfGoods)
                .HasForeignKey(m => m.DeliveryOfGoodsId)
                .WillCascadeOnDelete(false);

            // port
            modelBuilder.Entity<HblFclExp>().HasRequired(aa => aa.PlaceOfReceipt)
                .WithMany(m => m.FclPlaceOfReceipts)
                .HasForeignKey(m => m.PlaceOfReceiptId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HblFclExp>().HasRequired(aa => aa.PortOfLoaing)
                .WithMany(m => m.FclPortOfLoaings)
                .HasForeignKey(m => m.PortOfLoaingId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HblFclExp>().HasRequired(aa => aa.PortOfDischarge)
                .WithMany(m => m.FclPortOfDischarges)
                .HasForeignKey(m => m.PortOfDischargeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HblFclExp>().HasRequired(aa => aa.TranshipmentPort)
                .WithMany(m => m.FclTranshipmentPorts)
                .HasForeignKey(m => m.TranshipmentPortId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HblFclExp>().HasRequired(aa => aa.FinalDestination)
                .WithMany(m => m.FclFinalDestinations)
                .HasForeignKey(m => m.FinalDestinationId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HblFclExp>().HasRequired(aa => aa.PlaceOfDelivery)
                .WithMany(m => m.FclPlaceOfDeliveries)
                .HasForeignKey(m => m.PlaceOfDeliveryId)
                .WillCascadeOnDelete(false);

            #endregion

            #region FclExp Si

            // port
            modelBuilder.Entity<LclExpSi>().HasRequired(aa => aa.PortOfLoading)
                .WithMany(m => m.LclExpSiPortOfLoading)
                .HasForeignKey(m => m.PortofLoadingId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LclExpSi>().HasRequired(aa => aa.PortOfDischarge)
                .WithMany(m => m.LclExpSiPortOfDischarge)
                .HasForeignKey(m => m.PortofLoadingId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LclExpSi>().HasRequired(aa => aa.PlaceOfDelivery)
                .WithMany(m => m.LclExpSiPlaceOfDelivery)
                .HasForeignKey(m => m.PlaceOfDeliveryId)
                .WillCascadeOnDelete(false);

            #endregion

            #endregion

        }

        #region Datasets
        //framework
        public DbSet<Log> Logs { get; set; }
        public DbSet<LoginToken> LoginTokens { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<QueuedEmail> QueuedEmails { get; set; }

        //HR
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeData> EmployeeData { get; set; }

        #region CRM
        public DbSet<AirExp> AirExps{ get; set; }
        public DbSet<Carrier> Carriers{ get; set; }
        public DbSet<Data.CRM.CrmContact> CrmContacts { get; set; }
        public DbSet<Port> Ports{ get; set; }
        public DbSet<FclExp> FclExps{ get; set; }
        public DbSet<LclExp> LclExps { get; set; }
        public DbSet<AirImp> AirImps{ get; set; }
        public DbSet<FclImp> FclImps{ get; set; }
        public DbSet<LclImp> LclImps{ get; set; }
        public DbSet<CrmCustomer> Customers { get; set; }
        public DbSet<HblLclExp> HblLclExps { get; set; }
        public DbSet<HblFclExp> HblFclExps { get; set; }

        public DbSet<Topic> Topics{ get; set; }
        public DbSet<Container> Containers { get; set; }
        public DbSet<LclExpSi> LclExpSis { get; set; }


        #endregion
        //common
        public DbSet<OrderGenCode> OrderGenCodes { get; set; }

        public DbSet<Lookup> Lookups { get; set; }
        public DbSet<ImageRecord> ImageRecords { get; set; }
        public DbSet<EmailAccount> EmailAccounts { get; set; }
        public DbSet<MessageTemplate> MessageTemplates { get; set; }

        #endregion

        
    }
}