namespace AviBlog.Core.Context.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using AviBlog.Core.Entities;

    public class HtmlFragmentLocationConfiguration : EntityTypeConfiguration<HtmlFragmentLocation>
    {
        #region Constructors and Destructors

        public HtmlFragmentLocationConfiguration()
        {
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.LocationName).IsRequired();
            Property(x => x.LocationName).HasMaxLength(100);
        }

        #endregion
    }
}