using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SimpleBloggingApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                db.Database.EnsureCreated();

                var blog = new Blog { Title = "Funny Dog Tricks" };

                var connection = db.Database.GetDbConnection();

                connection.BeginTransaction();

                using (var transaction = db.Database.BeginTransaction())
                {
                    db.Blogs.Add(blog);

                    db.SaveChanges();
                    transaction.Commit();
                }
            }
        }
    }
}
