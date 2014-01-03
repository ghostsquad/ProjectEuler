using System;
using System.Linq;

namespace ProjectEuler
{
    /// <summary>
    /*
     * A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 * 99.
     * 
     * Find the largest palindrome made from the product of two 3-digit numbers.
     * 
     */
    /// </summary>
    public class Problem004
    {
        public ulong Answer { get; private set; }

        private int lowestProductPreviousRun;
        private int largestPalindrome = 0;
        private int factor1startpoint;
        private int factor2startpoint;
        private int lowestFactor;

        public ulong Solve(int numberOfDigits = 3)
        {
            this.Answer = 0;

            /*            
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
            * 998 * 996 = 994008 - STOP! (product lower than lowest product from previous run, products are only getting smaller from here out)
            * 
            * at some point, we need to break out of the outer loop, so we don't needlessly multiply tiny numbers
            * this happens when factor2 starts fresh, and is immediately met with a product that is smaller that the lowest product from the previous run
            */

            this.factor1startpoint = (int)(Math.Pow(10, numberOfDigits) - 1);
            this.factor2startpoint = factor1startpoint;
            this.lowestFactor = (int)(Math.Pow(10, numberOfDigits - 1));

            for (int factor1 = factor1startpoint; factor1 >= lowestFactor; factor1--)
            {
                //here we set factor 2 to the same as factor one, as shown in the example above
                //as the outer loop progresses, the inner loop starting point will always be the same as the outer loop starting point
                this.factor2startpoint = factor1;

                if (!CheckIfLargerPalindromeAvailable(this.factor2startpoint))
                {
                    break;
                }
            }

            this.Answer = (ulong)this.largestPalindrome;

            return this.Answer;
        }

        private bool CheckIfLargerPalindromeAvailable(int factor2startpoint)
        {
            int factor1 = factor2startpoint;

            int product;
            string productString;
            string productStringReverse;

            for (int factor2 = factor2startpoint; factor2 > 0; factor2--)
            {
                product = factor1 * factor2;

                //set the lowest product to the current product if it hasn't been set yet
                if (this.lowestProductPreviousRun == null)
                {
                    this.lowestProductPreviousRun = product;
                }

                //products are only getting smaller for each iteration
                //break early if the product is smaller than the lowest product from the previous run
                if (product < this.lowestProductPreviousRun)
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
                    if (product > this.largestPalindrome)
                    {
                        this.lowestProductPreviousRun = product;
                        this.largestPalindrome = product;
                    }
                    break;
                }
            }
            return true;
        }
    }
}
