using Car_Insurance.Co.Data;
using Car_Insurance.Co.Models;

using Microsoft.AspNetCore.Identity;
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
            var show = context.UserDetails.ToList();
            return View(show);
        }
        [HttpPost]
        public IActionResult CustomerDelete(int id)
        {
            var user = context.UserDetails.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            context.UserDetails.Remove(user);
            context.SaveChanges();

            return RedirectToAction("customerDetails"); 
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

        public IActionResult RegisterAdmin()
        {
            return View();
        }
        [HttpPost]
		public IActionResult RegisterAdmin(AdminDetail admin,string cpassword)
		{
            if(cpassword == admin.AdminPassword)
            {
            context.AdminDetails.Add(admin);
            context.SaveChanges();
			return View("Index");
            }
            else
            {
                ViewBag.notsame = "Password is not match";
            }
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

    }
}
