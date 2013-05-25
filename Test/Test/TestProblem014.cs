using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectEuler.Test
{
    [TestClass]
    public class TestProblem014
    {
        [TestMethod]
        public void SolveProblem014_DefaultParameters()
        {
            //Arrange
            Problem014 problemObj = new Problem014();
            ulong expectedAnswer = 837799;

            //Act
            problemObj.Solve();

            //Assert
            Assert.AreEqual(expectedAnswer, problemObj.Answer);
        }

        [TestMethod]
        public void SolveProblem014_ExampleNumbers()
        {
            //Arrange
            Problem014 problemObj = new Problem014();
            /// The following iterative sequence is defined for the set of positive integers:

            /// n → n/2 (n is even)
            /// n → 3n + 1 (n is odd)

            /// Using the rule above and starting with 13, we generate the following sequence:

            /// 13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
            ulong expectedAnswer = 13;

            //Act
            problemObj.Solve(14);

            //Assert
            Assert.AreEqual(expectedAnswer, problemObj.Answer);
        }       
    }
}
