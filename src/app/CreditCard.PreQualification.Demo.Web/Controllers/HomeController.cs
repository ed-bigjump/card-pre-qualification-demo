using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CreditCard.PreQualification.Demo.Web.Infrastructure.DateTime;
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
            if (!model.DateOfBirthIsValid())
            {
                ModelState.AddModelError("DateOfBirth", "Please enter a valid Date of Birth");
            }

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

        [Required(ErrorMessage =  "Please enter your annual income")]
        public int? AnnualIncome { get; set; }
    }
}