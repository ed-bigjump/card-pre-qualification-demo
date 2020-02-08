using System.Linq;
using System.Threading.Tasks;
using CreditCard.PreQualification.Demo.Web.Infrastructure.DateTime;
using Microsoft.AspNetCore.Mvc;

namespace CreditCard.PreQualification.Demo.Web.Controllers
{
    public class HomeController : Controller
    {
        private IDateTimeService _dateTime;

        public HomeController(IDateTimeService dateTime)
        {
            _dateTime = dateTime;
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

            //TODO log that this customer was recommended cards

            return View("Recommendations", results);
        }

        [HttpGet]
        public IActionResult Recommendation()
        {
            return View();
        }
    }
}