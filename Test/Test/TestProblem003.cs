using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectEuler.Test
{
    [TestClass]
    public class TestProblem003
    {
        [TestMethod]
        public void SolveProblem003_DefaultParameters()
        {
            //Arrange
            ulong expectedAnswer = 6857;

            //Act
            ProjectEuler.Problem003.Solve();

            //Assert
            Assert.AreEqual(expectedAnswer, ProjectEuler.Problem003.Answer);
        }

        [TestMethod]
        public void SolveProblem003_ExampleNumbers()
        {
            //Arrange 
            //The prime factors of 13195 are 5, 7, 13 and 29.
            ulong expectedAnswer = 29;

            //Act
            ProjectEuler.Problem003.Solve(13195);

            //Assert
            Assert.AreEqual(expectedAnswer, ProjectEuler.Problem003.Answer);
        }

        [TestMethod]
        public void SolveProblem003_SmallNumbers()
        {
            //Arrange
            //The prime factors of 20 are 2,2,5
            ulong expectedAnswer = 5;

            //Act
            ProjectEuler.Problem003.Solve(20);

            //Assert
            Assert.AreEqual(expectedAnswer, ProjectEuler.Problem003.Answer);
        }
    }
}
