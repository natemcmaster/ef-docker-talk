using Microsoft.EntityFrameworkCore;
using System;

namespace MigrationsApp
{
    public class BloggingContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\localdb;Database=DemoMigrations;Integrated Security=true");
        }

        public DbSet<Blog> Blogs { get; set; }
    }
}