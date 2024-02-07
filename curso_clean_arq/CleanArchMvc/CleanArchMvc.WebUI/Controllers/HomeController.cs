using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();// objetos olista do home, category ou product.
        }

        public IActionResult Privacy()
        {
            return View(); // retorna a view privacy.
        }
    }
}
