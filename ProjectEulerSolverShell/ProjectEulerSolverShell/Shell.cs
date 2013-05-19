using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler;

namespace ProjectEulerSolverShell
{
    class Shell
    {
        static void Main(string[] args)
        {
            ProjectEuler.Problem003.Solve();
            Console.WriteLine(ProjectEuler.Problem003.Answer.ToString());

            Console.ReadLine();
        }
    }
}
