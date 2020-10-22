using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumCalc.API.Request
{
    public class PremiumCalcRequest
    {
        [Required]
        [Range(1, Int32.MaxValue,ErrorMessage ="Death Cover Amount should be greater than 0 && cannot be empty")]
        public int DeathCoverAmt { get; set; }

        [Required]
        public int OccupationId { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage ="Age should be greater than 0 and lesser than or equal to 100")]
        public int Age { get; set; }
    }
}
