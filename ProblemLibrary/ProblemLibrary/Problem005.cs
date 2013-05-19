using System;
using System.Collections.Generic;
using System.Diagnostics;
using AdvancedMath;

namespace ProjectEuler
{
    /// <summary>
    /// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder. 
    /// 
    /// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
    /// </summary>
    class Problem005
    {
        public static ulong Answer { get; private set; }

        public static void Solve(int low, int high)
        {
            if (low == 1)
            {
                low = 2;
            }
            if (high == 1)
            {
                high = 2;
            }

            if (low > high)
            {
                throw new System.ArgumentException("low value must be less than or equal to high value");
            }

            Dictionary<ulong, int> factorPowersFinal = new Dictionary<ulong, int>();
            ulong primeFactorial;

            for (int num = low; num <= high; num++)
            {
                SortedList<ulong, int> factorPowers = Primality.FactorizeReturnFactorPowers((ulong)num);

                foreach (ulong factor in factorPowers.Keys)
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

            foreach (ulong factor in factorPowersFinal.Keys)
            {
                primeFactorial = checked((ulong)Math.Pow((double)factor, factorPowersFinal[factor]));

                if (Problem005.Answer == 0)
                {
                    Problem005.Answer = primeFactorial;
                }
                else
                {
                    Problem005.Answer = checked(Problem005.Answer *= primeFactorial);
                }
            }

            Debug.WriteLine("Problem005 Answer: {0}", Problem005.Answer);
        }
    }
}
