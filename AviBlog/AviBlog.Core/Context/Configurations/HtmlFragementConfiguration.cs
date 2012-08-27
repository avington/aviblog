namespace AviBlog.Core.Context.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using AviBlog.Core.Entities;

    public class HtmlFragementConfiguration : EntityTypeConfiguration<HtmlFragment>
    {
        #region Constructors and Destructors

        public HtmlFragementConfiguration()
        {
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ScriptBody).IsRequired();
        }

        #endregion
    }
}