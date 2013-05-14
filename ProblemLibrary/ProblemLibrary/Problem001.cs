using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    /// <summary>
    //Multiples of 3 and 5
    //Problem 1
    //If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.

    //Find the sum of all the multiples of 3 or 5 below 1000.
    /// </summary>
    public static class Problem001
    {
        public static ulong Answer { get; private set; }

        public static void Solve(int num1 = 3, int num2 = 5, int max = 1000)
        {
            Problem001.Answer = 0;

            ulong sumOfNum1 = 0;
            ulong sumOfNum2 = 0;
            ulong sumOfDuplicates = 0;

            sumOfNum1 = GetSumOfMultiples(num1, max);
            sumOfNum2 = GetSumOfMultiples(num2, max);
            sumOfDuplicates = GetSumOfMultiples(checked(num1 * num2), max);

            Problem001.Answer = sumOfNum1 + sumOfNum2 - sumOfDuplicates;
        }

        private static ulong GetSumOfMultiples(int multipleOf, int max)
        {
            ulong sum = 0;

            for (int i = multipleOf; i < max; i = checked(i + multipleOf))
            {
                sum = checked(sum + (ulong)i);
            }

            return sum;
        }
    }
}
