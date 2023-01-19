using Jhuan.Helper;
using Jhuan.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jhuan.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class BrandLogoController : Controller
    {
        private readonly JhuanContext _jhuanContext;
        private readonly IWebHostEnvironment _env;

        public BrandLogoController(JhuanContext jhuanContext,IWebHostEnvironment env)
        {
            _jhuanContext = jhuanContext;
            _env = env;
        }
        public IActionResult Index()
        {

            return View(_jhuanContext.BrandLogos.ToList());
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(BrandLogo brandLogo)
        {
            string name = brandLogo.ImageFile.FileName;

            

            brandLogo.Image = FileManager.SaveFile(_env.WebRootPath, "uploads/brandlogo", brandLogo.ImageFile);

            _jhuanContext.BrandLogos.Add(brandLogo);
            _jhuanContext.SaveChanges();


            return RedirectToAction("index");
           
        }
        public IActionResult Update(int id)
        {
            BrandLogo brand = _jhuanContext.BrandLogos.Find(id);

            if (brand == null) return View("Error");
            return View(brand);
        }
        [HttpPost]
        public IActionResult Update(int id,BrandLogo brandLogo)
        {
            if (brandLogo == null) return View("Error");

            BrandLogo existLogo = _jhuanContext.BrandLogos.FirstOrDefault(brandLogo => brandLogo.Id == id);

            if (brandLogo.ImageFile != null)
            {
                string name = FileManager.SaveFile(_env.WebRootPath, "uploads/brandlogo", brandLogo.ImageFile);
                existLogo.Image = name;
            }
            _jhuanContext.SaveChanges();

            return RedirectToAction("index");
        }
    
        public IActionResult Delete(int id)
        {
           BrandLogo brand = _jhuanContext.BrandLogos.FirstOrDefault(x => x.Id == id);
           if (brand == null) return View("Error");
           
           _jhuanContext.BrandLogos.Remove(brand);
           _jhuanContext.SaveChanges();
           
           
           
           return RedirectToAction("index");

        
        }
    }   
}
