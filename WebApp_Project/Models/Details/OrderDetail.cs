using System;

namespace WebApp_Project.Models.Details
{
    public class OrderDetail
    {

        public OrderDetail(Order order, User rider)
        {
            this.Id = order.Id;
            this.Place = order.Place;
            this.Restaurant = order.Restaurant;
            this.Price = order.Price;
            this.Menu = order.Menu;
            this.Rider = rider;
        }

        public OrderDetail(Order order, User rider, User buyer)
        {
            this.Id = order.Id;
            this.Place = order.Place;
            this.Restaurant = order.Restaurant;
            this.Price = order.Price;
            this.Menu = order.Menu;
            this.Rider = rider;
            this.Buyer = buyer;
        }

        public int Id { get; set; }

        public User Rider { get; set; }

        public User Buyer { get; set; }

        public string Place { get; set; }

        public string Restaurant { get; set; }

        public String? Menu { get; set; }

        public String? Price { get; set; }
    }


    /*   public OrderDetail(Order order, User rider)
       {
           this.Id = order.Id;
           this.Place = order.Place;
           this.Restaurant = order.Restaurant;
           this.Price = order.Price;
           this.Menu = order.Menu;
           this.Rider = rider;
       }

       public int Id { get; set; }

       public User Rider { get; set; }

       public User Buyer { get; set; }

       public string Place { get; set; }

       public string Restaurant { get; set; }

       public String? Menu { get; set; }

       public String? Price { get; set; }
   }
*/

}
