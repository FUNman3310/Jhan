using Microsoft.EntityFrameworkCore;

namespace Jhuan.Models
{
    public class JhuanContext:DbContext
    {
        public JhuanContext(DbContextOptions options):base(options) { }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Slider> sliders { get; set; } 
    }
}
