using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMath.PrimeNumberAlgorithms
{
    class SieveOfEuler : IPrimeNumberAlgorithm
    {
        #region Singleton Code
        private static volatile SieveOfEuler instance;
        private static object syncRoot = new Object();

        private SieveOfEuler() { }

        public static SieveOfEuler Instance
        {
            get 
            {
                if (instance == null) 
                {
                lock (syncRoot) 
                {
                    if (instance == null)
                        instance = new SieveOfEuler();
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
