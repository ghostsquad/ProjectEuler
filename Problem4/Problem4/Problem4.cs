using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 * 99.
 * 
 * Find the largest palindrome made from the product of two 3-digit numbers.
 * 
 */

namespace ProjectEuler
{
    class Problem4
    {
        private static int lowestProductPreviousRun;
        private static int largestPalindrome = 0;
        private static int factor1startpoint = 999;
        private static int factor2startpoint = factor1startpoint;

        static void Main(string[] args)
        {                                              
            //this doesn't work, decrementing evenly skips certain factors
            
            ////now we can work backwards, doing trial multiplication until we find a number that is a palindrome
            ////instead of doing nested for loops, we decrement each factor at an even pace to make sure
            ////we stop at the highest product possible
            //while (factor1 > 0 || factor2 > 0)
            //{
            //    product = factor1 * factor2;
            //    productString = product.ToString();
            //    productStringReverse = string.Join(String.Empty, productString.ToCharArray().Reverse());

            //    if (productString == productStringReverse)
            //    {
            //        answer = productString;
            //        break;
            //    }

            //    if (factor1 >= factor2)
            //    {
            //        factor1--;
            //    }
            //    else
            //    {
            //        factor2--;
            //    }
            //}

            //this is highly inefficient

            //for (int f1 = factor1; f1 > 0; f1--)
            //{
            //    for (int f2 = factor2; f2 > 0; f2--)
            //    {
            //        product = f1 * f2;
            //        productString = product.ToString();
            //        productStringReverse = string.Join("", productString.ToCharArray().Reverse());

            //        if (productString == productStringReverse)
            //        {
            //            if (product > largestPalindrome)
            //            {
            //                largestPalindrome = product;
            //            }                        
            //            break;
            //        }
            //    }                
            //}

            /*
             * this is a modification of the above nested loop
             * what we need to do, is decrement one factor until we find a palindrome
             * then decrement both to the 1 less than the highest value they started at before and keep going until we reach the
             * either 
             *      a higher valued palindrome OR
             *      a product lower than the lowest product from the previous run
             *      
             * example (using dummy requirement)
             * 999 x 999 = 998001
             * 999 x 998 = 997002
             * 999 x 997 = 996003
             * 999 x 996 = 995004 - STOP! (dummy requirement met)
             * ---------------
             * 998 * 998 = 996004
             * 998 * 997 = 995006             
             * 998 * 996 = 994008 - STOP! (product lower than lowest product from previous run)
             * 
             * at some point, we need to break out of the outer loop, so we don't needlessly multiply tiny numbers
             * this happens when factor2 starts fresh, and is immediately met with a product that is smaller that the lowest product from the previous run
             */
                                   
            for (int factor1 = factor1startpoint; factor1 > 0; factor1--)
            {
                //here we set factor 2 to the same as factor one, as shown in the example above
                //as the outer loop progresses, the inner loop starting point will always be the same as the outer loop starting point
                factor2startpoint = factor1;

                if (!CheckIfLargerPalindromeAvailable(factor2startpoint))
                {
                    break;
                }
            }

            Console.WriteLine(string.Format("answer: {0}", Problem4.largestPalindrome.ToString()));
            Console.ReadLine();
        }

        private static bool CheckIfLargerPalindromeAvailable(int factor2startpoint)
        {
            int factor1 = factor2startpoint;

            int product;
            string productString;
            string productStringReverse;

            for (int factor2 = factor2startpoint; factor2 > 0; factor2--)
            {
                product = factor1 * factor2;

                //set the lowest product to the current product if it hasn't been set yet
                if (Problem4.lowestProductPreviousRun == null)
                {
                    Problem4.lowestProductPreviousRun = product;
                }

                //products are only getting smaller for each iteration
                //break early if the product is smaller than the lowest product from the previous run
                if (product < Problem4.lowestProductPreviousRun)
                {
                    //here is where we tell the factor1 loop to break, because any operation done from here on out will always
                    //be smaller than the largest palindrome found so far
                    if (factor2 == factor2startpoint)
                    {
                        return false;
                    }
                    break;
                }

                //check if the number is the same forwards and backwards by converting the number to a string and reversing the string
                productString = product.ToString();
                productStringReverse = string.Join("", productString.ToCharArray().Reverse());

                if (productString == productStringReverse)
                {
                    if (product > Problem4.largestPalindrome)
                    {
                        Problem4.lowestProductPreviousRun = product;
                        Problem4.largestPalindrome = product;
                    }
                    break;
                }
            }
            return true;
        }
    }
}
