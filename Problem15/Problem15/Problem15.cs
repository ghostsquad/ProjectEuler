using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facet.Combinatorics;

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
		private static List<char> Turns = new List<char>();
		
		static void Main(string[] args)
		{
			Permutations<char> latticePaths = new Permutations<char>(Problem15.Turns, GenerateOption.WithoutRepetition);
			answer = (ulong)latticePaths.Count;
			Console.WriteLine(string.Format("answer: {0}", Problem15.answer.ToString()));
			Console.ReadLine();
		}

		private static void InitTurnList()
		{
			for (int i = 0; i < 10; i++)
			{
				Problem15.Turns.Add('R');
				Problem15.Turns.Add('D');
			}
		}
	}
}
