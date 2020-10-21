using System;
using System.Collections.Generic;

namespace PremiumCalc.Services.Models
{
    public partial class RatingMaster
    {
        public RatingMaster()
        {
            OccupationRating = new HashSet<OccupationRating>();
        }

        public int RatingId { get; set; }
        public string RatingName { get; set; }
        public decimal Factor { get; set; }

        public ICollection<OccupationRating> OccupationRating { get; set; }
    }
}
