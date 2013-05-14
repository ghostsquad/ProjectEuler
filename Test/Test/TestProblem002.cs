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
            ulong expectedAnswer = 4613732;

            //Act
            ProjectEuler.Problem002.Solve();

            //Assert
            Assert.AreEqual(expectedAnswer, ProjectEuler.Problem002.Answer);
        }

        [TestMethod]
        public void SolveProblem002_ExampleNumbers()
        {
            //Arrange
            //all terms < 100: 1, 2, 3, 5, 8, 13, 21, 34, 55, 89 
            ulong expectedAnswer = 2 + 8 + 34;

            //Act
            ProjectEuler.Problem002.Solve(100);

            //Assert
            Assert.AreEqual(expectedAnswer, ProjectEuler.Problem002.Answer);
        }

        [TestMethod]
        public void SolveProblem002_SmallNumbers()
        {
            //Arrange
            //all terms < 100: 1, 2, 3, 5, 8, 13, 21, 34, 55, 89;
            ulong expectedAnswer = 2 + 8;

            //Act
            ProjectEuler.Problem002.Solve(9);

            //Assert
            Assert.AreEqual(expectedAnswer, ProjectEuler.Problem002.Answer);
        }
    }
}
