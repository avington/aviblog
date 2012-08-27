namespace AviBlog.Core.Context.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using AviBlog.Core.Entities;

    public class TagConfiguration : EntityTypeConfiguration<Tag>
    {
        #region Constructors and Destructors

        public TagConfiguration()
        {
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TagName).HasMaxLength(50);
        }

        #endregion
    }
}