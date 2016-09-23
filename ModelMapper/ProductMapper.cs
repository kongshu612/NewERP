using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelMapper;
using Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelMapper
{
    public class ProductMapper:EntityTypeConfiguration<Product>
    {
        public ProductMapper()
        {
            this.ToTable("Products");
            this.HasKey(e => e.ProductId);

            this.Property(e => e.ProductId).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(e => e.Name).IsOptional().HasMaxLength(255);
            this.Property(e => e.Size).IsRequired();
            this.Property(e => e.Count).IsOptional();
        }
    }
}
