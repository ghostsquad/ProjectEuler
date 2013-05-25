using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectEuler.Test
{
    [TestClass]
    public class TestProblem010
    {
        [TestMethod]
        public void SolveProblem010_DefaultParameters()
        {
            //Arrange
            Problem010 problemObj = new Problem010();
            ulong expectedAnswer = 142913828922;

            //Act
            problemObj.Solve();

            //Assert
            Assert.AreEqual(expectedAnswer, problemObj.Answer);
        }

        [TestMethod]
        public void SolveProblem010_ExampleNumbers()
        {
            //Arrange
            Problem010 problemObj = new Problem010();
            //The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
            ulong expectedAnswer = 17;

            //Act
            problemObj.Solve(10);

            //Assert
            Assert.AreEqual(expectedAnswer, problemObj.Answer);
        }        
    }
}
