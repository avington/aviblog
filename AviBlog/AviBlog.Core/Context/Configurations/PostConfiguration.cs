using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using AviBlog.Core.Entities;

namespace AviBlog.Core.Context.Configurations
{
    public class PostConfiguration : EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.PostContent).IsRequired();
            Property(x => x.Title).IsRequired();
            Property(x => x.Title).HasMaxLength(200);
            Property(x => x.Slug).HasMaxLength(500);
        }
    }
}