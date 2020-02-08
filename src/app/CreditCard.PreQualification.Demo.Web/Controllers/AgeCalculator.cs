using System;

namespace CreditCard.PreQualification.Demo.Web.Controllers
{
    public class AgeCalculator
    {
        public int Calculate(DateTime today, DateTime dateOfBirth)
        {
            var age = today.Year - dateOfBirth.Year;

            // Go back to the year the person was born in case of a leap year
            if (dateOfBirth.Date > today.AddYears(-age)) age--;

            return age;
        }
    }
}