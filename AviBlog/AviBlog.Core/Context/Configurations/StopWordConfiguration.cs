namespace AviBlog.Core.Context.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using AviBlog.Core.Entities;

    public class StopWordConfiguration : EntityTypeConfiguration<StopWord>
    {
        #region Constructors and Destructors

        public StopWordConfiguration()
        {
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Word).HasMaxLength(50);
        }

        #endregion
    }
}