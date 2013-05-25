using System.Diagnostics;
using AdvancedMath;

namespace ProjectEuler
{
    /// <summary>
    ///The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
    ///
    /// Find the sum of all the primes below two million.
    /// </summary>
    public class Problem010
    {
        public ulong Answer { get; private set; }

        public ulong Solve(int maxPrime = 2000000)
        {
            this.Answer = 0;

            Primality.GeneratePrimes(maxPrime);

            foreach (ulong prime in Primality.KnownPrimes)
            {
                if (prime > (ulong)maxPrime)
                {
                    break;
                }

                this.Answer = checked(this.Answer + prime);
            }

            return this.Answer;
        }
    }
}
