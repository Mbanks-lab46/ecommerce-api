using EcommerceAPI.Models;

namespace EcommerceAPI.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext db)
        {
            // Only seed if tables are empty
            if (db.Products.Any()) return;

            // Create categories first
            if (!db.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category { Name = "Shoes", Slug = "shoes" },
                    new Category { Name = "Tops", Slug = "tops" },
                    new Category { Name = "Bottoms", Slug = "bottoms" },
                    new Category { Name = "Hoodies", Slug = "hoodies" }
                };

                db.Categories.AddRange(categories);
                db.SaveChanges();
            }

            // Grab category IDs from the database
            var shoes = db.Categories.First(c => c.Slug == "shoes");
            var tops = db.Categories.First(c => c.Slug == "tops");
            var bottoms = db.Categories.First(c => c.Slug == "bottoms");
            var hoodies = db.Categories.First(c => c.Slug == "hoodies");

            var products = new List<Product>
            {
                new Product
                {
                    Name = "Air Max 90",
                    Description = "Iconic Nike cushioning keeps every step feeling fresh.",
                    Price = 129.99m,
                    Stock = 50,
                    ImageUrl = "https://picsum.photos/seed/airmax/400/300",
                    CategoryId = shoes.Id
                },
                new Product
                {
                    Name = "Air Force 1",
                    Description = "Classic street style with premium leather upper.",
                    Price = 109.99m,
                    Stock = 75,
                    ImageUrl = "https://picsum.photos/seed/airforce/400/300",
                    CategoryId = shoes.Id
                },
                new Product
                {
                    Name = "React Infinity Run",
                    Description = "Designed to help reduce injury and keep you running.",
                    Price = 159.99m,
                    Stock = 30,
                    ImageUrl = "https://picsum.photos/seed/react/400/300",
                    CategoryId = shoes.Id
                },
                new Product
                {
                    Name = "Pegasus 40",
                    Description = "Versatile running shoe for everyday miles.",
                    Price = 139.99m,
                    Stock = 45,
                    ImageUrl = "https://picsum.photos/seed/pegasus/400/300",
                    CategoryId = shoes.Id
                },
                new Product
                {
                    Name = "Dri-FIT Training Tee",
                    Description = "Sweat-wicking fabric keeps you dry during tough workouts.",
                    Price = 34.99m,
                    Stock = 100,
                    ImageUrl = "https://picsum.photos/seed/dryfit/400/300",
                    CategoryId = tops.Id
                },
                new Product
                {
                    Name = "Pro Training Shorts",
                    Description = "Lightweight shorts built for high performance training.",
                    Price = 44.99m,
                    Stock = 80,
                    ImageUrl = "https://picsum.photos/seed/shorts/400/300",
                    CategoryId = bottoms.Id
                },
                new Product
                {
                    Name = "Therma-FIT Hoodie",
                    Description = "Warm fleece hoodie perfect for cold weather training.",
                    Price = 74.99m,
                    Stock = 60,
                    ImageUrl = "https://picsum.photos/seed/hoodie/400/300",
                    CategoryId = hoodies.Id
                },
                new Product
                {
                    Name = "Metcon 9",
                    Description = "Stable and versatile shoe built for cross training.",
                    Price = 149.99m,
                    Stock = 35,
                    ImageUrl = "https://picsum.photos/seed/metcon/400/300",
                    CategoryId = shoes.Id
                }
            };

            db.Products.AddRange(products);
            db.SaveChanges();
        }
    }
}