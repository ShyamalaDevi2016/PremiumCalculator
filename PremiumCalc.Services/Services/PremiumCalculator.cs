using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PremiumCalc.Services.DBContext;
using PremiumCalc.Services.Models;

namespace PremiumCalc.Services
{
    public class PremiumCalculator : IPremiumCalcService
    {
        private readonly DBContext.DBContext objDBContext;

        public PremiumCalculator(DBContext.DBContext _objDBContext)
        {
            objDBContext = _objDBContext;
        }

        public IEnumerable<OccupationRating> GetAllOccupations()
        {
            return objDBContext.OccupationRating;
        }

        public decimal GetRatingFactorForOccupation(int OccupationId)
        {

            if (OccupationId > 0)
            {
                var IQueryFactor = from occ in objDBContext.OccupationRating
                                   join rm in objDBContext.RatingMaster on occ.RatingId equals rm.RatingId
                                   where occ.OccupationId == OccupationId
                                   select rm.Factor;

                return IQueryFactor.SingleOrDefault<decimal>();
            }
            else
                throw new Exception("Invalid Occupation Id");
          
            
           //select new {rm.Factor};


           //decimal RatingFactor = (decimal)objFactor;
        }

        //public decimal MonthlyPremiumCalcForUser(int DeathCoverAmt, int OccupationId, int Age)
        //{

        //    decimal OccRatingFactor = GetRatingFactorForOccupation(OccupationId);


        //    decimal MonthlyPreminumAmt = (DeathCoverAmt * OccRatingFactor * Age) / 1000 * 12;

        //    return MonthlyPreminumAmt;


        //}
    }
}
