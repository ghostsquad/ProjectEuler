using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectEuler.Test
{
    [TestClass]
    public class TestProblem011
    {
        [TestMethod]
        public void SolveProblem011_DefaultParameters()
        {
            //Arrange
            Problem011 problemObj = new Problem011();
            ulong expectedAnswer = 70600674;

            //Act
            problemObj.Solve();

            //Assert
            Assert.AreEqual(expectedAnswer, problemObj.Answer);
        }        
    }
}
