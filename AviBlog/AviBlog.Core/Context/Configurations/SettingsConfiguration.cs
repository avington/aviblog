namespace AviBlog.Core.Context.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using AviBlog.Core.Entities;

    public class SettingsConfiguration : EntityTypeConfiguration<Setting>
    {
        #region Constructors and Destructors

        public SettingsConfiguration()
        {
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Key).HasMaxLength(100);
        }

        #endregion
    }
}