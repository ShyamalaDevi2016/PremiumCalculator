using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PremiumCalc.Services.Models;

namespace PremiumCalc.Services
{
    /// <summary>
    ///Interface for the Premium Calculator 
    /// </summary>
    public interface IPremiumCalcService
    {
        /// <summary>
        /// Get all the available occupations  
        /// </summary>
        /// <returns>IEnumerable<OccupationRating></returns>
        IEnumerable<OccupationRating> GetAllOccupations();

        /// <summary>
        /// Get the rating factor for the selected occupation
        /// </summary>
        /// <returns>double</returns>
        double GetRatingFactorForOccupation(int OccupationId);

     
    }
}
