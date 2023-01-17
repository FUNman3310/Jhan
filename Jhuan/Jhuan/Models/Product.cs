using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization.Formatters;

namespace Jhuan.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Image { get; set; }

        public string Name { get; set; }
        public string SalePrice { get; set; }
        public string DiscountPrice { get; set; }
        
        public string CostPrice { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }


    }
}
