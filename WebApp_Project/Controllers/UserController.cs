using Microsoft.AspNetCore.Mvc;
using WebApp_Project.Data;
using WebApp_Project.Models;

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
            //return View(obj);
            /* return View();*/
        }
        public IActionResult Sign_in() 
        { 
            return View("~/Views/Home/Index.cshtml"); }
        }
}
