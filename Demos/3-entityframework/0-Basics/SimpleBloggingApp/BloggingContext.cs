using Microsoft.EntityFrameworkCore;
using System;

namespace SimpleBloggingApp
{
    public class BloggingContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\localdb;Database=DemoBlog;Integrated Security=true");
        }

        public DbSet<Blog> Blogs { get; set; }
    }
}