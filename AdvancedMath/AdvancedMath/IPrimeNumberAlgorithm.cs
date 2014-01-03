using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMath
{
    public interface IPrimeNumberAlgorithm
    {
        List<ulong> FindPrimes(ulong maxNumber);
    }
}
