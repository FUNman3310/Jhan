using System.ComponentModel.DataAnnotations.Schema;

namespace Jhuan.Models
{
    public class BrandLogo
    {
        public int Id { get; set; }

        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
