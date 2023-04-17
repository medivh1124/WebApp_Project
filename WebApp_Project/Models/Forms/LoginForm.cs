using System.ComponentModel.DataAnnotations;

namespace WebApp_Project.Models.Forms
{
    public class LoginForm
    {
        [Required]
        public string Username { get; set; }

        [Required] 
        public string Password { get; set; }
    }
}
