using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace ProjectEuler
{
    public static class PrimeNumbers
    {
        public static List<ulong> KnownPrimes { get; private set; }
        private static string KnownPrimesFileName = "KnownPrimes.txt";

        static PrimeNumbers()
        {
            KnownPrimes = new List<ulong>();
            List<string> KnownPrimesStrings = File.ReadAllLines(KnownPrimesFileName).Where(s => !string.IsNullOrEmpty(s)).ToList<string>();

            ulong primeNum;

            foreach (string primeNumStr in KnownPrimesStrings)
            {
                if (ulong.TryParse(primeNumStr, out primeNum))
                {
                    KnownPrimes.Add(primeNum);
                }
                else
                {
                    System.NotSupportedException nse = new System.NotSupportedException(string.Format("Unable to convert [{0}] to ulong", primeNum));
                    throw nse;
                }
            }          
        }

        public static void GeneratePrimes(ulong max)
        {
            //Console.WriteLine("GeneratePrimes started");

            File.AppendAllText(KnownPrimesFileName, Environment.NewLine);

            uint primesGenerated = 0;
            uint totalPrimesGenerated = 0;
            List<string> newPrimes = new List<string>();

            for (ulong num = KnownPrimes.LastOrDefault() + 2; num <= max; num += 2)
            {
                double sqrt = Math.Sqrt(num);

                if (IsPrime(num))
                {
                    primesGenerated++;
                    KnownPrimes.Add(num);
                    newPrimes.Add(num.ToString());

                    if (primesGenerated == 1000)
                    {
                        totalPrimesGenerated += primesGenerated;
                        Console.WriteLine(string.Format("primes generated: {0}", totalPrimesGenerated.ToString()));
                        //Thread.Sleep(2000);                            

                        File.AppendAllLines(KnownPrimesFileName, newPrimes);
                        newPrimes = new List<string>();
                        primesGenerated = 0;
                    }
                }                
            }

            //write stragglers to the file
            if (newPrimes.Count > 0)
            {
                Console.WriteLine(string.Format("primes generated: {0}", totalPrimesGenerated.ToString()));
                File.AppendAllLines(KnownPrimesFileName, newPrimes);
            }
        }
        
        public static void GeneratePrimesUsingMaxNumberOfTerms(int maxNumberOfTerms)
        {            
            int termsGenerated = KnownPrimes.Count;
            if(termsGenerated >= maxNumberOfTerms)
            {
                return;
            }            

            ulong num = KnownPrimes.LastOrDefault() + 2;

            while(termsGenerated < maxNumberOfTerms)
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

        /*
         * The most basic method of checking the primality of a given integer n is called trial division. 
         * This routine consists of dividing n by each integer m that is greater than 1 and less than or equal to the square root of n.
         *           
         * This routine can be implemented more efficiently if a complete list of primes up to  is 
         * known—then trial divisions need to be checked only for those m that are prime.
         */        

        public static bool IsPrime(ulong Num)
        {            
            //first let's just see if the num is already in our known primes list
            //it might also be faster to just get the last num in our known primes list and see if it's bigger
            //the way we generate primes ensures that we have all primes, and they are sorted
            if (KnownPrimes.Contains(Num))
            {
                return true;
            }

            //if (KnownPrimes.LastOrDefault() >= Num)
            //{
            //    return true;
            //}

            double sqrt = Math.Sqrt(Num);

            //first lets make sure we have enough prime numbers
            if (KnownPrimes.LastOrDefault() < sqrt)
            {
                GeneratePrimes((ulong)sqrt + 1);
            }

            foreach (ulong prime in KnownPrimes)
            {
                if (prime > sqrt)
                {
                    return true;
                }
                if (Num % prime == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static void AddToKnownPrimes(ulong num)
        {

            if (num > KnownPrimes.LastOrDefault())
            {
                KnownPrimes.Add(num);
                File.AppendAllText(KnownPrimesFileName, string.Format("{0}{1}", Environment.NewLine, num.ToString()));
            }            
        }

        public static List<ulong> Factorize (ulong num)
        {
            List<ulong> factors = new List<ulong>();
            PrimeNumbers.GeneratePrimes(num);
            if (IsPrime(num))
            {
                factors.Add(num);
                return factors;
            }

            double tempNum = num;
            double newNum = num;
            double prime = KnownPrimes.First();

            int index;

            while (prime <= newNum)
            {
                tempNum = newNum / prime;

                //check if result is an integer (nothing past decimal point)
                if (tempNum % 1 == 0)
                {
                    factors.Add((ulong)prime);
                    newNum = (ulong)tempNum;
                }
                else
                {
                    //get the next prime in list
                    index = KnownPrimes.BinarySearch((ulong)prime);
                    prime = KnownPrimes[index + 1];
                }
            }

            return factors;
        }
    }
}
