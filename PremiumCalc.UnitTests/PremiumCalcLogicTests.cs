using System;
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
            int Age = 30;
            double RatingFactor = 1.75;
           
            objIPremiumLogic.Setup(x => x.GetRatingFactorForOccupation(It.Is<int>(u => u.Equals(OccupationId)))).Returns(RatingFactor);

            var TestResult = (2400 * RatingFactor * Age) / 1000 * 12;


            var result = objPremiumLogic.MonthlyPremiumCalcForUser(DeathCoverAmt, OccupationId, Age);

            Assert.IsNotNull(result);
            Assert.AreEqual(TestResult, result);
        }



        }
}
