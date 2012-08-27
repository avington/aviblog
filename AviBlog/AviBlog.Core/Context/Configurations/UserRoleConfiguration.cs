namespace AviBlog.Core.Context.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using AviBlog.Core.Entities;

    public class UserRoleConfiguration : EntityTypeConfiguration<UserRole>
    {
        #region Constructors and Destructors

        public UserRoleConfiguration()
        {
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.RoleName).HasMaxLength(20);
        }

        #endregion
    }
}