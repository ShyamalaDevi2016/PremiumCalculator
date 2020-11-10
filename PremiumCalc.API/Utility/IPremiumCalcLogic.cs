using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumCalc.API.Utility
{
    /// <summary>
    /// Interface for premium calculator utility
    /// </summary>
    <test>
    public interface IPremiumCalcLogic
    {
        double MonthlyPremiumCalcForUser(int DeathCoverAmt, int OccupationId, DateTime DOB);
    }
}
