namespace ProjectEuler
{
    /// <summary>
    //Multiples of 3 and 5
    //Problem 1
    //If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.

    //Find the sum of all the multiples of 3 or 5 below 1000.
    /// </summary>
    public class Problem001
    {
        public ulong Answer { get; private set; }

        //just an empty object used to make the GetInstance thread safe        
        private static Problem001 instance;

        public ulong Solve(int num1 = 3, int num2 = 5, int max = 1000)
        {
            this.Answer = 0;

            ulong sumOfNum1 = 0;
            ulong sumOfNum2 = 0;
            ulong sumOfDuplicates = 0;

            sumOfNum1 = GetSumOfMultiples(num1, max);
            sumOfNum2 = GetSumOfMultiples(num2, max);
            sumOfDuplicates = GetSumOfMultiples(checked(num1 * num2), max);

            this.Answer = sumOfNum1 + sumOfNum2 - sumOfDuplicates;

            return this.Answer;
        }

        private ulong GetSumOfMultiples(int multipleOf, int max)
        {
            ulong sum = 0;

            for (int i = multipleOf; i < max; i = checked(i + multipleOf))
            {
                sum = checked(sum + (ulong)i);
            }

            return sum;
        }
    }
}
