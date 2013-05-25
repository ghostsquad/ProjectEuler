using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectEuler.Test
{
    [TestClass]
    public class TestProblem015
    {
        [TestMethod]
        public void SolveProblem015_DefaultParameters()
        {
            //Arrange
            Problem015 problemObj = new Problem015();
            ulong expectedAnswer = 137846528820;

            //Act
            problemObj.Solve();

            //Assert
            Assert.AreEqual(expectedAnswer, problemObj.Answer);
        }

        [TestMethod]
        public void SolveProblem015_ExampleNumbers()
        {
            //Arrange 
            Problem015 problemObj = new Problem015();
            /// Starting in the top left corner of a 2x2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.

            /// →→     →        →       
            ///   ↓     ↓        ↓
            ///   ↓      →       ↓
            ///           ↓       →

            /// ↓       ↓       ↓
            ///  →→      →      ↓
            ///    ↓      ↓      →→
            ///            →
            ulong expectedAnswer = 6;

            //Act
            problemObj.Solve(2);

            //Assert
            Assert.AreEqual(expectedAnswer, problemObj.Answer);
        }

        [TestMethod]
        public void SolveProblem015_SmallNumbers()
        {
            //Arrange
            Problem015 problemObj = new Problem015();
            ulong expectedAnswer = 2;

            //Act
            problemObj.Solve(1);

            //Assert
            Assert.AreEqual(expectedAnswer, problemObj.Answer);
        }
    }
}
