using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using Model;

namespace ModelMapper
{
    public class CustomerMapper:EntityTypeConfiguration<Customer>
    {
        public CustomerMapper()
        {
            this.ToTable("Customers");
            this.HasKey(e => e.CustomerId);
            this.HasRequired(e => e.Catalog).WithMany(t => t.Customers).HasForeignKey(s => s.CatalogId);
            //this.HasMany(e => e.Contacters)
            //    .WithRequired(t => t.Customer);
            //  this.has

            this.Property(e => e.CustomerId).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(e => e.Address).IsOptional().HasMaxLength(150).IsUnicode();
            this.Property(e => e.Credit).IsRequired();
            this.Property(e => e.Description).IsOptional().HasMaxLength(1000).IsUnicode();
            this.Property(e => e.Name).IsRequired().HasMaxLength(100).IsUnicode();
            
        }
    }
}
