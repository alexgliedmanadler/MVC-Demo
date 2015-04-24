using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Demo
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                //Create and save a new Blog
                Console.Write("Enter a name for a new Blog: ");
                var name = Console.ReadLine();

                var blog = new Blog { Name = name };
                db.Blogs.Add(blog);
                db.SaveChanges();

                //Display all blogs from the db
                var query = from b in db.Blogs
                            orderby b.Name
                            select b;

                Console.WriteLine("All blogs inthe database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);

                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}