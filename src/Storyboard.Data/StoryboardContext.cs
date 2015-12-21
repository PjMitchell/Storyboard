using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Storyboard.Data.DbObject;

namespace Storyboard.Data
{
    public class StoryboardContext : DbContext
    {
        public StoryboardContext() { }

        public StoryboardContext(DbContextOptions options) : base(options){ }

        public DbSet<ActorTableRow> Actor { get; set; }
        public DbSet<StoryTableRow> Story { get; set; }
        public DbSet<LinkTableRow> Link { get; set; }
        public DbSet<StorySectionTableRow> StorySection { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorTableRow>().ToTable(nameof(Actor), DbSchemas.Story);
            modelBuilder.Entity<ActorTableRow>().HasKey(r=> r.Id);
            modelBuilder.Entity<ActorTableRow>().Property(r => r.Id).UseSqlServerIdentityColumn();

            modelBuilder.Entity<StoryTableRow>().ToTable(nameof(Story), DbSchemas.Story);
            modelBuilder.Entity<StoryTableRow>().HasKey(r => r.Id);
            modelBuilder.Entity<StoryTableRow>().Property(r => r.Id).UseSqlServerIdentityColumn();

            modelBuilder.Entity<LinkTableRow>().ToTable(nameof(Link), DbSchemas.Story);
            modelBuilder.Entity<LinkTableRow>().HasKey(r => r.Id);
            modelBuilder.Entity<LinkTableRow>().Property(r => r.Id).UseSqlServerIdentityColumn();

            modelBuilder.Entity<StorySectionTableRow>().ToTable(nameof(StorySection), DbSchemas.Story); ;
            modelBuilder.Entity<StorySectionTableRow>().HasKey(r=> r.Id);
            modelBuilder.Entity<StorySectionTableRow>().Property(r => r.Id).UseSqlServerIdentityColumn();
        }

    }
}
