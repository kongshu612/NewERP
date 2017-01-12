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
    public class ContactorMapper:EntityTypeConfiguration<Contacter>
    {
        public ContactorMapper()
        {
            this.ToTable("Contactors");
            this.HasKey(e => e.ContacterId);
            this.HasRequired(e => e.Customer).WithMany(t=>t.Contacters).HasForeignKey(s=>s.CustomerId);
         

            this.Property(e => e.ContacterId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            this.Property(e => e.Name).IsRequired().IsUnicode().HasMaxLength(50);
            this.Property(e => e.Telephones).IsRequired().IsUnicode().HasMaxLength(100);
            this.Property(e => e.CustomerId).IsRequired();
        }
    }
}
