namespace AviBlog.Core.Context.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using AviBlog.Core.Entities;

    public class TrackbackConfiguration : EntityTypeConfiguration<Trackback>
    {
        #region Constructors and Destructors

        public TrackbackConfiguration()
        {
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Url).IsRequired();
            Property(x => x.Url).HasMaxLength(500);
        }

        #endregion
    }
}