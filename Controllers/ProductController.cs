using ASP_MVC_PROJ.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC_PROJ.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DisplayProducts()
        {
            List<Product> products = new List<Product>
            {
                new Product { Id = 1, Name = "Some product #1", Price = 12 },
                new Product { Id = 2, Name = "Some product #2", Price = 30 },
                new Product { Id = 3, Name = "Some product #3", Price = 50 },
                new Product { Id = 4, Name = "Some product #4", Price = 9 }
            };

            return View(products);
        }
    }
}
