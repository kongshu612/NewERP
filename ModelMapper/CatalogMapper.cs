using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelMapper
{
    public class CatalogMapper:EntityTypeConfiguration<Catalog>
    {
        public CatalogMapper()
        {
            this.ToTable("Catalogs");
            this.HasKey(e => e.CatalogId);

            this.Property(e => e.CatalogId).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(e => e.CatalogName).IsOptional().HasMaxLength(50);
            this.Property(e => e.Description).IsOptional().HasMaxLength(500);
        //    this.HasMany(e => e.Customers).WithRequired(t => t.Catalog);
        }
    }
}
