namespace CreditCard.PreQualification.Demo.Web.Recommendation.Commands
{
    public class LogCustomerApplication
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public System.DateTime DateOfBirth { get; set; }

        public int AnnualIncome { get; set; }

        public string[] RecommendedCards { get; set; }
    }
}