using Microsoft.EntityFrameworkCore;
using WebApp_Project.Models;

namespace WebApp_Project.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        /* เป็นตัวแทนของตาราง student ที่อยู่ในฐานข้อมูล*/
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
    
    }
}
