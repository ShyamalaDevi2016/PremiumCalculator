﻿using System;
using System.Collections.Generic;
using System.Text;

using PremiumCalc.API.Utility;
using Moq;
using PremiumCalc.Services;
using NUnit.Framework;
using System.Linq;

namespace PremiumCalc.UnitTests
{
    public class PremiumCalcLogicTests
    {
       
        private PremiumCalcLogic objPremiumLogic;
        private Mock<IPremiumCalcService> objIPremiumLogic;

        [SetUp]
        public void Setup()
        {


            objIPremiumLogic = new Mock<IPremiumCalcService>();
            objPremiumLogic = new PremiumCalcLogic(objIPremiumLogic.Object);
        }


        [Test]
        public void MonthlyPremiumCalcForUser_Test( )
        {
            int OccupationId = 1;
            int DeathCoverAmt = 2400;
            DateTime DOB = DateTime.Parse("10/22/1992");
            double RatingFactor = 1.75;
            int Age = Utility.ReturnAge(DOB);


            objIPremiumLogic.Setup(x => x.GetRatingFactorForOccupation(It.Is<int>(u => u.Equals(OccupationId)))).Returns(RatingFactor);

            var TestResult =Math.Round( (2400 * RatingFactor * Age) / 1000 * 12,2);


            var result = objPremiumLogic.MonthlyPremiumCalcForUser(DeathCoverAmt, OccupationId, DOB);

            Assert.IsNotNull(result);
            Assert.AreEqual(TestResult, result);
        }



        }
}
