namespace AviBlog.Core.Context.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using AviBlog.Core.Entities;

    public class UserProfileConfiguration : EntityTypeConfiguration<UserProfile>
    {
        #region Constructors and Destructors

        public UserProfileConfiguration()
        {
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Email).HasMaxLength(100);
            Property(x => x.FirstName).HasMaxLength(100);
            Property(x => x.LastName).HasMaxLength(100);
            Property(x => x.Password).HasMaxLength(500);
        }

        #endregion
    }
}