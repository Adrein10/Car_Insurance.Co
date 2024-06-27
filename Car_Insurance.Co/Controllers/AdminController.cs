using Car_Insurance.Co.Data;

using Microsoft.AspNetCore.Mvc;

namespace Car_Insurance.Co.Controllers
{
    public class AdminController : Controller
    {
        private readonly car_insuranceContext context;
        private readonly IHttpContextAccessor accessor;

        public AdminController(car_insuranceContext context,IHttpContextAccessor accessor)
        {
            this.context = context;
            this.accessor = accessor;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult login()
        {
            return View();
        }
        public IActionResult logout()
        {
            return View();
        }
        public IActionResult policy()
        {
            return View();
        }
    }
}
