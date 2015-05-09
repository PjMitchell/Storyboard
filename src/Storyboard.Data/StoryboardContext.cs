﻿using Microsoft.Data.Entity;
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
            modelBuilder.Entity<ActorTableRow>().ForSqlServer().Table("Actor", DbSchemas.Story);
            modelBuilder.Entity<ActorTableRow>().Key(r=> r.Id);
            modelBuilder.Entity<ActorTableRow>().Property(r => r.Id).GenerateValueOnAdd();

            modelBuilder.Entity<StoryTableRow>().ForSqlServer().Table("Story", DbSchemas.Story);
            modelBuilder.Entity<StoryTableRow>().Key(r => r.Id);
            modelBuilder.Entity<StoryTableRow>().Property(r => r.Id).GenerateValueOnAdd();

            modelBuilder.Entity<LinkTableRow>().ForSqlServer().Table("Link", DbSchemas.Story);
            modelBuilder.Entity<LinkTableRow>().Key(r => r.Id);
            modelBuilder.Entity<LinkTableRow>().Property(r => r.Id).GenerateValueOnAdd();

            modelBuilder.Entity<StorySectionTableRow>().ForSqlServer().Table("StorySection", DbSchemas.Story); ;
            modelBuilder.Entity<StorySectionTableRow>().Key(r=> r.Id);
            modelBuilder.Entity<StorySectionTableRow>().Property(r => r.Id).GenerateValueOnAdd();
        }

    }
}
