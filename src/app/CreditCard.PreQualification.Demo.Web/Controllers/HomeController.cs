using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CreditCard.PreQualification.Demo.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IndexPostModel model)
        {
            if (!ModelState.IsValid) return Index();

            return Index();
        }

        [HttpGet]
        public IActionResult Recommendation()
        {
            return View();
        }
    }

    public class IndexPostModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int AnnualIncome { get; set; }
    }
}