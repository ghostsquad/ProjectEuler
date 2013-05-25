using System;
using ProjectEuler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectEuler.Test
{
    [TestClass]
    public class TestProblem004
    {
        [TestMethod]
        public void SolveProblem004_DefaultParameters()
        {
            //Arrange
            Problem004 problemObj = new Problem004();
            ulong expectedAnswer = 906609;

            //Act
            problemObj.Solve();

            //Assert
            Assert.AreEqual(expectedAnswer, problemObj.Answer);
        }

        [TestMethod]
        public void SolveProblem004_ExampleNumbers()
        {
            //Arrange 
            Problem004 problemObj = new Problem004();
            //The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 x 99.
            ulong expectedAnswer = 9009;

            //Act
            problemObj.Solve(2);

            //Assert
            Assert.AreEqual(expectedAnswer, problemObj.Answer);
        }        
    }
}
