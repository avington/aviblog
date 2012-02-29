using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using AviBlog.Core.Entities;

namespace AviBlog.Core.Context.Configurations
{
    public class SettingsConfiguration : EntityTypeConfiguration<Setting>
    {
        public SettingsConfiguration()
        {
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Key).HasMaxLength(100);
        }
    }
}