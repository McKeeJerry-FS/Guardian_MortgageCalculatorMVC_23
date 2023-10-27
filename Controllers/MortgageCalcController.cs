using Guardian_MortgageCalculator.Models;
using Microsoft.AspNetCore.Mvc;

namespace Guardian_MortgageCalculator.Controllers
{
    public class MortgageCalcController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoanDataModel model)
        {
            return View(model);
        }
    }
}
