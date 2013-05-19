using System.Diagnostics;
using AdvancedMath;

namespace ProjectEuler
{
    /// <summary>

    /// </summary>
    class Problem007
    {
        public static ulong Answer { get; private set; }

        public static void Solve(int terms)
        {
            Primality.GeneratePrimes(terms, Primality.PrimeGenerationType.MaxTerm);

            Problem007.Answer = Primality.KnownPrimes[terms - 1];

            Debug.WriteLine("Problem007 Answer: {0}", Problem007.Answer);
        }
    }
}
