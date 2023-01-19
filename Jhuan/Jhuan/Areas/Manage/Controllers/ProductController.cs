using Jhuan.Helper;
using Jhuan.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jhuan.Areas.Manage.Controllers
{
    [Area("Manage")]
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
            ViewBag.Color = _jhuanContext.Colors.ToList();
            ViewBag.Size = _jhuanContext.Sizes.ToList();
            ViewBag.Category = _jhuanContext.Categories.ToList();

            return  View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            
            string name = product.ImageFile.FileName;

           

            product.Image = FileManager.SaveFile(_env.WebRootPath, "uploads/product", product.ImageFile);

            _jhuanContext.Products.Add(product);
            _jhuanContext.SaveChanges();


            return RedirectToAction("index");
        }
        public IActionResult Update(int id)
        {
            ViewBag.Color = _jhuanContext.Colors.ToList();
            ViewBag.Size = _jhuanContext.Sizes.ToList();
            ViewBag.Category = _jhuanContext.Categories.ToList();
            Product product = _jhuanContext.Products.Find(id);

            if (product == null) return View("Error");
            return View(product);
        }
        [HttpPost]
        public IActionResult Update(int id,Product product)
        {
            if (product == null) return View("Error");

            Product existProduct = _jhuanContext.Products.FirstOrDefault(product => product.Id == id);

            if (product.ImageFile != null)
            {
                string name = FileManager.SaveFile(_env.WebRootPath, "uploads/slider", product.ImageFile);

                existProduct.Image = name;
            }

            existProduct.Name = product.Name;
            existProduct.SizeId= product.SizeId;
            existProduct.ColorId= product.ColorId;
            existProduct.CategoryId= product.CategoryId;
            existProduct.DiscountPrice = product.DiscountPrice;
            existProduct.CostPrice= product.CostPrice;
            existProduct.SalePrice = product.SalePrice;

            _jhuanContext.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            Product product = _jhuanContext.Products.FirstOrDefault(x => x.Id == id);
            if (product == null) return View("Error");

            _jhuanContext.Products.Remove(product);
            _jhuanContext.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
