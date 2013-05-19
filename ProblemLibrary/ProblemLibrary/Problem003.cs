using System.Diagnostics;
using System.Linq;
using AdvancedMath;

namespace ProjectEuler
{
    /// <summary>
    //Largest prime factor
    //Problem 3
    //The prime factors of 13195 are 5, 7, 13 and 29.

    //What is the largest prime factor of the number 600851475143 ?
    /// </summary>
    public class Problem003
    {
        public static ulong Answer { get; private set; }

        public static void Solve(ulong number = 600851475143)
        {
            Problem003.Answer = 0;

            Problem003.Answer = Primality.Factorize(number).Last();

            Debug.WriteLine("Problem 003 Answer: " + Problem003.Answer.ToString());
        }
    }
}
