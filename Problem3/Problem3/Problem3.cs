using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class Problem3
    {
        static void Main(string[] args)
        {
            UInt64 answer = 0;
            UInt64 myNum = 600851475143;
            UInt64 sqrt = (UInt64)Math.Sqrt(myNum);                               

            PrimeNumbers.InitPrimeNumbers();
            PrimeNumbers.GeneratePrimes(sqrt);

            //find the closest prime number to the SQRT without going over the SQRT
            //UInt64 startPoint = sqrt - PrimeNumbers.KnownPrimes.Where(n => n <= sqrt)
            //                                                    .Min(n => sqrt - n);

            //select all prime numbers less than the SQRT
            List<UInt64> possibilities = PrimeNumbers.KnownPrimes.Where(n => n <= sqrt).OrderByDescending(n => n).ToList<UInt64>();

            foreach (UInt64 prime in possibilities)
            {
                if (myNum % prime == 0)
                {
                    answer = prime;
                    break;
                }
            }

            Console.WriteLine(string.Format("answer: {0}", answer.ToString()));
            Console.ReadLine();
        }
    }
}
