using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMath.PrimalityTests
{
    class TrialDivisionPrimalityTest : IPrimalityTest
    {
        #region Singleton Code
        private static volatile TrialDivisionPrimalityTest instance;
        private static object syncRoot = new Object();

        private TrialDivisionPrimalityTest() { }

        public static TrialDivisionPrimalityTest Instance
        {
            get 
            {
                if (instance == null) 
                {
                lock (syncRoot) 
                {
                    if (instance == null)
                        instance = new TrialDivisionPrimalityTest();
                }
                }

                return instance;
            }
        }
        #endregion

        public bool IsPrime(ulong number, IPrimeNumberAlgorithm algorithm)
        {
            //first lets generate all prime numbers up the sqrt of the number to test
            double sqrt = Math.Sqrt(number);

            List<ulong> KnownPrimes = algorithm.FindPrimes((ulong)sqrt);

            foreach (ulong prime in KnownPrimes)
            {
                if (number % prime == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
