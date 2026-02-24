using Microsoft.AspNetCore.Mvc;

namespace MVC_IMDB_Practice.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
