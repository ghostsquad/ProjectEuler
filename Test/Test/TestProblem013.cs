using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectEuler.Test
{
    [TestClass]
    public class TestProblem013
    {
        [TestMethod]
        public void SolveProblem013_DefaultParameters()
        {
            //Arrange
            Problem013 problemObj = new Problem013();
            ulong expectedAnswer = 5537376230;

            //Act
            problemObj.Solve();

            //Assert
            Assert.AreEqual(expectedAnswer, problemObj.Answer);
        }        
    }
}
