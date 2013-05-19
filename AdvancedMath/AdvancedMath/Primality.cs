using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace AdvancedMath
{
    public static class Primality
    {
        public static List<ulong> KnownPrimes { get; private set; }

        private static string PrimeNumbersCacheFileName = "PrimeNumbersCache.txt";

        static Primality()
        {
            Primality.KnownPrimes = new List<ulong>();

            Primality.KnownPrimes.Add(2);
            Primality.KnownPrimes.Add(3);
            Primality.KnownPrimes.Add(5);
            //using (StreamReader sr = new StreamReader(Primality.PrimeNumbersCacheFileName))
            //{
            //    string line;
            //    while ((line = sr.ReadLine()) != null)
            //    {
            //        if (!string.IsNullOrEmpty(line))
            //        {
            //            try
            //            {
            //                KnownPrimes.Add(ulong.Parse(line));
            //            }
            //            catch(System.Exception exception)
            //            {
            //                Debug.WriteLine(string.Format("Unable to convert [{0}] to ulong", line));
            //            }
            //        }
            //    }
            //}
        }        

        public static void GeneratePrimes(ulong max, PrimeGenerationType primeGenerationType = PrimeGenerationType.MaxNumber)
        {
            switch(primeGenerationType)
            {
                case PrimeGenerationType.MaxTerm:
                    {
                        int maxTerms = checked((int)max);
                        GeneratePrimesMaxTerms(maxTerms);
                        break;
                    }
                default:
                    {
                        GeneratePrimesMaxNumber(max);
                        break;
                    }
            }
        }

        public static void GeneratePrimes(long max, PrimeGenerationType primeGenerationType = PrimeGenerationType.MaxNumber)
        {
            Primality.GeneratePrimes((ulong)max, primeGenerationType);
        }

        public static void GeneratePrimes(uint max, PrimeGenerationType primeGenerationType = PrimeGenerationType.MaxNumber)
        {
            Primality.GeneratePrimes((ulong)max, primeGenerationType);
        }

        public static void GeneratePrimes(int max, PrimeGenerationType primeGenerationType = PrimeGenerationType.MaxNumber)
        {
            Primality.GeneratePrimes((ulong)max, primeGenerationType);
        }

        private static void GeneratePrimesMaxNumber(ulong maxNumber)
        {
            int lastPrimeIndex = Primality.KnownPrimes.Count - 1;
            ulong lastPrime = Primality.KnownPrimes[lastPrimeIndex];
            int primesGenerated = 0;

            if (lastPrime >= maxNumber)
            {
                return;
            }

            for (ulong possibleNewPrime = lastPrime + 2; possibleNewPrime <= maxNumber; possibleNewPrime += 2)
            {
                if (Primality.IsPrime(possibleNewPrime))
                {
                    KnownPrimes.Add(possibleNewPrime);
                }
            }
            if (primesGenerated > 0)
            {
                Primality.WriteNewPrimesToFile(KnownPrimes.GetRange(lastPrimeIndex, primesGenerated));
            }
        }

        private static void GeneratePrimesMaxTerms(int maxNumberOfTerms)
        {
            int termsGenerated = Primality.KnownPrimes.Count;
            if (termsGenerated >= maxNumberOfTerms)
            {
                return;
            }

            ulong num = KnownPrimes.LastOrDefault() + 2;

            while (termsGenerated < maxNumberOfTerms)
            {
                double sqrt = Math.Sqrt(num);

                if (IsPrime(num))
                {
                    termsGenerated++;
                    KnownPrimes.Add(num);
                }

                num += 2;
            }
        }

        private static void WriteNewPrimesToFile(List<ulong> NewPrimes)
        {
            //using (StreamWriter sw = new StreamWriter(Primality.PrimeNumbersCacheFileName, true))
            //{
            //    foreach(ulong prime in NewPrimes)
            //    {
            //        sw.WriteLine(prime.ToString());
            //    }                
            //}
        }

        /// <summary>
        /// Checks if a number is prime
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsPrime(ulong number)
        {
            //first let's just see if the num is already in our known primes list
            //it might also be faster to just get the last num in our known primes list and see if it's bigger
            //the way we generate primes ensures that we have all primes, and they are sorted
            if (KnownPrimes.Contains(number))
            {
                return true;
            }

            //if (KnownPrimes.LastOrDefault() >= Num)
            //{
            //    return true;
            //}

            double sqrt = Math.Sqrt(number);

            //first lets make sure we have enough prime numbers
            if (KnownPrimes.LastOrDefault() < sqrt)
            {
                GeneratePrimes((ulong)sqrt);
            }

            foreach (ulong prime in KnownPrimes)
            {
                if (prime > sqrt)
                {
                    return true;
                }

                if (number % prime == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsPrime(int number)
        {
            return Primality.IsPrime((ulong)number);
        }

        public static bool IsPrime(uint number)
        {
            return Primality.IsPrime((ulong)number);
        }

        public static bool IsPrime(long number)
        {
            return Primality.IsPrime((ulong)number);
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
                    prime = KnownPrimes[primeIndex];
                }
            }

            return factors;
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

        public enum PrimeGenerationType
        {
            MaxNumber
          , MaxTerm
        }
    }
}
