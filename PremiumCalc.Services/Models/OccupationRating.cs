using System;
using System.Collections.Generic;

namespace PremiumCalc.Services.Models
{
    public partial class OccupationRating
    {
        public int OccupationId { get; set; }
        public int RatingId { get; set; }
        public string OccupationName { get; set; }

        public RatingMaster Rating { get; set; }
    }
}
