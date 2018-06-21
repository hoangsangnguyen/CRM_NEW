using System.Data.Entity;
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

        #endregion
        //common
        public DbSet<Lookup> Lookups { get; set; }
        public DbSet<ImageRecord> ImageRecords { get; set; }
        public DbSet<EmailAccount> EmailAccounts { get; set; }
        public DbSet<MessageTemplate> MessageTemplates { get; set; }

        #endregion

        
    }
}