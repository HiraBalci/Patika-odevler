using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Webapi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Books.AddRange(new Book()
                {
                    Title = "Lean Startup",
                    GenreId = 1, // Personal Growth
                    PageCount = 200,
                    PublishDate = new DateTime(2010, 03, 15)
                },
                new Book()
                {
                    Title = "Lord Of The Rings",
                    GenreId = 2, // Science Fiction
                    PageCount = 1000,
                    PublishDate = new DateTime(2001, 02, 12)
                },
                new Book()
                {
                    Title = "Hobbit",
                    GenreId = 2, // Science Fiction
                    PageCount = 1100,
                    PublishDate = new DateTime(2005, 01, 04)
                });

                context.SaveChanges();
            }
        }
    }
}