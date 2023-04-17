using Microsoft.AspNetCore.Mvc;
using WebApp_Project.Data;

namespace WebApp_Project.Controllers
{
    public class BuyerController : Controller
    {
        ApplicationDBContext dbContext;

        public BuyerController(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
         /*   var a = dbContext.Orders.Where(order => order.BuyerId == null);*/
            return View();
        }
    }
}
