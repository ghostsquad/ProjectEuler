using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class Problem2
    {
        static void Main(string[] args)
        {
            int term1 = 1;
            int term2 = 2;
            int tempTerm;
            int fourmil = 4000000;
            int answer = 0;

            while (term2 <= fourmil)
            {
                if (term2 % 2 == 0)
                {
                    answer += term2;
                }

                tempTerm = term1;
                term1 = term2;
                term2 = tempTerm + term2;
            }

            Console.WriteLine(string.Format("answer: {0}",answer.ToString()));

            Console.ReadLine();
        }
    }
}
