using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PremiumCalc.API.Validations;
namespace PremiumCalc.API.Request
{
    /// <summary>
   /// Request class for premium calculator
   /// </summary>
    public class PremiumCalcRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DOBMinAgeValidation(18)]//Minimum age for premium calculation is 18(Because, occupation can't be assigned for age less than 18)
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DOBValidation(ErrorMessage = "Date of birth cannot be greater than current date")]
        public System.DateTime DOB { get; set; }
        
        [Required]
        [Range(1, Int32.MaxValue,ErrorMessage ="Death Cover Amount should be greater than 0 && cannot be empty")]
        public int DeathCoverAmt { get; set; }

        [Required]
        public int OccupationId { get; set; }


    }
}
