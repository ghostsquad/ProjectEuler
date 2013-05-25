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
            Problem001 problemObj = new Problem001();

            ulong expectedAnswer = 233168;
            
            //Act
            problemObj.Solve();

            //Assert
            Assert.AreEqual(expectedAnswer, problemObj.Answer);
        }

        [TestMethod]
        public void SolveProblem001_ExampleNumbers()
        {
            //Arrange
            Problem001 problemObj = new Problem001();

            int sumOfThrees = 3 + 6 + 9;
            int sumOfFives  = 5;
            int dups = 0;
            ulong expectedAnswer = (ulong)checked(sumOfThrees + sumOfFives - dups);

            //Act            
            problemObj.Solve(3, 5, 10);            

            //Assert
            Assert.AreEqual(expectedAnswer, problemObj.Answer);
        }

        [TestMethod]
        public void SolveProblem001_SmallNumbers()
        {
            //Arrange
            Problem001 problemObj = new Problem001();

            int sumOfTwos   = 2 + 4 + 6 + 8 + 10 + 12 + 14 + 16 + 18;
            int sumOfThrees = 3 + 6 + 9 + 12 + 15 + 18;
            int dups        = 6 + 12 + 18;
            ulong expectedAnswer = (ulong)checked(sumOfTwos + sumOfThrees - dups);

            //Act
            problemObj.Solve(2, 3, 20);

            //Assert
            Assert.AreEqual(expectedAnswer, problemObj.Answer);
        }
    }
}
