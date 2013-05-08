using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{


    /// <summary>
    /// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
    /// 
    /// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
    /// </summary>

    class Problem5
    {
        static void Main(string[] args)
        {
            UInt64 answer = 0;
            UInt64 primeFactorial;
            Dictionary<UInt64, int> factorPowersFinal = new Dictionary<UInt64, int>();
            Dictionary<UInt64, int> factorPowers;        

            /*
             * loop through each number, and factorize it
             * example:
             * 6=2*3
             * 8=2*2*2 OR (2^3)
             * 14 = 2*7
             * 12 = 2*6 = 2*2*3 OR 2^2 * 3
             */

            for (UInt64 i = 2; i <= 20; i++)
            {
                List<UInt64> factors = PrimeNumbers.Factorize(i);
                factorPowers = new Dictionary<UInt64, int>();
                foreach (UInt64 factor in factors)
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

                foreach (UInt64 factor in factorPowers.Keys)
                {
                    //if the final factor/power dictionary does not contain the factor
                    //OR
                    //if the final factor/power dictionary DOES contain the factor, AND the new fact is greater
                    //no keyNotfoundException would ever be generated using this
                    if (!(factorPowersFinal.ContainsKey(factor)) || factorPowersFinal[factor] < factorPowers[factor])
                    {
                        factorPowersFinal[factor] = factorPowers[factor];
                    }
                }
            }            

            foreach (UInt64 factor in factorPowersFinal.Keys)
            {
                primeFactorial = (UInt64)Math.Pow((double)factor, factorPowersFinal[factor]);

                if (answer == 0)
                {                    
                    answer = primeFactorial;
                }
                else
                {
                    answer *= primeFactorial;
                }                
            }

            Console.WriteLine(string.Format("answer: {0}", answer.ToString()));
            Console.ReadLine(); //Prevent the console from closing when we are done
        }
    }
}
