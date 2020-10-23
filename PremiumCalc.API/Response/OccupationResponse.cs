using PremiumCalc.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumCalc.API.Response
{
    /// <summary>
    /// Response class for Occupation list
    /// </summary>
    public class OccupationResponse
    {
        public List<Occupations> Occupations { get; set; } = new List<Occupations>();
    }
}
