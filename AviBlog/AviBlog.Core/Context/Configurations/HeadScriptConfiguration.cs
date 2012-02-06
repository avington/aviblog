using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using AviBlog.Core.Entities;

namespace AviBlog.Core.Context.Configurations
{
    public class HeadScriptConfiguration : EntityTypeConfiguration<HeadScript>
    {
        public HeadScriptConfiguration()
        {
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ScriptBody).IsRequired();
        }
    }
}