using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using AdvancedMath;
using AdvancedMath.PrimeNumberAlgorithms;
using AdvancedMath.PrimalityTests;

namespace AdvancedMath
{
    public static class Primality
    {     
        public static ulong GetNthPrime(int n)
        {
            ulong nthPrime = 2;

            if (n < 1)
            {
                throw new System.NotSupportedException("N must be a positve integer greater than 0");
            }            

            return nthPrime;
        }
        
        public static List<ulong> FindPrimes(ulong maxNumber, PrimeAlgorithms algorithm)
        {
            IPrimeNumberAlgorithm iprimeAlgorithm;

            switch(algorithm)
            {
                case PrimeAlgorithms.SieveOfAtkin:
                    iprimeAlgorithm = SieveOfAtkin.Instance;
                    break;
                case PrimeAlgorithms.SieveOfEratosthenes:
                    iprimeAlgorithm = SieveOfEratosthenes.Instance;
                    break;
                case PrimeAlgorithms.SieveOfEuler:
                    iprimeAlgorithm = SieveOfEuler.Instance;
                    break;
                case PrimeAlgorithms.TrialDivision:
                    iprimeAlgorithm = TrialDivision.Instance;
                    break;
                case PrimeAlgorithms.WheelSieve:
                    iprimeAlgorithm = WheelSieve.Instance;
                    break;
                default:
                    throw new System.NotImplementedException("that algorithm is not implemented");
            }

            return iprimeAlgorithm.FindPrimes(maxNumber);
        }

        public static List<ulong> Factorize(ulong number)
        {
            List<ulong> factors = new List<ulong>();
            double sqrt = checked(Math.Sqrt(number));

            Primality.GeneratePrimes((ulong)sqrt);
            if (IsPrime(number))
            {
                factors.Add(number);
                return factors;
            }

            double tempNum = number;
            double newNum = number;
            int primeIndex = 0;
            double prime = KnownPrimes[primeIndex];

            while (prime <= newNum)
            {
                tempNum = checked(newNum / prime);

                //check if result is an integer (nothing past decimal point)
                if (tempNum % 1 == 0)
                {
                    factors.Add((ulong)prime);
                    newNum = (ulong)tempNum;
                }
                else
                {
                    //get the next prime in list
                    primeIndex++;
                    if (primeIndex > KnownPrimes.Count - 1)
                    {
                        break;
                    }
                    prime = KnownPrimes[primeIndex];
                }
            }

            return factors;
        }

        public static List<int> Factorize(int number)
        {
            List<ulong> factorsUlong = Primality.Factorize((ulong)number);
            List<int> factorsInt = new List<int>();
            foreach (ulong factor in factorsUlong)
            {
                factorsInt.Add(checked((int)factor));
            }

            return factorsInt;
        }

        public static SortedList<ulong, int> FactorizeReturnFactorPowers(ulong num)
        {
            SortedList<ulong, int> factorPowers = new SortedList<ulong, int>();
            List<ulong> factors = Primality.Factorize(num);
            foreach (ulong factor in factors)
            {
                //increment the "power" in the dictionary by one, otherwise, add a new entry at power of 1
                if (factorPowers.ContainsKey(factor))
                {
                    factorPowers[factor]++;
                }
                else
                {
                    factorPowers[factor] = 1;
                }
            }
            return factorPowers;
        }

        public enum PrimeAlgorithms
        {
            TrialDivision
            ,WheelSieve
            ,SieveOfEuler
            ,SieveOfAtkin
            ,SieveOfEratosthenes
        }
    }
}
