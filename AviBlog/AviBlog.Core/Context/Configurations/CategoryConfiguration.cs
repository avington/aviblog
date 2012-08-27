namespace AviBlog.Core.Context.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using AviBlog.Core.Entities;

    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        #region Constructors and Destructors

        public CategoryConfiguration()
        {
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CategoryName).IsRequired();
            Property(x => x.CategoryName).HasMaxLength(50);
        }

        #endregion
    }
}