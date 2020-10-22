using PremiumCalc.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumCalc.API.Response
{
    public class OccupationResponse
    {
        public List<Occupations> Occupations { get; set; } = new List<Occupations>();
    }
}
