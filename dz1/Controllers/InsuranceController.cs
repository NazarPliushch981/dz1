using Microsoft.AspNetCore.Mvc;
using dz1.Models;

namespace dz1.Controllers
{
    public class InsuranceController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            InsuranceViewModel model = new InsuranceViewModel();
            model.CityType = "Kyiv"; 
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(InsuranceViewModel model)
        {

            if (model.EngineCapacity <= 0 || model.DriverExperienceYears < 0)
            {
                model.ErrorMessage = "Невірний обєм двигуна або стаж!";
                model.CalculatedPrice = 0;
                return View(model);
            }

            double price = 1000;


            if (model.EngineCapacity <= 1600)
            {
                price = price * 1.0;
            }


              if (model.EngineCapacity > 1600 && model.EngineCapacity <= 2000)
             {
                price = price * 1.3;
             }

            if (model.EngineCapacity > 2000)
            {
                price = price * 1.6;
            }


            if (model.CityType == "Kyiv")
            {
                price = price * 1.8;
            }


            else if (model.CityType == "LargeCity")
            {
                price = price * 1.3;
            }

            else
             {
                price = price * 1.0;
             }

            if (model.DriverExperienceYears > 3)
            {
                double discount = price * 0.10; // 10%
                price = price - discount;
            }

            if (model.HasDiscountCategory == true)
            {
                double discount2 = price * 0.20; // 20%
                price = price - discount2;
            }

            model.CalculatedPrice = price;
            model.ErrorMessage = "";

            return View(model);
        }
    }
}