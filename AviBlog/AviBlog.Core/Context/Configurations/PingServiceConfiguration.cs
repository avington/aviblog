namespace AviBlog.Core.Context.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using AviBlog.Core.Entities;

    public class PingServiceConfiguration : EntityTypeConfiguration<PingService>
    {
        #region Constructors and Destructors

        public PingServiceConfiguration()
        {
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.PingUrl).HasMaxLength(200);
        }

        #endregion
    }
}