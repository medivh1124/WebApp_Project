using Microsoft.Build.Framework;

namespace WebApp_Project.Models.Forms
{
    public class PostOrderForm
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Menu { get; set; }

        [Required]
        public string Count { get; set; }

    }
}
