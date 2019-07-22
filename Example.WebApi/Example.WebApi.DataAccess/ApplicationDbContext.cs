using Example.WebApi.DataAccess.Common;
using Example.WebApi.DataAccess.Model.Database;
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

            #region "Model on Creating"
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
    }
}
