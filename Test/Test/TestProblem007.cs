using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectEuler.Test
{
    [TestClass]
    public class TestProblem007
    {
        [TestMethod]
        public void SolveProblem007_DefaultParameters()
        {
            //Arrange
            Problem007 problemObj = new Problem007();
            ulong expectedAnswer = 104743;

            //Act
            problemObj.Solve();

            //Assert
            Assert.AreEqual(expectedAnswer, problemObj.Answer);
        }

        [TestMethod]
        public void SolveProblem007_ExampleNumbers()
        {
            //Arrange
            Problem007 problemObj = new Problem007();
            //By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
            ulong expectedAnswer = 13;

            //Act
            problemObj.Solve(6);

            //Assert
            Assert.AreEqual(expectedAnswer, problemObj.Answer);
        }

        [TestMethod]
        public void SolveProblem007_SmallNumbers()
        {
            //Arrange
            Problem007 problemObj = new Problem007();
            //7th prime is 17
            ulong expectedAnswer = 17;

            //Act
            problemObj.Solve(7);

            //Assert
            Assert.AreEqual(expectedAnswer, problemObj.Answer);
        }
    }
}
