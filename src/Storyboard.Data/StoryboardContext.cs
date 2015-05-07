using Microsoft.Data.Entity;
using Storyboard.Data.DbObject;

namespace Storyboard.Data
{
    public class StoryboardContext : DbContext
    {
        public StoryboardContext()
        {

        }

        public DbSet<ActorTableRow> Actor { get; set; }
        public DbSet<StoryTableRow> Story { get; set; }
        public DbSet<LinkTableRow> Link { get; set; }
        public DbSet<StorySectionTableRow> StorySection { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorTableRow>().ForSqlServer().Table("Actor", DbSchemas.Story);
            modelBuilder.Entity<ActorTableRow>().Key(r=> r.Id);

            modelBuilder.Entity<StoryTableRow>().ForSqlServer().Table("Story", DbSchemas.Story);
            modelBuilder.Entity<StoryTableRow>().Key(r => r.Id);

            modelBuilder.Entity<LinkTableRow>().ForSqlServer().Table("Link", DbSchemas.Story);
            modelBuilder.Entity<LinkTableRow>().Key(r => r.Id);

            modelBuilder.Entity<StorySectionTableRow>().ForSqlServer().Table("StorySection", DbSchemas.Story); ;
            modelBuilder.Entity<StorySectionTableRow>().Key(r=> r.Id);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectsV12;Initial Catalog=StoryBoard;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False"); //todo remove this abomination
            base.OnConfiguring(optionsBuilder);
        }
    }
}
