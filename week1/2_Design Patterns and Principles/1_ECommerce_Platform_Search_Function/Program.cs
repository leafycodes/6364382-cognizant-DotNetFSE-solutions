using System;
using System.Linq;
using System.Diagnostics;

namespace ECommerceSearch
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        public Product(int id, string name, string category, decimal price)
        {
            ProductId = id;
            ProductName = name;
            Category = category;
            Price = price;
        }

        public override string ToString() =>
            $"{ProductId}: {ProductName} ({Category}) - ${Price}";
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("E-Commerce Search System\n");

            Product[] products = GenerateSampleProducts(1000);
            var sortedProducts = products.OrderBy(p => p.ProductId).ToArray();

            while (true)
            {
                Console.WriteLine("\n1. Linear Search");
                Console.WriteLine("2. Binary Search");
                Console.WriteLine("3. Compare Performance");
                Console.WriteLine("4. Exit");
                Console.Write("Select option: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        TestSearch(products, LinearSearch, "Linear Search");
                        break;
                    case 2:
                        TestSearch(sortedProducts, BinarySearch, "Binary Search");
                        break;
                    case 3:
                        ComparePerformance(products, sortedProducts);
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }

        #region Search Algorithms
        static Product LinearSearch(Product[] products, int targetId)
        {
            foreach (var product in products)
            {
                if (product.ProductId == targetId)
                    return product;
            }
            return null;
        }

        static Product BinarySearch(Product[] sortedProducts, int targetId)
        {
            int left = 0;
            int right = sortedProducts.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (sortedProducts[mid].ProductId == targetId)
                    return sortedProducts[mid];

                if (sortedProducts[mid].ProductId < targetId)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return null;
        }
        #endregion

        #region Test Utilities
        static Product[] GenerateSampleProducts(int count)
        {
            var rand = new Random();
            return Enumerable.Range(1, count)
                .Select(i => new Product(
                    id: 1000 + i,
                    name: $"Product {i}",
                    category: i % 2 == 0 ? "Electronics" : "Home",
                    price: Math.Round(10 + (decimal)rand.NextDouble() * 100, 2)
                )).ToArray();
        }

        static void TestSearch(Product[] products, Func<Product[], int, Product> searchMethod, string methodName)
        {
            Console.Write($"\nEnter Product ID to search ({methodName}): ");
            if (!int.TryParse(Console.ReadLine(), out int targetId))
            {
                Console.WriteLine("Invalid ID!");
                return;
            }

            var watch = Stopwatch.StartNew();
            var result = searchMethod(products, targetId);
            watch.Stop();

            Console.WriteLine(result != null
                ? $"Found: {result}\nTime: {watch.ElapsedTicks} ticks"
                : "Product not found");
        }

        static void ComparePerformance(Product[] unsorted, Product[] sorted)
        {
            int targetId = unsorted.Last().ProductId;
            var watch = new Stopwatch();

            Console.WriteLine("\n=== Performance Comparison ===");

            watch.Start();
            LinearSearch(unsorted, targetId);
            watch.Stop();
            Console.WriteLine($"Linear Search: {watch.ElapsedTicks} ticks");

            watch.Restart();
            BinarySearch(sorted, targetId);
            watch.Stop();
            Console.WriteLine($"Binary Search: {watch.ElapsedTicks} ticks");

            double ratio = (double)unsorted.Length / Math.Log2(unsorted.Length);
            Console.WriteLine($"\nTheoretical speedup for {unsorted.Length} items: ~{ratio:N0}x faster");
        }
        #endregion
    }
}