using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApp_Project.Data;
using WebApp_Project.Models;
using WebApp_Project.Models.Forms;

namespace WebApp_Project.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDBContext _db;

        public UserController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUser(User obj)
        {
            _db.Users.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        /*public IActionResult Profile()
        {
            IEnumerable<User> allUser = _db.Users;
            return View(allUser);
        }*/

        public IActionResult Profile()
        {
            var currentUser = HttpContext.Session.GetString("_CurrentUser");
            var profile = _db.Users.Where(user => user.UserName == currentUser).FirstOrDefault();
            ViewData["profile"] = profile;
            return View();
        }
        public IActionResult Sign_in() 
        { 
            return View("~/Views/Home/Index.cshtml"); }
        }
}
