using Microsoft.AspNetCore.Mvc;
using WebApp_Project.Data;
using WebApp_Project.Models.Details;
using WebApp_Project.Models;
using WebApp_Project.Models.Forms;
using WebApp_Project.Filters;
using NuGet.Packaging;

namespace WebApp_Project.Controllers
{
    public class BuyerController : Controller
    {
        ApplicationDBContext dbContext;

        public BuyerController(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [AuthorizeSession]
        public IActionResult Index()
        {
            /*var a = dbContext.Orders.Where(order => order.BuyerId == null);*/

            return View();
        }

        [HttpPost]
        public IActionResult Index(Order obj)
        {
            return View();
        }

        /*public IActionResult Index(Order obj)
        {
            *//*ชี้ไปที่ ตาราง order: column BuyerId ที่เป็น null*//*
            var a = dbContext.Orders.Where(order => order.BuyerId == null);
            var buyerId = HttpContext.Session.GetInt32("_CurrentUserId");
            obj.BuyerId = buyerId;


           
            return Content("A");

        }*/

        [AuthorizeSession]
        public IActionResult Detail(int id)
        {
            ViewData["OrderId"] = id;
            return View("Index"); 
        }

        [AuthorizeSession]
        public IActionResult PostOrder()
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

        [AuthorizeSession]

        public IActionResult YourOrder()
        {
            List<OrderDetail> details = new();
            var riderId = HttpContext.Session.GetInt32("_CurrentUserId");
            //ที่พิ่มมา
            var buyerId = HttpContext.Session.GetInt32("_CurrentUserId");
            List<Order> allOrder = new List<Order>();
            List<Order> orderOfBuyer = new List<Order>();
            List<Order> orderOfRider = new List<Order>();
            orderOfRider = dbContext.Orders.Where(order => order.RiderId == riderId).ToList();
            orderOfBuyer = dbContext.Orders.Where(order => order.BuyerId == buyerId).ToList();
            allOrder.AddRange(orderOfRider);
            allOrder.AddRange(orderOfBuyer);
            //

            foreach (Order order in allOrder)
            {
                var rider = dbContext.Users.Find(order.RiderId);
                //เพิ่มมา
                var buyer = dbContext.Users.Find(order.BuyerId);
                var detail = new OrderDetail(order, rider!, buyer!);
                //
                details.Add(detail);
            }
            return View(details);
        }


        /* public IActionResult PostOrder()
        {
            var riderId = HttpContext.Session.GetInt32("_CurrentUserId");
            List<Order> allOrder = _db.Orders.Where(order => order.RiderId == riderId).ToList();
            return View(allOrder);
        }*/


        /*public IActionResult YourOrder()
        {
            List<OrderDetail> details = new();
            List<Order> allOrder = dbContext.Orders.ToList();
            foreach (Order order in allOrder)
            {
                var rider = dbContext.Users.Find(order.RiderId);
                //เพิ่มมา
                var buyer = dbContext.Users.Find(order.BuyerId);
                var detail = new OrderDetail(order, rider!, buyer!);
                //
                details.Add(detail);
            }
            return View(details);
        }*/


        


        [HttpPost]
        public IActionResult YourOrder(PostOrderForm form)
        {
            var buyerId = HttpContext.Session.GetInt32("_CurrentUserId");
            if (buyerId == null)
            {
                return Content("Please login");
            }
            else
            {
                var order = dbContext.Orders.Find(form.Id) as Order;
                order!.Menu = form.Menu;
                order!.Price = form.Count;
                order!.BuyerId = buyerId;
                dbContext.Update(order);
                dbContext.SaveChanges();
                return Content("Update Success");
            }

        }


    }

}
