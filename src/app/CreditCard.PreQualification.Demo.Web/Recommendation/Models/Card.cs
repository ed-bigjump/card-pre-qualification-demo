namespace CreditCard.PreQualification.Demo.Web.Recommendation.Models
{
    public class Card
    {
        public int MinimumAge { get; set; }

        public int MinimumIncome { get; set; }

        public int? MaximumIncome { get; set; }

        public string Name { get; set; }

        public decimal APR { get; set; }

        public string ImageUrl { get; set; }

        public string PromotionalMessage { get; set; }
    }
}