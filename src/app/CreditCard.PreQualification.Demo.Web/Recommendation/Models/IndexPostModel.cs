using System;
using System.ComponentModel.DataAnnotations;
using CreditCard.PreQualification.Demo.Web.Infrastructure.DateTime;

namespace CreditCard.PreQualification.Demo.Web.Recommendation.Models
{
    public class IndexPostModel
    {
        [Required(ErrorMessage = "Please enter your first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage =  "Please enter your last name")]
        public string LastName { get; set; }

        public int? BirthDay { get; set; }
        public int? BirthMonth { get; set; }
        public int? BirthYear { get; set; }

        public bool DateOfBirthIsValid()
        {
            return DateHelper.IsValidDateTime(BirthDay, BirthMonth, BirthYear);
        }

        public DateTime GetDateOfBirth()
        {
            return new DateTime(BirthYear.Value, BirthMonth.Value, BirthDay.Value);
        }

        [Required(ErrorMessage =  "Please enter your annual income")]
        public int? AnnualIncome { get; set; }
    }
}