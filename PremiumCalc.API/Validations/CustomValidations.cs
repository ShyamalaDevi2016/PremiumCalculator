using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PremiumCalc.API.Validations
{
    /// <summary>
    ///custom validator class to check the DOB is not future date
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class DOBValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value != null)
            {
                DateTime _dob = Convert.ToDateTime(value);
                if (_dob > DateTime.Now)
                {
                    return new ValidationResult("Date of birth cannot be greater than current date");
                }
            }
            return ValidationResult.Success;

        }

    }

    /// <summary>
    ///custom validator class to check the minimum age is 18 based on DOB
    /// </summary>
    public sealed class DOBMinAgeValidation : ValidationAttribute
    {
        public int MinimumAge { get; }
        public DOBMinAgeValidation(int minimumAge)
        {
            MinimumAge = minimumAge;
            ErrorMessage = $"Age should be greater than minimum age - {minimumAge}";
        }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime date;
            if ((value != null && DateTime.TryParse(value.ToString(), out date)))
            { 
                if(!(date.AddYears(MinimumAge) < DateTime.Now))
                {
                    return new ValidationResult(ErrorMessage);
                }
                else
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(ErrorMessage);
        }

    }


}
