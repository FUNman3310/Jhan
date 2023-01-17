using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jhuan.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [StringLength(maximumLength:20)]
        public string  SubTitle { get; set; }
        [StringLength(maximumLength: 30)]
        public string Title { get; set; }
        [StringLength(maximumLength: 120)]
        public string Description { get; set; }
        public string? Image { get; set; }
        [StringLength(maximumLength: 20)]
        public string RedirectUrlText { get; set; }
        public string RedirectUrl { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }



    }
}
