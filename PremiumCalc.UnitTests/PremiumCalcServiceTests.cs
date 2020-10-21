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
          
            Assert.AreEqual(Occupations, objActualOccupations.ToList<OccupationRating>());
        }

        [Test]
        public void GetRatingFactorForOccupation()
        {

            var RatingFactor = new List<RatingMaster>()
            {
                new RatingMaster{ RatingId =5, RatingName="Heavy Manual", Factor=1.75},
                new RatingMaster{ RatingId =6, RatingName="Light Manual", Factor=1.50},
                new RatingMaster{ RatingId =7, RatingName="Professional", Factor=1.00},
            }.AsQueryable();

            var RatingFactorMock = new Mock<DbSet<RatingMaster>>();
            RatingFactorMock.As<IQueryable<RatingMaster>>().Setup(m => m.Provider).Returns(RatingFactor.Provider);
            RatingFactorMock.As<IQueryable<RatingMaster>>().Setup(m => m.Expression).Returns(RatingFactor.Expression);
            RatingFactorMock.As<IQueryable<RatingMaster>>().Setup(m => m.ElementType).Returns(RatingFactor.ElementType);
            RatingFactorMock.As<IQueryable<RatingMaster>>().Setup(m => m.GetEnumerator()).Returns(RatingFactor.GetEnumerator());


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

            objDBContext.Setup(x => x.RatingMaster).Returns(RatingFactorMock.Object);
            objDBContext.Setup(x => x.OccupationRating).Returns(OccupationMock.Object);



            var TestQryResult = from occ in Occupations
                              join rm in RatingFactor on occ.RatingId equals rm.RatingId
                              where occ.OccupationId== 2
                          select rm.Factor;


      

            var objActualRatingFactor = objService.GetRatingFactorForOccupation(2);

            Assert.AreEqual(TestQryResult.SingleOrDefault<double>(), objActualRatingFactor);


        }

        }
}