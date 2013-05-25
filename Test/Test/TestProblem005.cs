using System;
using ProjectEuler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectEuler.Test
{
    [TestClass]
    public class TestProblem005
    {
        [TestMethod]
        public void SolveProblem005_DefaultParameters()
        {
            //Arrange
            Problem005 problemObj = new Problem005();
            ulong expectedAnswer = 232792560;

            //Act
            problemObj.Solve();

            //Assert
            Assert.AreEqual(expectedAnswer, problemObj.Answer);
        }

        [TestMethod]
        public void SolveProblem005_ExampleNumbers()
        {
            //Arrange
            Problem005 problemObj = new Problem005();
            //2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
            ulong expectedAnswer = 2520;

            //Act
            problemObj.Solve(1, 10);

            //Assert
            Assert.AreEqual(expectedAnswer, problemObj.Answer);
        }

        [TestMethod]
        public void SolveProblem005_SmallNumbers()
        {
            //Arrange
            Problem005 problemObj = new Problem005();
            ulong expectedAnswer = 2;

            //Act
            problemObj.Solve(1, 2);

            //Assert
            Assert.AreEqual(expectedAnswer, problemObj.Answer);
        }
    }
}
