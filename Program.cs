using System;
using System.Collections.Generic;
using System.Linq;

namespace euler
{
    class Program
    {
        static void Main(string[] args)
        {
            E1Sum();
            E2Fib();
            E3Prime();
            E4Palindrome();
        }

        private static void E4Palindrome()
        {
            //Brute force
            {
                //could be done more easily via num.tostring
                bool isPalindrome(int num)
                {
                    var digits = (int) (Math.Log10(num) + 1);
                    for (int i = 0; i < digits / 2; i++)
                    {
                        var first = num / (int) Math.Pow(10, digits - 1 - i) % 10;
                        var second = num / (int) Math.Pow(10, i) % 10;
                        if (first != second) return false;
                    }
                    return true;
                }
                var digitsLimit = 3;
                var max = 0;
                var start = (int) Math.Pow(10, digitsLimit - 1);
                var limit = (int) Math.Pow(10, digitsLimit);
                for (int a = start; a < limit; a++)
                    for (int b = a; b < limit; b++)
                    {
                        var num = a * b;
                        if (num > max && isPalindrome(num))
                            max = num;
                    }
                Console.WriteLine(max);
            }
        }

        private static void E3Prime()
        {
            {
                //Brute force
                var num = 600851475143;
                var divisors = new List<int>();
                var div = 2;
                while (num > 1)
                {
                    while (num % div == 0)
                    {
                        num /= div;
                        divisors.Add(div);
                    }
                    div++;
                }
                Console.WriteLine(string.Join(", ", divisors));
                Console.WriteLine(divisors.Last());
            }
            //Eratosthen's sieve
        }

        private static void E2Fib()
        {
            var limit = 4000000;
            {
                //Brute force
                //Set first 2 elements to 1 which is not even so does not need to be included in the sum
                var fibPrev = 1;
                var fibPrevPrev = 1;
                var sum = 0;
                var last = 0;
                while (true)
                {
                    last = fibPrev + fibPrevPrev;
                    if (last > limit) break;
                    fibPrevPrev = fibPrev;
                    fibPrev = last;
                    if (last % 2 == 0) sum += last;
                }
                Console.WriteLine(sum);
            }
            {
                //Only even members are computed
                //Seems that fib(n) = 4 * fib(n-3) + fib(n-6)
                //Set first 2 even elements and include them in the sum
                var fibPrev = 2;
                var fibPrevPrev = 0;
                var sum = fibPrev + fibPrevPrev;
                var last = 0;
                while (true)
                {
                    last = 4 * fibPrev + fibPrevPrev;
                    if (last > limit) break;
                    fibPrevPrev = fibPrev;
                    fibPrev = last;
                    sum += last;
                }
                Console.WriteLine(sum);
            }
        }

        private static void E1Sum()
        {
            var limit = 1000;
            {
                //Brute force
                var numbers = Enumerable.Range(1, limit - 1);
                var sum = (from k in numbers where k % 3 == 0 || k % 5 == 0 select k)
                    .Sum();
                Console.WriteLine(sum);
            }
            {
                //Constant-time
                var max = limit - 1;
                int sumTo(int n) => n * (n + 1) / 2;
                int sumDivisors(int n, int div) => sumTo(n / div) * div;
                var sum = sumDivisors(max, 3) + sumDivisors(max, 5) - sumDivisors(max, 15);
                Console.WriteLine(sum);
            }
        }
    }
}
