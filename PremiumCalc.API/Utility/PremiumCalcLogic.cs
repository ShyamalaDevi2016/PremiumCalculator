using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PremiumCalc.Services;
namespace PremiumCalc.API.Utility
{
    public class PremiumCalcLogic : IPremiumCalcLogic
    {
        private readonly IPremiumCalcService objPremiumCalcService;
        int Age;
        public PremiumCalcLogic(IPremiumCalcService _objPremiumCalcService)
        {
            objPremiumCalcService = _objPremiumCalcService;
        }

        public double MonthlyPremiumCalcForUser(int DeathCoverAmt, int OccupationId, DateTime DOB)
        {
            try
            {
               
                Age = DateTime.Now.Year - DOB.Year;
                if (DateTime.Now.DayOfYear < DOB.DayOfYear)
                    Age = Age - 1;

                double OccRatingFactor = objPremiumCalcService.GetRatingFactorForOccupation(OccupationId);


                double MonthlyPreminumAmt = (DeathCoverAmt * OccRatingFactor * Age) / 1000 * 12;

                return MonthlyPreminumAmt;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
