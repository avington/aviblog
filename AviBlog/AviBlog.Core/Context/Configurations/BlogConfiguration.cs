using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using AviBlog.Core.Entities;

namespace AviBlog.Core.Context.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class BlogConfiguration : EntityTypeConfiguration<Blog>
    {
        public BlogConfiguration()
        {
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.BlogName).IsRequired();
            Property(x => x.BlogName).HasMaxLength(200);
        }
    }
}