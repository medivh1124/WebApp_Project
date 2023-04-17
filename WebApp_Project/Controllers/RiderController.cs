using Microsoft.AspNetCore.Mvc;
using WebApp_Project.Data;
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

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Order obj)
        {
            obj.RiderId = HttpContext.Session.GetInt32("_CurrentUserId");
            _db.Orders.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("PostOrder");
        }

        public IActionResult PostOrder() 
        {
            List<OrderDetail> details = new();
            List<Order> allOrder = _db.Orders.ToList();
            foreach (Order order in allOrder)
            {
                var rider = _db.Users.Find(order.RiderId);
                var detail = new OrderDetail(order, rider!);
                details.Add(detail);
                /*RedirectToAction("BuyerOrder");*/
            }
            return View(details);
        }

        public IActionResult BuyerOrder()
        {
            return View();
        }

 
    }
}
