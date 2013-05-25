﻿using System;
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
            Problem003 problemObj = new Problem003();
            ulong expectedAnswer = 6857;

            //Act
            problemObj.Solve();

            //Assert
            Assert.AreEqual(expectedAnswer, problemObj.Answer);
        }

        [TestMethod]
        public void SolveProblem003_ExampleNumbers()
        {
            //Arrange
            Problem003 problemObj = new Problem003();
            //The prime factors of 13195 are 5, 7, 13 and 29.
            ulong expectedAnswer = 29;

            //Act
            problemObj.Solve(13195);

            //Assert
            Assert.AreEqual(expectedAnswer, problemObj.Answer);
        }

        [TestMethod]
        public void SolveProblem003_SmallNumbers()
        {
            //Arrange
            Problem003 problemObj = new Problem003();
            //The prime factors of 20 are 2,2,5
            ulong expectedAnswer = 5;

            //Act
            problemObj.Solve(20);

            //Assert
            Assert.AreEqual(expectedAnswer, problemObj.Answer);
        }
    }
}
