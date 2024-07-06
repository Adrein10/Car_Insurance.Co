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
            var username = accessor.HttpContext.Session.GetString("username");
            if (username != null)
            {
                ViewBag.sessionuser = username;
                return View();
            }
            return View();
        }
        public IActionResult Blog()
        {
            var username = accessor.HttpContext.Session.GetString("username");
            if (username != null)
            {
                ViewBag.sessionuser = username;
                return View();
            }
            return View();
        }
        public IActionResult Contact()
        {
            var username = accessor.HttpContext.Session.GetString("username");
            if (username != null)
            {
                ViewBag.sessionuser = username;
                return View();
            }
            return View();
        }
        public IActionResult InsuranceForm()
        {
            var username = accessor.HttpContext.Session.GetString("username");
            if (username != null)
            {
                ViewBag.sessionuser = username;
            }
            else
            {
                return View("Login");
            }
            InsuranceViewModel insuranceForm = new InsuranceViewModel()
            {
                    userDetailTable = new UserDetail(),
                userCarDetail = new UserCarsDetail(),
                insurancePolicyTable = new InsurancePolicy(),
                orderDetail=new OrderDetail(),
                orderStatus = new OrderStatus()
            };
            return View(insuranceForm);
        }
        [HttpPost]
        public IActionResult InsuranceForm(InsuranceViewModel insurance,UserDetail user)
        {

            var Ishow = context.UserDetails.Where(option => option.Useremail == user.Useremail || option.Username == user.Useremail && option.Userpassword == user.Userpassword).FirstOrDefault();
            if (Ishow != null)
            {
                accessor.HttpContext.Session.SetString("username", Ishow.Username);
                accessor.HttpContext.Session.SetString("useremail", Ishow.Useremail);
                accessor.HttpContext.Session.SetString("userpass", Ishow.Userpassword);
                return View();
            }
            else
            {
                ViewBag.failed = "Incorrect User Or Password";
            }
            var show = context.UserDetails.Where(option => option.Useremail == insurance.userDetailTable.Useremail && option.Userpassword == insurance.userDetailTable.Userpassword).FirstOrDefault();
            if(show != null)
            {
                UserCarsDetail userCars = new UserCarsDetail()
                {
                    Carcolor = insurance.userCarDetail.Carcolor,
                    Carmodel = insurance.userCarDetail.Carmodel,
                    Carname = insurance.userCarDetail.Carname,
                    Carnumber = insurance.userCarDetail.Carnumber,
                    Carrcc = insurance.userCarDetail.Carrcc,
                    Chasisnumber = insurance.userCarDetail.Chasisnumber,
                    City = insurance.userCarDetail.City,
                    Enginenumber = insurance.userCarDetail.Enginenumber,
                    PolicyId = insurance.userCarDetail.PolicyId,
                    Purpose = insurance.userCarDetail.Purpose,
                    Userid = show.Id,


                };




                var lastIndexId = context.UserCarsDetails.ToList();



                var lastIndex = lastIndexId.Count; // Index of the last item
                var lastItem = lastIndexId[lastIndex-1];

                OrderDetail orderDetail = new OrderDetail()
                {

                    CarId = lastItem.Id + 1,
                    StatusId = 1,
                    PlaneId = insurance.orderDetail.PlaneId
                };



                InsurancePolicy insurancePolicy = new InsurancePolicy()
                {
                    StartDate = insurance.insurancePolicyTable.StartDate,
                };
                insurancePolicy.UserCarsDetails = new List<UserCarsDetail> { userCars };


                context.UserCarsDetails.Add(userCars);
                context.InsurancePolicies.Add(insurancePolicy);
                context.SaveChanges();
                context.OrderDetails.Add(orderDetail);
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

            var username = accessor.HttpContext.Session.GetString("username");
            if (username != null)
            {
                ViewBag.sessionuser = username;
                return View();
            }
            return View();
        }
        public IActionResult NotFound()
        {
            var username = accessor.HttpContext.Session.GetString("username");
            if (username != null)
            {
                ViewBag.sessionuser = username;
                return View();
            }
            return View();
        }
        public IActionResult ServiceDetail()
        {
            var username = accessor.HttpContext.Session.GetString("username");
            if (username != null)
            {
                ViewBag.sessionuser = username;
                return View();
            }
            return View();
        }
        public IActionResult Services()
        {
            var username = accessor.HttpContext.Session.GetString("username");
            if (username != null)
            {
                ViewBag.sessionuser = username;
                return View();
            }
            return View();
        }
        public IActionResult Signup()
        {
            var username = accessor.HttpContext.Session.GetString("username");
            if (username != null)
            {
                ViewBag.sessionuser = username;
                return RedirectToAction("NotFound");
            }
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
            var username = accessor.HttpContext.Session.GetString("username");
            if (username != null)
            {
                ViewBag.sessionuser = username;
                return RedirectToAction("NotFound");
            }
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
            var username = accessor.HttpContext.Session.GetString("username");
            if (username != null)
            {
                ViewBag.sessionuser = username;
                return View();
            }
            return View();
        }
        public IActionResult TeamDetail()
        {
            var username = accessor.HttpContext.Session.GetString("username");
            if (username != null)
            {
                ViewBag.sessionuser = username;
                return View();
            }
            return View();
        }
        public IActionResult Tearms()
        {
            var username = accessor.HttpContext.Session.GetString("username");
            if (username != null)
            {
                ViewBag.sessionuser = username;
                return View();
            }
            return View();
        }
        public IActionResult Privacy()
        {
            var username = accessor.HttpContext.Session.GetString("username");
            if (username != null)
            {
                ViewBag.sessionuser = username;
                return View();
            }
            return View();
        }

		public IActionResult BillingInfo()
		{
            var username = accessor.HttpContext.Session.GetString("username");
            if (username != null)
            {
                ViewBag.sessionuser = username;
                return View();
            }
            return View();
		}
        public IActionResult ThankyouForm()
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