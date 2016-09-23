namespace ERP
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Tab_Credit> Tab_Credit { get; set; }
        public virtual DbSet<Tab_CustomerCatalog> Tab_CustomerCatalog { get; set; }
        public virtual DbSet<Tab_CustomerContacts> Tab_CustomerContacts { get; set; }
        public virtual DbSet<Tab_Customers> Tab_Customers { get; set; }
        public virtual DbSet<Tab_Orders> Tab_Orders { get; set; }
        public virtual DbSet<Tab_Products> Tab_Products { get; set; }
        public virtual DbSet<Tab_SysUsers> Tab_SysUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tab_Credit>()
                .HasMany(e => e.Tab_CustomerContacts)
                .WithRequired(e => e.Tab_Credit)
                .HasForeignKey(e => e.FK_Credit)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tab_CustomerCatalog>()
                .HasMany(e => e.Tab_Customers)
                .WithRequired(e => e.Tab_CustomerCatalog)
                .HasForeignKey(e => e.FK_CustomerCatalog)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tab_CustomerContacts>()
                .HasMany(e => e.Tab_Orders)
                .WithRequired(e => e.Tab_CustomerContacts)
                .HasForeignKey(e => e.FK_CustomerContact)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tab_Customers>()
                .HasMany(e => e.Tab_CustomerContacts)
                .WithRequired(e => e.Tab_Customers)
                .HasForeignKey(e => e.FK_Customer_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tab_Customers>()
                .HasMany(e => e.Tab_Orders)
                .WithRequired(e => e.Tab_Customers)
                .HasForeignKey(e => e.FK_Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tab_Products>()
                .HasMany(e => e.Tab_Orders)
                .WithRequired(e => e.Tab_Products)
                .HasForeignKey(e => e.FK_Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tab_SysUsers>()
                .Property(e => e.UserName)
                .IsFixedLength();

            modelBuilder.Entity<Tab_SysUsers>()
                .Property(e => e.Password)
                .IsFixedLength();
        }
    }
}
