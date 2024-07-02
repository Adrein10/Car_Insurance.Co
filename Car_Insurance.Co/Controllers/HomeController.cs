using Car_Insurance.Co.Data;
using Car_Insurance.Co.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var username = accessor.HttpContext.Session.GetString("username");
            if(username != null)
            {
                ViewBag.sessionuser = username;
                return View();
            }
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
        public IActionResult InsuranceForm()
        {
            InsuranceViewModel insuranceForm = new InsuranceViewModel()
            {
                    userDetailTable = new UserDetail(),
                userCarDetail = new UserCarsDetail(),
                insurancePolicyTable = new InsurancePolicy()

            };
            return View(insuranceForm);
        }
        [HttpPost]
        public IActionResult InsuranceForm(InsuranceViewModel insurance)
        {
            var show = context.UserDetails.Where(option => option.Useremail == insurance.userDetailTable.Useremail && option.Userpassword == insurance.userDetailTable.Userpassword).FirstOrDefault();
            if(show != null)
            {
                context.UserCarsDetails.Add(insurance.userCarDetail);
                context.InsurancePolicies.Add(insurance.insurancePolicyTable);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.failedpass = "Incorrect password";
            }
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
   
        [HttpPost]
        public IActionResult Signup(UserDetail user,string ConfirmPassword)
        {
            var name = context.UserDetails.Where(option => option.Username == user.Username).FirstOrDefault();
            var email = context.UserDetails.Where(option => option.Useremail == user.Useremail).FirstOrDefault();
            if(name != null && email != null)
            {
                ViewBag.uniquename = "The name you entered is already exist";
                ViewBag.uniqueemail = "The email you entered is already exist";
            }
            else if(name != null)
            {
                ViewBag.uniquename = "The name you entered is already exist";
            }else if(email != null)
            {
                ViewBag.uniqueemail = "The email you entered is already exist";
            }
            else
            {

            if(ConfirmPassword == user.Userpassword)
            {
                context.UserDetails.Add(user);
                context.SaveChanges();
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.confirmpass = "Password is not match";
            }
            }
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserDetail user)
        {
            var show = context.UserDetails.Where( option => option.Useremail == user.Useremail || option.Username == user.Useremail && option.Userpassword == user.Userpassword).FirstOrDefault();
            if (show != null)
            {
                accessor.HttpContext.Session.SetString("username", show.Username);
                accessor.HttpContext.Session.SetString("useremail", show.Useremail);
                accessor.HttpContext.Session.SetString("userpass", show.Userpassword);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.failed = "Incorrect User Or Password";
            }
            return View();
        }
        public IActionResult Logout()
        {
            var user = accessor.HttpContext.Session.GetString("username");
            if(user != null)
            {
                accessor.HttpContext.Session.Clear();
                return RedirectToAction("Index");
            }
            return RedirectToAction("NotFound");
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

		public IActionResult BillingInfo()
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