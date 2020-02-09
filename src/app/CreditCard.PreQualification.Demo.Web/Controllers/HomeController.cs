using CreditCard.PreQualification.Demo.Web.Infrastructure.Cqs;
using CreditCard.PreQualification.Demo.Web.Infrastructure.DateTime;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CreditCard.PreQualification.Demo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDateTimeService _dateTime;
        private readonly ICommandHandler<LogCustomerApplication> _logHandler;

        public HomeController(IDateTimeService dateTime, ICommandHandler<LogCustomerApplication> logHandler)
        {
            _dateTime = dateTime;
            _logHandler = logHandler;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IndexPostModel model)
        {
            if (!model.DateOfBirthIsValid())
            {
                ModelState.AddModelError("DateOfBirth", "Please enter a valid date of birth");
            }

            if (!ModelState.IsValid) return Index();

            var querier = new RecommendedCardsQuerier(_dateTime);
            var results = querier.Query(model.GetDateOfBirth(), model.AnnualIncome.Value);

            _logHandler.Handle(new LogCustomerApplication
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.GetDateOfBirth(),
                AnnualIncome = model.AnnualIncome.Value,
                RecommendedCards = results.Select(r => r.Name).ToArray()
            });

            return View("Recommendations", results);
        }

        [HttpGet]
        public IActionResult Recommendation()
        {
            return View();
        }
    }
}