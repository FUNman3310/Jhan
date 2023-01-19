using Microsoft.EntityFrameworkCore;

namespace Jhuan.Models
{
    public class JhuanContext:DbContext
    {
        public JhuanContext(DbContextOptions options):base(options) { }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Slider> sliders { get; set; } 

        public DbSet<Color> Colors { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Size> Sizes { get; set; }

        public DbSet<BrandLogo> BrandLogos { get; set;}
    }
}
