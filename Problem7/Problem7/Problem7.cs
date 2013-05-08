using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    /// <summary>
    /// 10001st prime
    // Problem 7
    // By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.

    // What is the 10,001st prime number?
    /// </summary>
    class Problem7
    {
        static void Main(string[] args)
        {
            UInt64 answer = 0;
            int terms = 10001;

            PrimeNumbers.GeneratePrimesUsingMaxNumberOfTerms(terms);

            answer = PrimeNumbers.KnownPrimes[terms - 1];

            Console.WriteLine(string.Format("answer: {0}", answer.ToString()));
            Console.ReadLine(); //Prevent the console from closing when we are done
        }
    }
}
