using Microsoft.EntityFrameworkCore;
using System;

namespace SimpleBloggingApp
{
    public class BloggingContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=StarWarsBlog;Integrated Security=true"
                , b=>b.SuppressAmbientTransactionWarning())
                ;
        }

        public DbSet<Blog> Blogs { get; set; }
    }
}