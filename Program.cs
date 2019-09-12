﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace euler
{
    class Program
    {
        static void Main(string[] args)
        { }

        private static void E2Fib()
        {
            {
                //Brute force
                var limit = 4000000;
                //Set first 2 elements to 1 which is not even so does not need to be included in the sum
                var fibPrev = 1;
                var fibPrevPrev = 1;
                var sum = 0;
                var last = 0;
                while (true)
                {
                    last = fibPrev + fibPrevPrev;
                    if (last > limit)break;
                    fibPrevPrev = fibPrev;
                    fibPrev = last;
                    if (last % 2 == 0)sum += last;
                }
                Console.WriteLine(sum);
            }
            {
                //Only even members are computed
                //Seems that fib(n) = 4 * fib(n-3) + fib(n-6)
                var limit = 4000000;
                //Set first 2 even elements and include them in the sum
                var fibPrev = 2;
                var fibPrevPrev = 0;
                var sum = fibPrev + fibPrevPrev;
                var last = 0;
                while (true)
                {
                    last = 4 * fibPrev + fibPrevPrev;
                    if (last > limit)break;
                    fibPrevPrev = fibPrev;
                    fibPrev = last;
                    if (last % 2 == 0)sum += last;
                }
                Console.WriteLine(sum);
            }
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
