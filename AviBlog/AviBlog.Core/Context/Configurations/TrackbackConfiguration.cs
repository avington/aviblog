using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using AviBlog.Core.Entities;

namespace AviBlog.Core.Context.Configurations
{
    public class TrackbackConfiguration :EntityTypeConfiguration<Trackback>
    {
        public TrackbackConfiguration()
        {
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Url).IsRequired();
            Property(x => x.Url).HasMaxLength(500);
        }
    }
}