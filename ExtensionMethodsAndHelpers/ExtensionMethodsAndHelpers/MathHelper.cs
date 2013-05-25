using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedMath;

namespace ExtensionMethodsAndHelpers
{
    public static class MathHelper
    {      
        /// <summary>
        /// factorial definition: http://en.wikipedia.org/wiki/Factorial
        /// extension method explanation: http://msdn.microsoft.com/en-us/library/bb383977.aspx
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int Factorial(this int num)
        {
            int factorialNum = 1;
            while (num > 0)
            {
                factorialNum = checked(factorialNum * num);
                num--;
            }

            return factorialNum;
        }

        public static ulong Factorial(this ulong num)
        {
            ulong factorialNum = 1;
            while (num > 0)
            {
                factorialNum = checked(factorialNum * num);
                num--;
            }

            return factorialNum;
        }

        /// <summary>
        /// example usage
        /// 5! / 3!
        /// 5 x 4 x 3 x 2 x 1 / 3 x 2 x 1
        /// (3 x 2 x 1) can be eliminated from both denominator and numerator
        /// </summary>
        /// <param name="num"></param>
        /// <param name="denominatorFactorial"></param>
        /// <returns></returns>
        public static ulong FactorialSimplified(this ulong num, ulong denominatorFactorial)
        {
            ulong factorialNum = 1;
            if (denominatorFactorial < num)
            {
                while (num > denominatorFactorial)
                {
                    factorialNum = checked(factorialNum * num);
                    num--;
                }
            }            
            return factorialNum;
        }

        public static ulong DivideFactorialsUsingExpandAndSimplify(this int num, int denomFactorial1, int denomFactorial2)
        {
            ulong quotient;
            ulong numerator = 1;
            ulong denominator = 1;

            //let's say I was given 15! / 10!4!
            //this can be expanded to 15 * 14 * 13 * 12 * 11 * 10! / 10!4!
            //10! can be eliminated from top and bottom
            //leaving us
            //15 * 14 * 13 * 12 * 11 / 4 * 3 * 2 * 1
            //
            //from here, let's loop through each numerator number, and try to divide by a denominator number.
            //if division is unsuccessful, start creating our new numerator
            //if division is successful, remove the denominator used            
            //15 / 1
            //remove 1 from denom list
            //do not change numerator yet.
            //loop starting at last place

            List<int> numeratorFactorialParts = new List<int>();
            List<int> denominatorFactorialParts = new List<int>();

            while (num > 1)
            {

                numeratorFactorialParts.AddRange(Primality.Factorize(num));
                num--;
            }

            while (denomFactorial1 > 1)
            {
                denominatorFactorialParts.AddRange(Primality.Factorize(denomFactorial1));
                denomFactorial1--;
            }

            while (denomFactorial2 > 1)
            {
                denominatorFactorialParts.AddRange(Primality.Factorize(denomFactorial2));
                denomFactorial2--;
            }

            numeratorFactorialParts.Sort();
            //numeratorFactorialParts.RemoveAll(n => n == 1);
            denominatorFactorialParts.Sort();
            //denominatorFactorialParts.RemoveAll(n => n == 1);

            int numeratorPartsIterated = 0;
            int numeratorPart = numeratorFactorialParts[numeratorPartsIterated];
            bool divisionSuccessful;
            double q;

            while (numeratorPartsIterated < numeratorFactorialParts.Count)
            {
                divisionSuccessful = false;
                foreach (int denomPart in denominatorFactorialParts)
                {
                    if (numeratorPart < denomPart)
                    {                        
                        break;
                    }

                    q = (double)numeratorPart / (double)denomPart;

                    if (q % 1 == 0)
                    {
                        divisionSuccessful = true;
                        denominatorFactorialParts.Remove(denomPart);
                        numeratorPart = (int)q;
                        break;
                    }
                }

                if (!divisionSuccessful || numeratorPart == 1)
                {
                    numerator = checked(numerator * (ulong)numeratorPart);
                    numeratorPartsIterated++;
                    if (numeratorPartsIterated < numeratorFactorialParts.Count - 1)
                    {
                        numeratorPart = numeratorFactorialParts[numeratorPartsIterated];
                    }                    
                }
            }

            if (denominatorFactorialParts.Count > 0)
            {
                foreach (int denomPart in denominatorFactorialParts)
                {
                    denominator = checked(denominator * (ulong)denomPart);
                }
            }
            else
            {
                denominator = 1;
            }

            quotient = numerator / denominator;

            return quotient;
        }
    }
}
