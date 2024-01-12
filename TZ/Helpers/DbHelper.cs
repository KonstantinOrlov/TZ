using TZ.Data;
using TZ.Data.Models;

namespace TZ.WebApi.Helpers
{
    public static class DbHelper
    {
        public static void SetDataIfEmpty(TZContext context)
        {
            var userCount = 10;
            var productCount = 100;
            var ratingCount = productCount * userCount;

            if (!context.Users.Any())
            {
                for (var i = 0; i < userCount; i++)
                {
                    context.Users.Add(new User
                    {
                        Name = $"User №{i + 1}",
                    });

                }
            }

            if (!context.Products.Any())
            {
                for (var i = 0; i < productCount; i++)
                {
                    context.Products.Add(new Product
                    {
                        Name = $"Product №{i + 1}",
                    });

                }
            }

            context.SaveChanges();

            if (!context.Ratings.Any())
            {

                var productId = 0;
                var userId = 0;

                var users = context.Users.ToList();
                var products = context.Products.ToList();

                var random = new Random();
                for (var i = 0; i < ratingCount; i++)
                {
                    context.Ratings.Add(new Rating
                    {
                        Review = $"Some big text №{i + 1}",
                        StarsCount = random.Next(5),
                        Product = products[productId],
                        User = users[userId]
                    });

                    if (productId == productCount - 1)
                    {
                        productId = 0;
                        userId++;
                    }
                    else
                    {
                        productId++;
                    }
                }
            }

            context.SaveChanges();
        }
    }
}
