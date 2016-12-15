using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Model;
using ModelMapper;
using System.Data.Entity.Migrations;

namespace DBContext
{
    public class DataContext:DbContext
    {
        public DataContext():base("ERPDB")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, DataContextMigrationConfiguration>());
        }
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Contacter> Contacters { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CatalogMapper());
            modelBuilder.Configurations.Add(new ContactorMapper());
            modelBuilder.Configurations.Add(new CustomerMapper());
            modelBuilder.Configurations.Add(new OrderMapper());
            modelBuilder.Configurations.Add(new ProductMapper());
            modelBuilder.Configurations.Add(new UserMapper());
            base.OnModelCreating(modelBuilder);
        }
    }
    public class DataContextMigrationConfiguration:DbMigrationsConfiguration<DataContext>
    {
        public DataContextMigrationConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }
        protected override void Seed(DataContext context)
        {
            new DataContextSeed(context).Seed();
           // base.Seed(context);
        }
    }
}
