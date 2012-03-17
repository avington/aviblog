using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using AviBlog.Core.Entities;

namespace AviBlog.Core.Context.Configurations
{
    public class StopWordConfiguration : EntityTypeConfiguration<StopWord>
    {
        public StopWordConfiguration()
        {
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Word).HasMaxLength(50);
        }
    }
}