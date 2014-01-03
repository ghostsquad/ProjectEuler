using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
	/// <summary>

	/// </summary>
	public class Problem013
	{
		public ulong Answer { get; private set; }

		private static string FiftyDigitNumbersFileName = "ProblemFiles\\Problem013_FiftyDigitNumbers.txt";
		private static List<char[]> FiftyDigitNumbers;

		public ulong Solve()
		{
			this.Answer = 0;

			Problem013.InitFiftyDigitNumbers();

			string finalSumString;
			StringBuilder finalSumStringBuilder = new StringBuilder();
			int tempDigitLastIteration = 0;
			int newTempDigit;
			int newSum;
			int tempCarry = 0;

			for (int i = 49; i >= 0; i--)
			{
				foreach (char[] numCharArray in FiftyDigitNumbers)
				{
					newTempDigit = int.Parse(numCharArray[i].ToString());
					//sum the last number and current number;
					newSum = tempDigitLastIteration + newTempDigit;
					//once we have a sum, we replace tempDigitLastIteration with the ONE's spot, and add the TEN's spot to tempCarry
					//example: newSum = 17
					//tempDigitLastIteration = 7
					//tempCarry += 10
					if (newSum >= 10)
					{
						tempDigitLastIteration = newSum % 10;
						tempCarry += (newSum / 10) * 10;
					}
					else
					{
						tempDigitLastIteration = newSum;
					}
				}

				//when we get to the end of the list, we've added together all of the digits in Column[i] of the 50 digit numbers
				//lets take the tempDigitLastIteration and add it to our string builder
				finalSumStringBuilder.Append(tempDigitLastIteration.ToString());

				//temp carry should always be a multiple of 10, so this is safe
				tempDigitLastIteration = tempCarry / 10;

				//reset tempCarry to 0;
				tempCarry = 0;
			}

			//at the end, we end with finalNumber (but backwards).. so if our number SHOULD be 12345, it will actually look like 54321 until we reverse it
			//but before we reverse it, we still have our "carry" from the last iteration (currently assigned to tempDigitLastIteration)
			//this number, will might be something like 789. If we just append it to our current StringBuilder, 
			//we get 54321789 which, reversed, would give us the wrong number (98712345) where as, we are expecting 78912345
			//we we need to reverse 789 append, then reverse our string builder.
			finalSumStringBuilder.Append(string.Join("", tempDigitLastIteration.ToString().ToCharArray().Reverse()));

			//finally, let's take a look at the REALLY big answer before we chop the first 10 digits off.
			string finalSumStringFull = string.Join("", finalSumStringBuilder.ToString().ToCharArray().Reverse());
			Debug.WriteLine(finalSumStringFull);

			finalSumString = finalSumStringFull.Substring(0, 10);

			this.Answer = ulong.Parse(finalSumString);

			return this.Answer;
		}

		private static void InitFiftyDigitNumbers()
		{
			Problem013.FiftyDigitNumbers = new List<char[]>();
			using (StreamReader sr = new StreamReader(Problem013.FiftyDigitNumbersFileName))
			{
				string line;
				while ((line = sr.ReadLine()) != null)
				{
					Problem013.FiftyDigitNumbers.Add(line.ToCharArray());
				}
			}
		}
	}    
}
