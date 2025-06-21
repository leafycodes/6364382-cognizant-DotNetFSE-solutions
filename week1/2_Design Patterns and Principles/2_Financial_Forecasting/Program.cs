using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FinancialForecasting
{
    class Program
    {
        private static Dictionary<int, decimal> _memoCache = new Dictionary<int, decimal>();

        static void Main(string[] args)
        {
            Console.WriteLine("=== Financial Forecasting Tool ===");
            var (pv, rate, periods) = GetUserInput();
            var recursiveResult = CalculateFutureValueRecursive(pv, rate, periods);
            Console.WriteLine($"\n[Recursive] Future Value after {periods} periods: {recursiveResult:C}");

            _memoCache.Clear();
            var memoizedResult = CalculateFutureValueMemoized(pv, rate, periods);
            Console.WriteLine($"[Memoized] Future Value after {periods} periods: {memoizedResult:C}");

            var iterativeResult = CalculateFutureValueIterative(pv, rate, periods);
            Console.WriteLine($"[Iterative] Future Value after {periods} periods: {iterativeResult:C}");

            var optimizedResult = CalculateFutureValueOptimized(pv, rate, periods);
            Console.WriteLine($"[Optimized] Future Value after {periods} periods: {optimizedResult:C}");

            ComparePerformance(pv, rate, periods);
        }

        static (decimal pv, decimal rate, int periods) GetUserInput()
        {
            Console.Write("Enter present value (PV): ");
            decimal pv = decimal.Parse(Console.ReadLine());

            Console.Write("Enter growth rate per period (e.g., 0.05 for 5%): ");
            decimal rate = decimal.Parse(Console.ReadLine());

            Console.Write("Enter number of periods: ");
            int periods = int.Parse(Console.ReadLine());

            return (pv, rate, periods);
        }

        static decimal CalculateFutureValueRecursive(decimal pv, decimal rate, int periods)
        {
            if (periods == 0) return pv;
            return (1 + rate) * CalculateFutureValueRecursive(pv, rate, periods - 1);
        }

        static decimal CalculateFutureValueMemoized(decimal pv, decimal rate, int periods)
        {
            if (_memoCache.ContainsKey(periods))
                return _memoCache[periods];

            decimal result = periods == 0
                ? pv
                : (1 + rate) * CalculateFutureValueMemoized(pv, rate, periods - 1);

            _memoCache[periods] = result;
            return result;
        }

        static decimal CalculateFutureValueIterative(decimal pv, decimal rate, int periods)
        {
            decimal result = pv;
            for (int i = 0; i < periods; i++)
            {
                result *= (1 + rate);
            }
            return result;
        }

        static decimal CalculateFutureValueOptimized(decimal pv, decimal rate, int periods)
        {
            return pv * (decimal)Math.Pow((double)(1 + rate), periods);
        }

        static void ComparePerformance(decimal pv, decimal rate, int periods)
        {
            Console.WriteLine("\n=== Performance Comparison ===");
            var watch = new Stopwatch();
            int warmupCount = 100;
            int testCount = 10000;

            for (int i = 0; i < warmupCount; i++)
            {
                CalculateFutureValueRecursive(pv, rate, periods);
                CalculateFutureValueMemoized(pv, rate, periods);
                CalculateFutureValueIterative(pv, rate, periods);
                CalculateFutureValueOptimized(pv, rate, periods);
            }

            watch.Start();
            for (int i = 0; i < testCount; i++)
            {
                CalculateFutureValueRecursive(pv, rate, periods);
            }
            watch.Stop();
            Console.WriteLine($"Recursive: {watch.ElapsedMilliseconds}ms");

            watch.Restart();
            for (int i = 0; i < testCount; i++)
            {
                _memoCache.Clear();
                CalculateFutureValueMemoized(pv, rate, periods);
            }
            watch.Stop();
            Console.WriteLine($"Memoized: {watch.ElapsedMilliseconds}ms");

            watch.Restart();
            for (int i = 0; i < testCount; i++)
            {
                CalculateFutureValueIterative(pv, rate, periods);
            }
            watch.Stop();
            Console.WriteLine($"Iterative: {watch.ElapsedMilliseconds}ms");

            watch.Restart();
            for (int i = 0; i < testCount; i++)
            {
                CalculateFutureValueOptimized(pv, rate, periods);
            }
            watch.Stop();
            Console.WriteLine($"Optimized: {watch.ElapsedMilliseconds}ms");
        }
    }
}