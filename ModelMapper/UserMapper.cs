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
    public class UserMapper:EntityTypeConfiguration<User>
    {
        public UserMapper()
        {
            this.ToTable("Users");
            this.HasKey(e => e.UserId);

            this.Property(e => e.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(e => e.UserName).IsRequired().HasMaxLength(255).IsUnicode();
            this.Property(e => e.Password).IsRequired().HasMaxLength(20).IsUnicode();
            this.Property(e => e.IsAdmin).IsRequired();
        }
    }
}
