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

        public IActionResult customerDetails()
        {
            return View();
        }

        public IActionResult vehicalInfo()
        {
            return View();
        }

        public IActionResult insuranceApproval()
        {
            return View();
        }

        public IActionResult insurances()
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
<<<<<<< HEAD

=======
        public IActionResult RegisterAdmin()
        {
            return View();
        }
        public IActionResult AdminInfo()
        {
            return View();
        }
        public IActionResult policy()
        {
            return View();
        }
>>>>>>> 8aca920da41b2a6d626c4be2e62ecbda05f56a43
    }
}
