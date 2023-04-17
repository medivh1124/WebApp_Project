using System.ComponentModel.DataAnnotations;

namespace WebApp_Project.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int? RiderId { get; set; }

        public int? BuyerId { get; set; }

        [Required]
        public string Place { get; set; }

        [Required]
        public string Restaurant { get; set; }

        public String? Menu { get; set; }

        public String? Price { get; set; }
    }
}
