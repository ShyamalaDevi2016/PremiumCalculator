using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Moq;
using NUnit.Framework;
using PremiumCalc.API.Controllers;
using PremiumCalc.API.Mapper;
using PremiumCalc.API.Utility;
using PremiumCalc.Services;
using AutoFixture;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PremiumCalc.API.Models;
using PremiumCalc.Infra;
using PremiumCalc.API.Request;
using PremiumCalc.API.Response;

namespace PremiumCalc.UnitTests
{
    public class PremiumCalcControllerTests
    {
        private Fixture objFixture;
        private PremiumCalcController objController;
        private Mock<IPremiumCalcService> objPremiumService;
        private Mock<IPremiumCalcLogic> objPremiumLogic;


        [SetUp]
        public void Setup()
        {
            objFixture = new Fixture();
            objFixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => objFixture.Behaviors.Remove(b));
            objFixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile<PremiumCalcProfile>();
            });
            var mapper = config.CreateMapper();
            var logger = new LoggerManager();

            objPremiumService = new Mock<IPremiumCalcService>();
            objPremiumLogic = new Mock<IPremiumCalcLogic>();
            objController = new PremiumCalcController(objPremiumService.Object, objPremiumLogic.Object, mapper, logger);
        }


        [Test]
        public void GetAllOccupations_Test()
        {

            var Occupations = objFixture.Build<PremiumCalc.Services.Models.OccupationRating>().CreateMany(4).AsQueryable();

            objPremiumService.Setup(x => x.GetAllOccupations()).Returns(Occupations);

            var okResult = objController.GetAllOccupations() as OkObjectResult;
            var apiResult = okResult.Value as OccupationResponse;

            Assert.IsNotNull(apiResult);
            Assert.IsTrue(apiResult.Occupations.Count == 4);
            Assert.AreEqual(Occupations.First().OccupationName, apiResult.Occupations.First().OccupationName);
        }


        [Test]
        public void MonthlyPremiumCalculator_Test()
        {
            PremiumCalcRequest request = new PremiumCalcRequest();
            request.OccupationId = 1;
            request.DeathCoverAmt = 2400;
            request.DOB = DateTime.Parse("10/22/1992");
            double RatingFactor = 1.75;

            int Age = Utility.ReturnAge(request.DOB);

            var TestResult = (2400 * RatingFactor * Age) / 1000 * 12;

            objPremiumLogic.Setup(x => x.MonthlyPremiumCalcForUser(It.Is<int>(u => u.Equals(request.DeathCoverAmt)), It.Is<int>(u => u.Equals(request.OccupationId)), It.Is<DateTime>(u => u.Equals(request.DOB)))).Returns(TestResult);

            var okResult = objController.MonthlyPremiumCalculator(request) as OkObjectResult;
            var apiResult = okResult.Value as PremiumCalcResponse;

            Assert.IsNotNull(apiResult.MonthlyPremiumAmout);
            Assert.AreEqual(TestResult, apiResult.MonthlyPremiumAmout);

        }




        }
}
