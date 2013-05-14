using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectEuler.Test
{
    [TestClass]
    public class TestProblem001
    {
        [TestMethod]
        public void SolveProblem001_DefaultParameters()
        {
            //Arrange
            ulong expectedAnswer = 233168;
            
            //Act
            ProjectEuler.Problem001.Solve();

            //Assert
            Assert.AreEqual(expectedAnswer, ProjectEuler.Problem001.Answer);
        }

        [TestMethod]
        public void SolveProblem001_ExampleNumbers()
        {
            //Arrange
            int sumOfThrees = 3 + 6 + 9;
            int sumOfFives  = 5;
            int dups = 0;
            ulong expectedAnswer = (ulong)checked(sumOfThrees + sumOfFives - dups);

            //Act
            ProjectEuler.Problem001.Solve(3, 5, 10);

            //Assert
            Assert.AreEqual(expectedAnswer, ProjectEuler.Problem001.Answer);
        }

        [TestMethod]
        public void SolveProblem001_SmallNumbers()
        {
            //Arrange
            int sumOfTwos   = 2 + 4 + 6 + 8 + 10 + 12 + 14 + 16 + 18;
            int sumOfThrees = 3 + 6 + 9 + 12 + 15 + 18;
            int dups        = 6 + 12 + 18;
            ulong expectedAnswer = (ulong)checked(sumOfTwos + sumOfThrees - dups);

            //Act
            ProjectEuler.Problem001.Solve(2,3,20);

            //Assert
            Assert.AreEqual(expectedAnswer, ProjectEuler.Problem001.Answer);
        }
    }
}
