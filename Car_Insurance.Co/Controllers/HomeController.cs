using Car_Insurance.Co.Data;
using Car_Insurance.Co.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Car_Insurance.Co.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly car_insuranceContext context;
        private readonly IHttpContextAccessor accessor;

        public HomeController(ILogger<HomeController> logger,car_insuranceContext context,IHttpContextAccessor accessor)
        {
            _logger = logger;
            this.context = context;
            this.accessor = accessor;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Insurance()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult NewsDetail()
        {
            return View();
        }
        public IActionResult NotFound()
        {
            return View();
        }
        public IActionResult ServiceDetail()
        {
            return View();
        }
        public IActionResult Services()
        {
            return View();
        }
        public IActionResult Signup()
        {
            return View();
        }
        public IActionResult Team()
        {
            return View();
        }
        public IActionResult TeamDetail()
        {
            return View();
        }
        public IActionResult Tearms()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}