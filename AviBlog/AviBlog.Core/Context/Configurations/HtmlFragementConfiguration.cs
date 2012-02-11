using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using AviBlog.Core.Entities;

namespace AviBlog.Core.Context.Configurations
{
    public class HtmlFragementConfiguration : EntityTypeConfiguration<HtmlFragment>
    {
        public HtmlFragementConfiguration()
        {
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ScriptBody).IsRequired();
        }
    }
}