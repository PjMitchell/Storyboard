using Storyboard.Data.EF.DbObject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storyboard.Data.EF
{
    public class StoryboardContext : DbContext
    {
        public StoryboardContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<ActorTableRow> Actor { get; set; }
        public DbSet<StoryTableRow> Story { get; set; }
        public DbSet<LinkTableRow> Link { get; set; }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorTableRow>();
            modelBuilder.Entity<StoryTableRow>();
            modelBuilder.Entity<LinkTableRow>();

        }
    }
}
