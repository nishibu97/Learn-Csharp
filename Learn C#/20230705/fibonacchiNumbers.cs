// See https://aka.ms/new-console-template for more information
using System;

namespace ConsoleApp6
{
    class program
    {
        static void Main(string[] args)
        {
            int n = 20;
            var fibonacciNumbers = new List<int> { 1, 1 };

            for (int i = 3; i <= n; i++)
            {
                var previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
                var previous2 = fibonacciNumbers[fibonacciNumbers.Count - 2];
                fibonacciNumbers.Add(previous + previous2);
            }
            foreach (var item in fibonacciNumbers)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"フィボナッチ数列の20番目は {fibonacciNumbers[n - 1]}");
        }
    }
}
