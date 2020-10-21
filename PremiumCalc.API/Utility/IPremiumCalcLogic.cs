using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumCalc.API.Utility
{
    public interface IPremiumCalcLogic
    {
        decimal MonthlyPremiumCalcForUser(int DeathCoverAmt, int OccupationId, int Age);
    }
}
