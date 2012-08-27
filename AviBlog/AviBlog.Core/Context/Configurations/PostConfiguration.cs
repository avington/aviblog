namespace AviBlog.Core.Context.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using AviBlog.Core.Entities;

    public class PostConfiguration : EntityTypeConfiguration<Post>
    {
        #region Constructors and Destructors

        public PostConfiguration()
        {
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.PostContent).IsRequired();
            Property(x => x.Title).IsRequired();
            Property(x => x.Title).HasMaxLength(200);
            Property(x => x.Slug).HasMaxLength(500);
        }

        #endregion
    }
}