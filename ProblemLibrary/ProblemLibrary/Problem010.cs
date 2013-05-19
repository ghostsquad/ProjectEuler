using System.Diagnostics;
using AdvancedMath;

namespace ProjectEuler
{
    /// <summary>
    ///The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
    ///
    /// Find the sum of all the primes below two million.
    /// </summary>
    public static class Problem010
    {
        public static ulong Answer { get; private set; }

        public static void Solve(int maxPrime)
        {
            Problem010.Answer = 0;

            Primality.GeneratePrimes(maxPrime);

            foreach (ulong prime in Primality.KnownPrimes)
            {
                if (prime > (ulong)maxPrime)
                {
                    break;
                }

                Problem010.Answer = checked(Problem010.Answer + prime);
            }

            Debug.WriteLine("Problem010 Answer: {0}", Problem010.Answer);
        }
    }
}
