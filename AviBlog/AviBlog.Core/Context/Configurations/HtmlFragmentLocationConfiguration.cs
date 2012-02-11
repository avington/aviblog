using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using AviBlog.Core.Entities;

namespace AviBlog.Core.Context.Configurations
{
    public class HtmlFragmentLocationConfiguration : EntityTypeConfiguration<HtmlFragmentLocation>
    {
        public HtmlFragmentLocationConfiguration()
        {
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.LocationName).IsRequired();
            Property(x => x.LocationName).HasMaxLength(100);
        }
    }
}