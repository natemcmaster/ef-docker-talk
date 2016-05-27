using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationsApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                db.Database.EnsureCreated();
                db.Database.Migrate();

                db.Blogs.Add(new Blog
                {
                    Title = "VS Code Tips and Tricks"
                });

                db.SaveChanges();

                var blogs = db.Blogs.ToList();

                foreach (var blog in blogs)
                {
                    Console.WriteLine($"Blog: {blog.Title}");
                }
            }
        }
    }
}
