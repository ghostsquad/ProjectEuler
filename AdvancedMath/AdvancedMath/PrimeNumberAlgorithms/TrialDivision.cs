using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMath.PrimeNumberAlgorithms
{
    class TrialDivision : IPrimeNumberAlgorithm
    {
        #region Singleton Code
        private static volatile TrialDivision instance;
        private static object syncRoot = new Object();

        private TrialDivision() { }

        public static TrialDivision Instance
        {
            get 
            {
                if (instance == null) 
                {
                lock (syncRoot) 
                {
                    if (instance == null)
                        instance = new TrialDivision();
                }
                }

                return instance;
            }
        }
        #endregion

        public List<ulong> FindPrimes(ulong maxNumber)
        {
            List<ulong> Primes = new List<ulong>();
            Primes.Add(2);
            Primes.Add(3);
            Primes.Add(5);

            int lastPrimeIndex = Primes.Count - 1;
            ulong lastPrime = Primes[lastPrimeIndex];

            if (lastPrime >= maxNumber)
            {
                return Primes;
            }

            for (ulong possibleNewPrime = lastPrime + 2; possibleNewPrime <= maxNumber; possibleNewPrime += 2)
            {
                if (Primality.IsPrime(possibleNewPrime))
                {
                    Primes.Add(possibleNewPrime);
                }
            }

            return Primes;
        }
    }
}
