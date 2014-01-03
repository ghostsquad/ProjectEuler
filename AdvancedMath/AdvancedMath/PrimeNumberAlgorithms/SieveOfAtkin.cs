using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMath.PrimeNumberAlgorithms
{
    class SieveOfAtkin : IPrimeNumberAlgorithm
    {
        #region Singleton Code
        private static volatile SieveOfAtkin instance;
        private static object syncRoot = new Object();

        private SieveOfAtkin() { }

        public static SieveOfAtkin Instance
        {
            get 
            {
                if (instance == null) 
                {
                lock (syncRoot) 
                {
                    if (instance == null)
                        instance = new SieveOfAtkin();
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
