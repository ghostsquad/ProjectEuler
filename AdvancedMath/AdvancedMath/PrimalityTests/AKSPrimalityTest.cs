using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedMath;

namespace AdvancedMath.PrimalityTests
{
    /// <summary>
    
    /// </summary>
    class AKSPrimalityTest : IPrimalityTest
    {
        public bool IsPrime(ulong number, IPrimeNumberAlgorithm algorithm)
        {
            /// Input: integer n > 1.
            /// If n = a<sup>b</sup> for integers a > 0 and b > 1, output composite.
            /// Find the smallest r such that o<sub>r</sub>(n) > log<sup>2</sup>(n).
            /// If 1 < gcd(a,n) < n for some a ≤ r, output composite.
            /// If n ≤ r, output prime.
            /// For a = 1 to Floor( SqRt ( Phi(r) log(n) ) ) do
            /// if (X+a)<sup>n</sup> ≠ X<sup>n</sup>+a (mod X<sup>r</sup> − 1,n), output composite;
            /// Output prime.
            /// 
            /// Here o<sub>r</sub>(n) is the multiplicative order of n modulo r, log is the binary logarithm, and Phi(r) is Euler's totient function of r.
            /// 
            /// To determine the multiplicative order of 4 modulo 7, we compute 42 = 16 ≡ 2 (mod 7) and 43 = 64 ≡ 1 (mod 7), so ord7(4) = 3.

            if (number > 3)
            {
                if (number % 2 == 0)
                {
                    return false;
                }
            }
            else if(number > 1)
            {
                return true;
            }
            else
            {
                return false;
            }

            bool continueOuterLoop = true;

            //step1
            for (ulong a = 2; a < number; a++)
            {
                for (ulong b = 2; b < number; b++)
                {
                    ulong step1;

                    try
                    {
                        step1 = checked((ulong)Math.Pow(a, b));
                    }
                    catch
                    {
                        if (b == 2)
                        {
                            continueOuterLoop = false;
                        }
                        break;
                    }

                    if (step1 > number)
                    {
                        if (b == 2)
                        {
                            continueOuterLoop = false;
                        }

                        break;
                    }
                    if (number == step1)
                    {
                        return false;
                    }
                }
                if (!continueOuterLoop)
                {
                    break;
                }
            }

            //step2
            ulong step2floor = checked((ulong)Math.Pow(Math.Log(number), 2));
            ulong r;

            

            return true;
        }
    }
}
