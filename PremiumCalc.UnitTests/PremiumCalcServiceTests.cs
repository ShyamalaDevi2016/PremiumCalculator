using NUnit.Framework;
using PremiumCalc.Services;
using PremiumCalc.Services.DBContext;
using PremiumCalc.Services.Models;
using Moq;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace PremiumCalc.UnitTests
{
    public class PremiumCalcServiceTests
    {
        private PremiumCalculator objService;
        private Mock<DBContext> objDBContext;
        [SetUp]
        public void Setup()
        {
            objDBContext = new Mock<DBContext>();
            objService = new PremiumCalculator(objDBContext.Object);
        }

        [Test]
        public void GetAllOccupations_Test()
        {

            //UnprocessableEntityObjectResult

            //Arrange
            var Occupations = new List<OccupationRating>()
             {
                 new OccupationRating { OccupationId=1,RatingId=5, OccupationName="Farmer" },
                 new OccupationRating { OccupationId=2,RatingId=5, OccupationName="MECHANIC" },
                 new OccupationRating { OccupationId=3,RatingId=6, OccupationName="Cleaner" }
             }.AsQueryable();

            var OccupationMock = new Mock<DbSet<OccupationRating>>();
            OccupationMock.As<IQueryable<OccupationRating>>().Setup(m => m.Provider).Returns(Occupations.Provider);
            OccupationMock.As<IQueryable<OccupationRating>>().Setup(m => m.Expression).Returns(Occupations.Expression);
            OccupationMock.As<IQueryable<OccupationRating>>().Setup(m => m.ElementType).Returns(Occupations.ElementType);
            OccupationMock.As<IQueryable<OccupationRating>>().Setup(m => m.GetEnumerator()).Returns(Occupations.GetEnumerator());


            objDBContext.Setup(x => x.OccupationRating).Returns(OccupationMock.Object);

            //Act
            var objActualOccupations = objService.GetAllOccupations();
            //Assert
            Assert.IsNotNull(objActualOccupations);
            Assert.IsTrue(objActualOccupations.Count() == 3);
            Assert.AreEqual(Occupations, objActualOccupations.ToList<OccupationRating>());
        }
    }
}