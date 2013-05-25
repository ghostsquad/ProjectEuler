using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectEuler.Test
{
    [TestClass]
    public class TestProblem002
    {       
        [TestMethod]
        public void SolveProblem002_DefaultParameters()
        {
            //Arrange
            Problem002 problemObj = new Problem002();

            ulong expectedAnswer = 4613732;

            //Act
            problemObj.Solve();

            //Assert
            Assert.AreEqual(expectedAnswer, problemObj.Answer);
        }

        [TestMethod]
        public void SolveProblem002_ExampleNumbers()
        {
            //Arrange
            Problem002 problemObj = new Problem002();
            //all terms < 100: 1, 2, 3, 5, 8, 13, 21, 34, 55, 89 
            ulong expectedAnswer = 2 + 8 + 34;

            //Act
            problemObj.Solve(100);

            //Assert
            Assert.AreEqual(expectedAnswer, problemObj.Answer);
        }

        [TestMethod]
        public void SolveProblem002_SmallNumbers()
        {
            //Arrange
            Problem002 problemObj = new Problem002();
            //all terms < 100: 1, 2, 3, 5, 8, 13, 21, 34, 55, 89;
            ulong expectedAnswer = 2 + 8;

            //Act
            problemObj.Solve(9);

            //Assert
            Assert.AreEqual(expectedAnswer, problemObj.Answer);
        }
    }
}
