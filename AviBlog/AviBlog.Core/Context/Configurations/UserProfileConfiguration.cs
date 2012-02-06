using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using AviBlog.Core.Entities;

namespace AviBlog.Core.Context.Configurations
{
    public class UserProfileConfiguration :EntityTypeConfiguration<UserProfile>
    {
        public UserProfileConfiguration()
        {
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Email).HasMaxLength(100);
            Property(x => x.FirstName).HasMaxLength(100);
            Property(x => x.LastName).HasMaxLength(100);
            Property(x => x.Password).HasMaxLength(500);
        }
    }
}