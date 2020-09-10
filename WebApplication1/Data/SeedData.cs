using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;
using WebApplication1.Models.Entities;

namespace WebApplication1.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider app)
        {
            using (var context = new ApplicationDbContext(
                app.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Get a logger
                var logger = app.GetRequiredService<ILogger<SeedData>>();
                // Make sure the database is created
                context.Database.EnsureCreated();
                // Look for any products.
                if (context.Products.Any())
                {
                    logger.LogInformation("The database was already seeded");
                    return; // DB has been seeded
                }
              
                context.Manufacturers.AddRange(
                new Manufacturer { Address = "Kongegaten 11", Description = "Knows everything", Name = "Potato"}
                );

                context.Categories.AddRange(
                    new Category { Name = "Verktøy"},
                    new Category { Name = "Kjøretøy" },
                    new Category { Name = "Dagligvarer" }
                    );


                context.Products.AddRange(
                    new Product { Name = "Hammer", Price = 121.50m },
                    new Product { Name = "Vinkelsliper", Price = 1520.00m},
                    new Product { Name = "Volvo XC90", Price = 990000m},
                    new Product { Name = "Volvo XC60", Price = 620000m,},
                    new Product { Name = "Brød", Price = 25.50m,}
                );
                context.SaveChanges();
                logger.LogInformation("Finished seeding the database.");
            }
        }
    }
}
