using Car_Insurance.Co.Data;
using Car_Insurance.Co.Models;

using Humanizer;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var showmessage = context.Feedbacks.Count();
            ViewBag.ShowMessage = showmessage;
            var showcount = context.AdminDetails.Count();
            ViewBag.Showcount = showcount;
            var showCust = context.UserDetails.Count();
            ViewBag.ShowCust = showCust;
            var showvehicle = context.UserCarsDetails.Count();
            ViewBag.ShowVehicle = showvehicle;
            var finddata = context.UserCarsDetails
                .Include(option => option.User)
                .Include(option => option.Policy)
                .Include(option => option.OrderDetails)
                .ThenInclude(OrderDetail => OrderDetail.Plane)
                .ToList();
            //var SAdminname = accessor.HttpContext.Session.GetString("adminname");
            //var SCeoname = accessor.HttpContext.Session.GetString("ceoname");
            //if(SAdminname != null || SCeoname != null)
            //{
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("Login");
            //}
            return View(finddata);
        }

        public IActionResult customerDetails()
        {
            var showCust = context.UserDetails.Count();
            ViewBag.ShowCust = showCust;

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
            var show = context.UserCarsDetails.Include(option => option.User).ToList();
            return View(show);
        }

        public IActionResult insuranceApproval()
        {
            InsuranceApprovalView approvalView = new InsuranceApprovalView()
            {
                cardetail = context.UserCarsDetails.Include(option => option.User).Include(option => option.OrderDetails).ThenInclude(OrderDetail => OrderDetail.Plane).ToList(),
                orderstatus = new OrderDetail()
            };
            return View(approvalView);
        }
        public IActionResult EditStatus(int id)
        {
            var orderToUpdate = context.UserCarsDetails
                                       .Include(option => option.OrderDetails)
                                       .FirstOrDefault(context => context.Id == id);
            if (orderToUpdate != null)
            {
                // Assuming OrderDetails is a collection, find the specific OrderDetail to update
                var orderDetailToUpdate = orderToUpdate.OrderDetails.FirstOrDefault();

                if (orderDetailToUpdate != null)
                {
                    // Update the status
                    orderDetailToUpdate.StatusId = 2;
                    context.OrderDetails.Update(orderDetailToUpdate);

                    // Save changes
                    context.SaveChanges();
                }
            }

            // Redirect to insuranceApproval action
            return RedirectToAction("insuranceApproval");
        }


        public IActionResult insurances()
        {
            var find = context.OrderDetails
                .Include(option => option.Car)
                .Include(option => option.Plane)
                .Where(option => option.StatusId ==  2)
                .ToList();
            //var error = 123;
            return View(find);
        }
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(AdminDetail admin)
        {
            var show = context.AdminDetails
                .Where(option => option.AdminName == admin.AdminName || option.AdminEmail == admin.AdminName && option.AdminPassword == admin.AdminPassword).FirstOrDefault();

            var ceo = context.CeoDetails
                .Where(option => option.CeoEmail == admin.AdminName || option.CeoName == admin.AdminName && option.CeoPassword == admin.AdminPassword).FirstOrDefault();
          
            if(show != null)
            {
                accessor.HttpContext.Session.SetString("adminname", show.AdminName);
                accessor.HttpContext.Session.SetString("adminemail", show.AdminEmail);
                accessor.HttpContext.Session.SetString("adminpass", show.AdminPassword);
                accessor.HttpContext.Session.SetString("adminid", Convert.ToString(show.Id));
                return RedirectToAction("Index");
            }else if(ceo != null)
            {
                accessor.HttpContext.Session.SetString("ceoname", ceo.CeoName);
                accessor.HttpContext.Session.SetString("ceoemail", ceo.CeoEmail);
                accessor.HttpContext.Session.SetString("ceopass", ceo.CeoPassword);
                accessor.HttpContext.Session.SetString("ceoid", Convert.ToString(ceo.Id));
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Adminloginfailed = "Incorect User Or Password";
            }
            return View();
        }
        public IActionResult logout()
        {
            var admin = accessor.HttpContext.Session.GetString("adminname");
            var ceo = accessor.HttpContext.Session.GetString("ceoname");
            if (admin != null || ceo != null)
            {
                accessor.HttpContext.Session.Clear();
                return RedirectToAction("Login");
            }
            return RedirectToAction("Login");
        }

        public IActionResult RegisterAdmin()
        {
            return View();
        }
        [HttpPost]
		public IActionResult RegisterAdmin(AdminDetail admin,string cpassword)
		{
            var name = context.AdminDetails.Where(option => option.AdminName == admin.AdminName).FirstOrDefault();
            var email = context.AdminDetails.Where(option => option.AdminEmail == admin.AdminEmail).FirstOrDefault();
            if (name != null && email != null)
            {
                ViewBag.Adminuniquename = "The name you entered is already exist";
                ViewBag.Adminuniqueemail = "The email you entered is already exist";
            }
            else if (name != null)
            {
                ViewBag.Adminuniquename = "The name you entered is already exist";
            }
            else if (email != null)
            {
                ViewBag.Adminuniqueemail = "The email you entered is already exist";
            }
            else
            {

                if (cpassword == admin.AdminPassword)
                {
                    context.AdminDetails.Add(admin);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.notsame = "Password is not match";
                }
            }
            return View();
        }

        public IActionResult AdminInfo()
        {
            var showcount = context.AdminDetails.Count();
            ViewBag.Showcount = showcount;

            var show = context.AdminDetails.ToList();
            return View(show);
        }
        public IActionResult AdminInfoUpdate(int id)
        {
            var show = context.AdminDetails.Find(id);
            return View(show);
        }
        [HttpPost]
        public IActionResult AdminInfoUpdate(AdminDetail admin, int id)
        {
           
                var update = context.AdminDetails.Find(id);
                if(update != null)
            {
               update.AdminName = admin.AdminName;
                update.AdminEmail = admin.AdminEmail;
                update.AdminPassword = admin.AdminPassword;
                update.RegisterDate = admin.RegisterDate;
            
                context.AdminDetails.Update(update);
                context.SaveChanges();
                return RedirectToAction("AdminInfo");
            }
            else
            {
                ViewBag.failed = "Incorrect User Or Password";
            }

            return View();
            }

        public IActionResult AdminInfoDelete(int id)
        {
            var admin = context.AdminDetails.Find(id);
            if (admin == null)
            {
                return NotFound();
            }

            context.AdminDetails.Remove(admin);
            context.SaveChanges();

            return RedirectToAction("AdminInfo");
        }


        public IActionResult profile()
        {
            
            return View();
        }

        public IActionResult Mails()
        {
            var email = context.Feedbacks.ToList();
            return View(email);
        }
        public IActionResult DeleteMail(int id)
        {
            var mail = context.Feedbacks.Find(id);
            if (mail == null)
            {
                return NotFound();
            }

            context.Feedbacks.Remove(mail);
            context.SaveChanges();
            return RedirectToAction("Mails");
            
        }
        public IActionResult Re_newInsurance()
        {
            return View();
        }
        public IActionResult ExpiredInsurance()
        {
            return View();
        }
        public IActionResult policy()
        {
            return View();
        }

    }
}
