using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class Problem1
    {
        static void Main(string[] args)
        {
            int sumThrees = 0;
            int sumFives = 0;
            int sumDups = 0;
            int answer = 0;

            sumThrees = GetSumOfMultiples(3, 1000);
            sumFives = GetSumOfMultiples(5, 1000);
            sumDups = GetSumOfMultiples(15, 1000);

            answer = sumThrees + sumFives - sumDups;

            Console.WriteLine(String.Format("Answer: {0}", answer.ToString()));

            Console.ReadLine();
        }

        private static int GetSumOfMultiples(int multipleOf, int max)
        {
            int sum = 0;

            for (int i = multipleOf; i < max; i += multipleOf)
            {
                sum += i;
            }

            return sum;
        }
    }
}
