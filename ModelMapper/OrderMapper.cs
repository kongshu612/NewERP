using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Model;

namespace ModelMapper
{
    public class OrderMapper:EntityTypeConfiguration<Order>
    {
        public OrderMapper()
        {
            this.ToTable("Orders");
            this.HasKey(e => e.OrderId);
            this.HasRequired(e => e.Contacter).WithMany(t => t.Orders).HasForeignKey(s=>s.ContacterId);
            this.HasRequired(e => e.Product).WithMany(t => t.Orders).HasForeignKey(s=>s.ProductId);
        //    this.HasRequired(e => e.Customer).WithMany(t => t.Orders).HasForeignKey(s => s.CustomerId);           
            this.Property(e => e.OrderId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            this.Property(e => e.Count).IsRequired();
            this.Property(e => e.CreatedTime).IsRequired();
            this.Property(e => e.SentTime).IsOptional();
            this.Property(e => e.Description).IsOptional().HasMaxLength(1000);
            this.Property(e => e.DestinationAddress).IsRequired().HasMaxLength(500);
            this.Property(e => e.ExpressId).IsOptional().HasMaxLength(50);
            this.Property(e => e.IsPayed).IsRequired();
            this.Property(e => e.TotalPrice).IsRequired();
       }
    }
}
