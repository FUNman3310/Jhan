using Jhuan.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jhuan.Areas.Manage.Controllers
{
    public class ProductController : Controller
    {
        private readonly JhuanContext _jhuanContext;
        private readonly IWebHostEnvironment _env;

        public ProductController(JhuanContext jhuanContext,IWebHostEnvironment env)
        {
            _jhuanContext = jhuanContext;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_jhuanContext.Products.ToList());
        }

        public IActionResult Create() 
        {
            return  View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            return View();
        }
        public IActionResult Update(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(int id,Product product)
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
    }
}
