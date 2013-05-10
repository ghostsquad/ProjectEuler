using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler 
{
    /// <summary>
    //The following iterative sequence is defined for the set of positive integers:

    //n → n/2 (n is even)
    //n → 3n + 1 (n is odd)

    //Using the rule above and starting with 13, we generate the following sequence:

    //13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
    //It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.

    //Which starting number, under one million, produces the longest chain?

    //NOTE: Once the chain starts the terms are allowed to go above one million.
    /// </summary>
	class Problem14
	{
		private static ulong answer = 0;
        private static int longestChainLength = 0;
		
		static void Main(string[] args)
		{           
            for (int startingNum = 1000000; startingNum > 0; startingNum--)
            {
                ulong next = (ulong)startingNum;
                int chainLength = 0;

                while (next > 1)
                {
                    chainLength++;
                    next = NextNumberInSequence(next);                    
                }

                if (chainLength > Problem14.longestChainLength)
                {
                    Problem14.longestChainLength = chainLength;
                    Problem14.answer = (ulong)startingNum;
                }
            }            

			Console.WriteLine(string.Format("answer: {0}", Problem14.answer.ToString()));
            Console.WriteLine(string.Format("longest chain: {0}", Problem14.longestChainLength.ToString()));
			Console.ReadLine();
		}

        private static ulong NextNumberInSequence(ulong current)
        {
            if (current % 2 == 0)
            {
                return (current / 2);
            }
            else
            {
                return ((3 * current) + 1);
            }
        }
	}
}
