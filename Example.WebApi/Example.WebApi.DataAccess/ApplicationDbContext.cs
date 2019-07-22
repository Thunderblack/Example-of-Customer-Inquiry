using Example.WebApi.DataAccess.Common;
using Example.WebApi.DataAccess.Model.Database;
using Example.WebApi.DataAccess.Model.Database.Master;
using Example.WebApi.DataAccess.Model.Database.Operation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example.WebApi.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public string _userName;
        public ApplicationDbContext()
        {
            // Open Package Manager Console
            // enable-migrations
            // add-migration Initial
            // update-database -StartUpProjectName IT1.DAC

            // Update new table. Using following command.
            // add-migration Initial
            // update-database -TargetMigration: 0
            // update-database
            _userName = "Anonymous";
        }

        public ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string cn = AppConfig.DbConnection;
            optionsBuilder.UseSqlServer(cn);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region "Initial seed data"
            Seed process = new Seed(modelBuilder);
            process.InitialCustomerStatus();
            process.InitialTransactionsStatus();
            #endregion "Initial seed data"

            #region "Model on Creating"
            modelBuilder.Entity<Customers>(entity => {
                entity.HasIndex(x => x.email).IsUnique();
            });
            #endregion "Model on Creating"
        }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries().Where(x => (x.Entity is LogTimeStamp) && (x.State == EntityState.Added || x.State == EntityState.Modified));

            var currentUsername = _userName;

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((LogTimeStamp)entity.Entity).CreatedDate = DateTime.Now;
                    ((LogTimeStamp)entity.Entity).CreatedBy = currentUsername;
                }
                if (entity.State == EntityState.Modified)
                {
                    ((LogTimeStamp)entity.Entity).UpdatedDate = DateTime.Now;
                    ((LogTimeStamp)entity.Entity).UpdatedBy = currentUsername;
                }
            }
        }

        #region "Add Master Table"
        public virtual DbSet<CustomerStatus> CustomerStatuses { get; set; }
        public virtual DbSet<TransactionsStatus> TransactionStatuses { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        #endregion "Add Master Table"

        #region "Add Transaction Table"
        public virtual DbSet<Transactions> Transactionses { get; set; }
        #endregion "Add Transaction Table"
    }
}
