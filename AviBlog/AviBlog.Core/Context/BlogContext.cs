using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using AviBlog.Core.Context.Configurations;
using AviBlog.Core.Entities;

namespace AviBlog.Core.Context
{
    public class BlogContext : DbContext, IDbConnectionFactory
    {
        protected BlogContext()
        {
        }

        public BlogContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<HtmlFragment> HtmlFragments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Trackback> Trackbacks { get; set; }
        public DbSet<HtmlFragmentLocation> HtmlFragmentLocations { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<PingService> PingServices { get; set; }
        public DbSet<StopWord> StopWords { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PostConfiguration());
            modelBuilder.Configurations.Add(new BlogConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new HtmlFragementConfiguration());
            modelBuilder.Configurations.Add(new TagConfiguration());
            modelBuilder.Configurations.Add(new UserProfileConfiguration());
            modelBuilder.Configurations.Add(new UserRoleConfiguration());
            modelBuilder.Configurations.Add(new TrackbackConfiguration());
            modelBuilder.Configurations.Add(new HtmlFragmentLocationConfiguration());
            modelBuilder.Configurations.Add(new SettingsConfiguration());
            modelBuilder.Configurations.Add(new PingServiceConfiguration());
            modelBuilder.Configurations.Add(new StopWordConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbConnection CreateConnection(string nameOrConnectionString)
        {
            return new SqlConnection(nameOrConnectionString);
        }
    }
}