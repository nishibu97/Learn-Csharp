// See https://aka.ms/new-console-template for more information
using System;

namespace ConsoleApp6
{
    class program
    {
        static void Main(string[] args)
        {
            int n = 1;
            int sum = 0;
            do
            {
                if (n % 3 == 0)
                {
                    sum = sum + n;
                }
                n++;
            } while (n < 21);
            Console.WriteLine($"1 から 20 の整数のうち 3 で割り切れる数の合計は{sum}です。");
        }
    }
}
