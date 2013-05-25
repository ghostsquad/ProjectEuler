using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectEuler.Test
{
    [TestClass]
    public class TestProblem012
    {
        [TestMethod]
        public void SolveProblem012_DefaultParameters()
        {
            //Arrange
            Problem012 problemObj = new Problem012();
            ulong expectedAnswer = 76576500;

            //Act
            problemObj.Solve();

            //Assert
            Assert.AreEqual(expectedAnswer, problemObj.Answer);
        }

        [TestMethod]
        public void SolveProblem012_ExampleNumbers()
        {
            //Arrange
            Problem012 problemObj = new Problem012();
            //Let us list the factors of the first seven triangle numbers:
            // 1: 1
            // 3: 1,3
            // 6: 1,2,3,6
            //10: 1,2,5,10
            //15: 1,3,5,15
            //21: 1,3,7,21
            //28: 1,2,4,7,14,28
            //We can see that 28 is the first triangle number to have over five divisors.
            ulong expectedAnswer = 28;

            //Act
            problemObj.Solve(5);

            //Assert
            Assert.AreEqual(expectedAnswer, problemObj.Answer);
        }        
    }
}
