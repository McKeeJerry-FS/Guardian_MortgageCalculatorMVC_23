using Guardian_MortgageCalculator.Models;
using Microsoft.AspNetCore.Mvc;

namespace Guardian_MortgageCalculator.Controllers
{
    public class MortgageCalcController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            LoanDataModel loan = new LoanDataModel() { 
                MonthlyPayment = 0.0m,
                TotalInterest = 0.0m,
                TotalCost = 0.0m,
                InterestRate = 5.0m,
                LoanAmount = 25000.00m,
                Term = 60

            };

            return View(loan);
        }

        [HttpPost]
        public IActionResult Index(LoanDataModel loan)
        {
            return View(loan);
        }
    }
}
