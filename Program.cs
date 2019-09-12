using System;
using System.Linq;

namespace euler
{
    class Program
    {
        static void Main(string[] args)
        {
            E1Sum();
        }

        private static void E1Sum()
        {
            {
                //Brute force
                var numbers = Enumerable.Range(1, 1000);
                var sum = (from k in numbers where k % 3 == 0 || k % 5 == 0 select k)
                    .Sum();
                Console.WriteLine(sum);
            }
            {
                //Constant-time
                var limit = 1000;
                int sumTo(int n) => n * (n + 1) / 2;
                int sumDivisors(int n, int div) => sumTo(n / div) * div;
                var sum = sumDivisors(limit, 3) + sumDivisors(limit, 5) - sumDivisors(limit, 15);
                Console.WriteLine(sum);
            }
        }
    }
}
