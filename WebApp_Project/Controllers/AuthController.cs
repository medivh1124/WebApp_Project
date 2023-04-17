using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp_Project.Data;
using WebApp_Project.Models.Forms;

namespace WebApp_Project.Controllers
{
    public class AuthController : Controller
    {

        private readonly ApplicationDBContext dbContext;

        public AuthController(ApplicationDBContext db)
        {
            dbContext = db;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(LoginForm form)
        {
            try
            {
                var user = dbContext.Users.Where(user => user.UserName == form.Username).First();
                
                if (user.Password == form.Password)
                {
                    /*set ค่าลงใน session*/
                    HttpContext.Session.SetString("_CurrentUser", user.UserName);
                    HttpContext.Session.SetInt32("_CurrentUserId", user.Id);

                    return View();
                }
                else
                {
                    Console.WriteLine("No.");
                    return View();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("User not found.");
                return View();
            }
        }

        public IActionResult Check()
        {
            if(HttpContext.Session.GetString("_CurrentUser") != null)
            {
                return Content("Already login.");
            }
            else
            {
                return Content("Please login.");
            }
        }


    }
}
