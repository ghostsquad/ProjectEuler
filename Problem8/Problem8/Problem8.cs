using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjectEuler
{
    class Problem8
    {
        private static Queue<int> fiveDigits = new Queue<int>();
        private static string ThousandDigitNumberFileName = "ThousandDigitNumber.txt";
        private static int answer = 0;        

        static void Main(string[] args)
        {
            int product;
            using (StreamReader sr = new StreamReader(Problem8.ThousandDigitNumberFileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    foreach(char character in line.ToCharArray())
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
                            if (product > answer)
                            {
                                answer = product;
                            }

                            fiveDigits.Dequeue();
                        }                                                                       
                    }
                }
            }

            Console.WriteLine(string.Format("answer: {0}", Problem8.answer.ToString()));
            Console.ReadLine(); //Prevent the console from closing when we are done
        }
    }
}
