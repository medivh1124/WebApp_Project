using Microsoft.AspNetCore.Mvc;
using WebApp_Project.Data;
using WebApp_Project.Filters;
using WebApp_Project.Models;
using WebApp_Project.Models.Details;

namespace WebApp_Project.Controllers
{
    public class RiderController : Controller
    {

        private readonly ApplicationDBContext _db;

        public RiderController(ApplicationDBContext db)
        {
            _db = db;
        }

        [AuthorizeSession]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AuthorizeSession]
        public IActionResult Index(Order obj)
        {
            var riderId = HttpContext.Session.GetInt32("_CurrentUserId");
            obj.RiderId = riderId;
            _db.Orders.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("PostOrder");
        }

        [AuthorizeSession]
        public IActionResult PostOrder()
        {
            var riderId = HttpContext.Session.GetInt32("_CurrentUserId");
            List<Order> allOrder = _db.Orders.Where(order => order.RiderId == riderId).ToList();
            return View(allOrder);
        }
    }
}
