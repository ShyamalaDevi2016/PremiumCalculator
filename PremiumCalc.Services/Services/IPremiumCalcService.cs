using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PremiumCalc.Services.Models;

namespace PremiumCalc.Services
{
   public interface IPremiumCalcService
    {
      IEnumerable<OccupationRating> GetAllOccupations(); 

      decimal  GetRatingFactorForOccupation(int OccupationId);

     
    }
}
