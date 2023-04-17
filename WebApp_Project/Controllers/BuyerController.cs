using Microsoft.AspNetCore.Mvc;
using WebApp_Project.Data;
using WebApp_Project.Models.Details;
using WebApp_Project.Models;

namespace WebApp_Project.Controllers
{
    public class BuyerController : Controller
    {
        ApplicationDBContext dbContext;

        public BuyerController(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index(Order obj)
        {
            /*ชี้ไปที่ ตาราง order : column BuyerId ที่เป็น null*/
            var a = dbContext.Orders.Where(order => order.BuyerId == null);
            var buyerId = HttpContext.Session.GetInt32("_CurrentUserId");


            return View();
        }

        /*public IActionResult Index()
        {
            var a = dbContext.Orders.Where(order => order.BuyerId == null);
            
            return View();
        }*/

        public IActionResult YourOrder()
        {
            List<OrderDetail> details = new();
            List<Order> allOrder = dbContext.Orders.ToList();
            foreach (Order order in allOrder)
            {
                var rider = dbContext.Users.Find(order.RiderId);
                var detail = new OrderDetail(order, rider!);
                details.Add(detail);
            }
            return View(details);
        }

    }
}
