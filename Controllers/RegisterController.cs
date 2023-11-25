using LR10.Models;
using Microsoft.AspNetCore.Mvc;

namespace LR10.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.SelectedProduct == "Основи" && model.ConsultationDate.DayOfWeek == DayOfWeek.Monday)
                {
                    ModelState.AddModelError("ConsultationDate", "Консультація з 'Основи' не проходить в понеділок!");
                    return View("Index", model);
                }

                return RedirectToAction("Success");
            }

            return View("Index", model);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
