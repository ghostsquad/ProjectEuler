using AdvancedMath;

namespace ProjectEuler
{
    /// <summary>

    /// </summary>
    public class Problem007
    {
        public ulong Answer { get; private set; }

        public ulong Solve(int terms = 10001)
        {
            this.Answer = 0;

            Primality.GeneratePrimes(terms, Primality.PrimeGenerationType.MaxTerm);

            this.Answer = Primality.KnownPrimes[terms - 1];

            return this.Answer;
        }
    }
}
