using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;


namespace uyg.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Categories")]
        public IActionResult Categories()
        {
            return View();
        }

        [Route("Products")]
        public IActionResult Products()
        {
            return View();
        }
    }
}
