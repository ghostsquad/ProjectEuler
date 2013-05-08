using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ProjectEuler
{
	/// <summary>
	/// Special Pythagorean triplet
	// Problem 9
	// A Pythagorean triplet is a set of three natural numbers, a  b  c, for which,

	// a2 + b2 = c2
	// For example, 32 + 42 = 9 + 16 = 25 = 52.

	// There exists exactly one Pythagorean triplet for which a + b + c = 1000.
	// Find the product abc.
	/// </summary>
	/// 
	/// <answer>
	/// r = 150
	/// s = 50
	/// t = 225
	/// 
	/// a = 200
	/// b = 375
	/// c = 425
	/// 
	/// numToFactor 11250
	/// factors [50,225] = 11250
	/// triple generated [200,375,425]
	/// </answer>
	class Problem9
	{
		/// <summary>
		/// Pythagorean Theorem
		/// a^2 + b^2 = c^2
		/// a < b < c
		/// 
		/// triplet generation using Dickson method
		/// 
		/// http://en.wikipedia.org/wiki/Formulas_for_generating_Pythagorean_triples
		/// 
		/// r^2 = 2st
		/// 
		/// a = r + s
		/// b = r + t
		/// c = r + s + t
		/// 
		/// r is an EVEN integer
		/// 
		/// s & t are factors of r^2 / 2
		/// 
		/// Example: r = 6
		/// then r^2 / 2 = 18
		/// 
		/// factor pairs of 18 are (1,18), (2,9), and (3,6) all of which produce triples
		/// 
		/// s = 1, t = 18 produces the triple [7, 24, 25] because a = 6 + 1 = 7,  b = 6 + 18 = 24,  c = 6 + 1 + 18 = 25.
		/// s = 2, t = 9 produces the triple [8, 15, 17] because a = 6 + 2 = 8,  b = 6 +  9 = 15,  c = 6 + 2 + 9 = 17.
		/// s = 3, t = 6 produces the triple [9, 12, 15] because a = 6 + 3 = 9,  b = 6 +  6 = 12,  c = 6 + 3 + 6 = 15.
		/// 
		/// </summary>
		private static int sumGoal = 1000;
		private static ulong answer = 0;

		static void Main(string[] args)
		{
			int r = 2;
			int s;
			int t;

			int a;
			int b;
			int c;

			int sum = 0; 
			int numToFactor;

			while (Problem9.answer == 0)
			{
				Debug.WriteLine("r = " + r.ToString());

				//first lets get factors of r^2 / 2
				numToFactor = r * r / 2;

				List<Tuple<int, int>> factors = GenerateFactors(numToFactor);              

				foreach (Tuple<int, int> tuple in factors)
				{                    
					s = tuple.Item1;
					t = tuple.Item2;

					//Debug.WriteLine(string.Format("factors [{0},{1}]", s, t));

					/// a = r + s
					/// b = r + t
					/// c = r + s + t
					a = r + s;
					b = r + t;
					c = r + s + t;                    

					sum = a + b + c;

					//I'm not sure this is true, so I'm commenting this out until I can test it more
					//if (sum < Problem9.sumGoal)
					//{
					//    Debug.WriteLine(string.Format("sum too small, only getting smaller {0}", sum));
					//    //break;
					//}

					Debug.WriteLine(string.Format("triple generated [{0},{1},{2}]", a, b, c));
					Debug.WriteLine("sum " + sum.ToString());

					if (sum == Problem9.sumGoal)
					{
						//Debug.WriteLine(string.Format("triple generated [{0},{1},{2}]", a, b, c));
						//Debug.WriteLine("sum " + sum.ToString());

						Problem9.answer = (ulong)(a * b * c);
						break;
					}
				}                

				//r can only be even integers, so increment by 2
				r += 2;
			}            

			Console.WriteLine(string.Format("answer: {0}", Problem9.answer.ToString()));
			Console.ReadLine(); //Prevent the console from closing when we are done
		}

		private static List<Tuple<int,int>> GenerateFactors(int num)
		{
			Debug.WriteLine("generating factors for " + num.ToString());
			List<Tuple<int, int>> factorTuples = new List<Tuple<int, int>>();

			factorTuples.Add(new Tuple<int, int>(1, num));
			Debug.WriteLine(string.Format("factors generated [{0},{1}]", 1, num));

			double sqrt = Math.Sqrt(num);
			double quotient;

			for (int i = 2; i < sqrt; i++)
			{
				quotient = (double)num / (double)i;

				//division was even (no decimal places)
				if (quotient % 1 == 0)
				{
					factorTuples.Add(new Tuple<int, int>(i, (int)quotient));
					Debug.WriteLine(string.Format("factors generated [{0},{1}]", i, quotient));
				}
			}

			return factorTuples;
		}
	   
	}
}
