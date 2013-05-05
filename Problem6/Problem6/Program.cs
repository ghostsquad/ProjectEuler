using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    /// <summary>
    // The sum of the squares of the first ten natural numbers is,
    //
    // 1^2 + 2^2 + ... + 10^2 = 385
    // The square of the sum of the first ten natural numbers is,
    //
    // (1 + 2 + ... + 10)^2 = 55^2 = 3025
    // Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 - 385 = 2640.
    //
    // Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
    /// </summary>
    class Problem6
    {
        /// <summary>
        /// 
        /// sum of squares formula
        /// 
        /// http://formulas.tutorvista.com/math/sum-of-squares-formula.html
        /// 
        /// 1^2 + 2^2 + 3^2 + .... + n^2 = ( n(n + 1)(2n + 1) ) / 6
        /// 
        /// sum of consective integers
        /// 
        /// (1 + 2 + 3 + ... + n)^2 = n(n+1)/2
        /// where N is the number of terms
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            UInt64 answer = 0;
            UInt64 n = 100;
            UInt64 sumOfSquares = (n * (n + 1) * (2 * n + 1)) / 6;
            UInt64 sumOfConsecutive = (n * (n + 1)) / 2;
            UInt64 squareOfSum = sumOfConsecutive * sumOfConsecutive;

            answer = squareOfSum - sumOfSquares;

            Console.WriteLine(string.Format("answer: {0}", answer.ToString()));
            Console.ReadLine(); //Prevent the console from closing when we are done
        }
    }
}
