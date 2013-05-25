using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler;

namespace ProjectEuler.Test
{
    [TestClass]
    public class TestProblem008
    {
        [TestMethod]
        public void SolveProblem008_DefaultParameters()
        {
            //Arrange
            Problem008 problemObj = new Problem008();
            ulong expectedAnswer = 40824;

            //Act
            problemObj.Solve();

            //Assert
            Assert.AreEqual(expectedAnswer, problemObj.Answer);
        }

        //[TestMethod]
        //public void SolveProblem003_ExampleNumbers()
        //{
        //    //Arrange 
        //    //The prime factors of 13195 are 5, 7, 13 and 29.
        //    ulong expectedAnswer = 29;

        //    //Act
        //    ProjectEuler.Problem003.Solve(13195);

        //    //Assert
        //    Assert.AreEqual(expectedAnswer, ProjectEuler.Problem003.Answer);
        //}

        //[TestMethod]
        //public void SolveProblem003_SmallNumbers()
        //{
        //    //Arrange
        //    //The prime factors of 20 are 2,2,5
        //    ulong expectedAnswer = 5;

        //    //Act
        //    ProjectEuler.Problem003.Solve(20);

        //    //Assert
        //    Assert.AreEqual(expectedAnswer, ProjectEuler.Problem003.Answer);
        //}
    }
}
