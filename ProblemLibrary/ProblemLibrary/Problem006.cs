﻿using System.Diagnostics;

namespace ProjectEuler
{
    /// <summary>
    /// The sum of the squares of the first ten natural numbers is,
    ///
    /// 1^2 + 2^2 + ... + 10^2 = 385
    /// The square of the sum of the first ten natural numbers is,
    ///
    /// (1 + 2 + ... + 10)^2 = 55^2 = 3025
    /// Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 - 385 = 2640.
    ///
    /// Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
    /// </summary>
    class Problem006
    {
        public static ulong Answer { get; private set; }

        /// <summary>
        /// 
        /// sum of squares formula
        /// 
        /// http://formulas.tutorvista.com/math/sum-of-squares-formula.html
        /// 
        /// 1^2 + 2^2 + 3^2 + .... + n^2 = ( n(n + 1)(2n + 1) ) / 6
        /// 
        /// sum of consecutive integers
        /// 
        /// (1 + 2 + 3 + ... + n)^2 = n(n+1)/2
        /// where N is the number of terms
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Solve(int highNumber)
        {
            ulong n = (ulong)highNumber;
            ulong sumOfSquares = checked((n * (n + 1) * (2 * n + 1)) / 6);
            ulong sumOfConsecutive = checked((n * (n + 1)) / 2);
            ulong squareOfSums = checked(sumOfConsecutive * sumOfConsecutive);

            Problem006.Answer = checked(squareOfSums - sumOfSquares);

            Debug.WriteLine("Problem006 Answer: {0}", Problem006.Answer);
        }
    }
}