using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMath.PrimeNumberAlgorithms
{
    class SieveOfEratosthenes : IPrimeNumberAlgorithm
    {
        #region Singleton Code
        private static volatile SieveOfEratosthenes instance;
        private static object syncRoot = new Object();

        private SieveOfEratosthenes() { }

        public static SieveOfEratosthenes Instance
        {
            get 
            {
                if (instance == null) 
                {
                lock (syncRoot) 
                {
                    if (instance == null)
                        instance = new SieveOfEratosthenes();
                }
                }

                return instance;
            }
        }
        #endregion

        public List<ulong> FindPrimes(ulong maxNumber)
        {
            List<ulong> Primes = new List<ulong>();

            throw new System.NotImplementedException();

            return Primes;
        }
    }
}
