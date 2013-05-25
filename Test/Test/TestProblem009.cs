using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectEuler.Test
{
    [TestClass]
    public class TestProblem009
    {
        [TestMethod]
        public void SolveProblem009_DefaultParameters()
        {
            //Arrange
            Problem009 problemObj = new Problem009();
            ulong expectedAnswer = 31875000;

            //Act
            problemObj.Solve();

            //Assert
            Assert.AreEqual(expectedAnswer, problemObj.Answer);
        }

        //[TestMethod]
        public void SolveProblem009_ExampleNumbers()
        {
            //Arrange
            Problem009 problemObj = new Problem009();
            ///a^2 + b^2 = c^2
            ///3,4,5
            ///For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.
            ///
            ///9 * 16 * 25 = 3600
            ///3+4+5 = 12
            ulong expectedAnswer = 3600;

            //Act
            problemObj.Solve(12);

            //Assert
            Assert.AreEqual(expectedAnswer, problemObj.Answer);
        }
    }
}
