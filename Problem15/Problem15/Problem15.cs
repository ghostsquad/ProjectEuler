using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionMethods;

namespace ProjectEuler 
{
	/// <summary>
	//Starting in the top left corner of a 22 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.

	//→→     →        →       
	//  ↓     ↓        ↓
	//  ↓      →       ↓
	//          ↓       →

	//↓       ↓       ↓
	// →→      →      ↓
	//   ↓      ↓      →→
	//           →

	//How many such routes are there through a 2020 grid?

	//the above combinations can be translated to THESE permutations:
	//RRDD RDRD RDDR
	//DRRD DRDR DDRR
	/// </summary>
	class Problem15
	{
		private static ulong answer = 0;

		//lets create a list of the TURNS we can take. We always need to go Right 20, Down 20, we just need to find the permutations of such
		private static List<string> Turns = new List<string>();

		private static int gridSize = 2;
		
		static void Main(string[] args)
		{

			//this is a case of combinations with repetition
			//http://www.mathsisfun.com/combinatorics/combinations-permutations.html            
			//so in the example, of 5 icecream flavors, choosing 3 of them (n=5, r=3)
			//There are n=5 things to choose from, and you choose r=3 of them.
			//he later explains (from the arrow/circle example), there are always 3 circles & 4 arrows
			//So (being general here) there are r + (n-1) positions, and we want to choose r of them to have circles.

			//in the 2x2 grid, we have 2 left turns, 2 down turns, and 4 possible positions (2 lefts + 2 downs) of right's and down's            
			//... we want R of them to have circles (right turn) so R = 2
			//so.. the math would be... 4 positions = 2 + (n-1)
			// 4 = 2 + (n-1)
			// 2 = n - 1
			// 3 = n
			//
			//the equation to get number of combinations with repetition is:
			// (n + r - 1)!
			// ------------
			// r!(n - 1)!

			/*
			 * n = 3, r = 2
			 * 
			 * (3 + 2 - 1)! / 2!(3 - 1)!
			 * 
			 * 4! / 2! *  2!
			 * 
			 * 4! = 4 x 3 x 2 x 1 = 24
			 * 2! = 2 x 1 = 2
			 * 
			 * 24 / 2 * 2  = 6          
			 */

            //so for a grid of 20 (20*2 positions), 1/2 of them are right's (remaining are down), r = positions/2 = 20
            int gridWidth = 20;
			int positions = gridWidth * 2;
            int r = positions / 2;
			//positions = r + (n - 1)
			//position - r = n - 1
			//positions - r + 1 = n
            //n = positions - r - 1
            int n = positions - r + 1;

			//the equation to get number of combinations with repetition is:
			// (n + r - 1)!
			// ------------
			// r! * (n - 1)!
            int numeratorBeforeFactorial = n + r - 1;
            int denomPart1PreFactorial = r;
            int denomPart2PreFactorial = n - 1;         

            //let's simplify as much as possible

            //simplifying factorials
            //http://www.ehow.com/video_4738956_simplify-factorials.html
            //http://www.sophia.org/simplifying-factorials-tutorial

            //I've implemented FactorialSimplified, but that's not enough
            //example
            /// 5! / 3!
            /// 5 x 4 x 3 x 2 x 1 / 3 x 2 x 1
            /// (3 x 2 x 1) can be eliminated from both denominator and numerator          

            //the code below throws an overflow exception when coming up with the numerator
            //ulong numerator = numeratorBeforeFactorial.FactorialSimplified(Math.Max(denomPart1PreFactorial, denomPart2PreFactorial));
            //ulong denominator = Math.Min(denomPart1PreFactorial, denomPart2PreFactorial).Factorial();

            //next idea:
            //factorial expand and simplification

            Problem15.answer = numeratorBeforeFactorial.DivideFactorialsUsingExpandAndSimplify(denomPart1PreFactorial, denomPart2PreFactorial);


			Console.WriteLine(string.Format("answer: {0}", Problem15.answer.ToString()));			
			Console.ReadLine();
		}
	}
}
