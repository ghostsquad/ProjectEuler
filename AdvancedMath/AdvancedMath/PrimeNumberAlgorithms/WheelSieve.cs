using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMath.PrimeNumberAlgorithms
{
    class WheelSieve : IPrimeNumberAlgorithm
    {
        #region Singleton Code
        private static volatile WheelSieve instance;
        private static object syncRoot = new Object();

        private WheelSieve() { }

        public static WheelSieve Instance
        {
            get 
            {
                if (instance == null) 
                {
                lock (syncRoot) 
                {
                    if (instance == null)
                        instance = new WheelSieve();
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
