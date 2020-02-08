using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            //TODO validate DOB is correct date

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

        [Required(ErrorMessage =  "Please enter your annual income")]
        public int? AnnualIncome { get; set; }
    }
}