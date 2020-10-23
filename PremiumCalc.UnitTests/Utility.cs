using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalc.UnitTests
{
    public static class Utility
    {
        /// <summary>
        ///  utility function to calculate age
        /// </summary>
        /// <param name="DOB"></param>
        /// <returns></returns>
        public static int ReturnAge(DateTime DOB)
        {
            int Age;
            Age = DateTime.Now.Year - DOB.Year;
            if (DateTime.Now.DayOfYear < DOB.DayOfYear)
                Age = Age - 1;
            return Age;
        }
    }
}
