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
        public ulong Answer { get; private set; }

        public ulong Solve(ulong number = 600851475143)
        {
            this.Answer = 0;

            this.Answer = Primality.Factorize(number).Last();

            return this.Answer;
        }
    }
}
