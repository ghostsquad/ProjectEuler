using System;

namespace ProjectEuler 
{
    class Problem10
    {
        static void Main(string[] args)
        {
            ulong answer = 0;

            PrimeNumbers.GeneratePrimes(1999999);

            foreach (ulong prime in PrimeNumbers.KnownPrimes)
            {
                if (prime > 1999999)
                {
                    break;
                }

                answer += prime;
            }

            Console.WriteLine(string.Format("answer: {0}", answer.ToString()));
            Console.ReadLine();
        }
    }
}
