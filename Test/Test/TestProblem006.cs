using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectEuler.Test
{
    [TestClass]
    public class TestProblem006
    {
        [TestMethod]
        public void SolveProblem006_DefaultParameters()
        {
            //Arrange
            Problem006 problemObj = new Problem006();
            ulong expectedAnswer = 25164150;

            //Act
            problemObj.Solve();

            //Assert
            Assert.AreEqual(expectedAnswer, problemObj.Answer);
        }

        [TestMethod]
        public void SolveProblem006_ExampleNumbers()
        {
            //Arrange
            Problem006 problemObj = new Problem006();
            /// The sum of the squares of the first ten natural numbers is,
            ///
            /// 1^2 + 2^2 + ... + 10^2 = 385
            /// The square of the sum of the first ten natural numbers is,
            ///
            /// (1 + 2 + ... + 10)^2 = 55^2 = 3025
            /// Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 - 385 = 2640.
            ulong expectedAnswer = 2640;

            //Act
            problemObj.Solve(10);

            //Assert
            Assert.AreEqual(expectedAnswer, problemObj.Answer);
        }

        [TestMethod]
        public void SolveProblem006_SmallNumbers()
        {
            //Arrange
            Problem006 problemObj = new Problem006();
            //1^2 + 2^2 + 3^2 = 1 + 4 + 9 = 14
            //(1 + 2 + 3)^2 = 6^2 = 36
            //36-14 = 22
            ulong expectedAnswer = 22;

            //Act
            problemObj.Solve(3);

            //Assert
            Assert.AreEqual(expectedAnswer, problemObj.Answer);
        }
    }
}
