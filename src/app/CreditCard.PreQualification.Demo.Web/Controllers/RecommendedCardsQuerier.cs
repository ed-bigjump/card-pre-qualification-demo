using System;
using System.Collections.Generic;
using System.Linq;

namespace CreditCard.PreQualification.Demo.Web.Controllers
{
    public class RecommendedCardsQuerier
    {
        //TODO could come from the database in future?
        private IEnumerable<Card> Cards
        {
            get
            {
                return new[]
                {
                    new Card
                    {
                        MinimumAge = 18,
                        MinimumIncome = 30000,
                        Name = "BarclayCard",
                        APR = 21.9m,
                        ImageUrl = "~/images/barclaycard.png",
                        PromotionalMessage = "A flexible card you can use for balance transfers and purchases. 0% interest on purchases for up to 25 months from the date you open your account."
                    },
                    new Card
                    {
                        MinimumAge = 18,
                        MinimumIncome = 0,
                        MaximumIncome = 30000,
                        Name = "Vanquis Card",
                        APR = 39.9m,
                        ImageUrl = "~/images/vanquis-card.png",
                        PromotionalMessage = "Great for credit building. Opening credit limit of £150 - £1,000. Increase your credit limit after the fifth statement, subject to eligibility"
                    },
                };
            }
        }

        public IEnumerable<RecommendedCard> Query(DateTime dateOfBirth, int annualIncome)
        {
            //TODO remove dependencies
            var calculator = new AgeCalculator();
            var age = calculator.Calculate(DateTime.Today, dateOfBirth);

            var cards = Cards
                .Where(c => age >= c.MinimumAge)
                .Where(c => annualIncome >= c.MinimumIncome)
                .Where(c => c.MaximumIncome == null || annualIncome < c.MaximumIncome)
                .Select(c => new RecommendedCard
                {
                    Name = c.Name,
                    APR = c.APR,
                    ImageUrl = c.ImageUrl,
                    PromotionalMessage = c.PromotionalMessage
                })
                .ToArray();

            return cards;
        }
    }
}