using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RetailInventory
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await using var context = new AppDbContext();

            Console.WriteLine("=== All Products ===");
            var products = await context.Products.ToListAsync();
            foreach (var p in products)
                Console.WriteLine($"{p.Name} - ₹{p.Price}");

            Console.WriteLine("\n=== Find Product (ID=1) ===");
            var product = await context.Products.FindAsync(1);
            Console.WriteLine($"Found: {product?.Name}");

            Console.WriteLine("\n=== First Expensive Product (>₹50,000) ===");
            var expensive = await context.Products
                .FirstOrDefaultAsync(p => p.Price > 50000);
            Console.WriteLine($"Expensive: {expensive?.Name}");

            Console.WriteLine("\n=== Products with Categories ===");
            var productsWithCategories = await context.Products
                .Include(p => p.Category)
                .ToListAsync();
            foreach (var p in productsWithCategories)
                Console.WriteLine($"{p.Name} belongs to {p.Category.Name}");
        }
    }
}