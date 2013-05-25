using System.Collections.Generic;
using System.IO;

namespace ProjectEuler
{
    /// <summary>
    /// Find the greatest product of five consecutive digits in the 1000-digit number.
    /// </summary>
    public class Problem008
    {
        public ulong Answer { get; private set; }

        private Queue<int> fiveDigits = new Queue<int>();
        private static string ThousandDigitNumberFileName = "ProblemFiles\\Problem008_ThousandDigitNumber.txt";

        public ulong Solve()
        {
            this.Answer = 0;

            int product;
            using (StreamReader sr = new StreamReader(Problem008.ThousandDigitNumberFileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    foreach (char character in line.ToCharArray())
                    {
                        string charAsString = character.ToString();

                        if (string.IsNullOrEmpty(charAsString))
                        {
                            continue;
                        }

                        fiveDigits.Enqueue(int.Parse(charAsString));
                        if (fiveDigits.Count == 5)
                        {
                            product = 1;
                            foreach (int digit in fiveDigits)
                            {
                                product *= digit;
                            }
                            if (product > (int)this.Answer)
                            {
                                this.Answer = (ulong)product;
                            }

                            fiveDigits.Dequeue();
                        }
                    }
                }
            }

            return this.Answer;
        }
    }
}
