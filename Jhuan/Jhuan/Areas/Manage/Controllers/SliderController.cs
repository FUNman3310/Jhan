using Jhuan.Helper;
using Jhuan.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jhuan.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SliderController : Controller
    {
        private readonly JhuanContext _jhuanContext;
        private readonly IWebHostEnvironment _env;

        public SliderController(JhuanContext jhuanContext, IWebHostEnvironment env)
        {
            _jhuanContext = jhuanContext;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_jhuanContext.sliders.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            string name = slider.ImageFile.FileName;

            //string path = "C:\\Users\\ca.r214.16\\Desktop\\Jhuan\\Jhuan\\Jhuan\\wwwroot\\Uploads\\Slider\\" + name;

            //using (FileStream stream = new FileStream(path,FileMode.Create))
            //{
            //    slider.ImageFile.CopyTo(stream);
            //}

            slider.Image = FileManager.SaveFile(_env.WebRootPath, "uploads/slider", slider.ImageFile);

            _jhuanContext.sliders.Add(slider);
            _jhuanContext.SaveChanges();


            return RedirectToAction("index");

        }
        public IActionResult Update(int id)
        {
            Slider slider = _jhuanContext.sliders.Find(id);

            if (slider == null) return View("Error");
            

            return View();
        }
        [HttpPost]
        public IActionResult Update(int id, Slider slider)
        {
            if (slider == null) return View("Error");
           
            Slider existSlider = _jhuanContext.sliders.FirstOrDefault(slider => slider.Id == id);

            if (slider.ImageFile != null)
            {
                string name = FileManager.SaveFile(_env.WebRootPath, "uploads/slider", slider.ImageFile);

                existSlider.Image = name;
            }

            existSlider.Image = slider.Image;
            existSlider.Title= slider.Title;
            existSlider.SubTitle= slider.SubTitle;
            existSlider.RedirectUrl=slider.RedirectUrl;
            existSlider.RedirectUrlText=slider.RedirectUrlText;
            existSlider.Description=slider.Description;

            _jhuanContext.SaveChanges();




            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {

            Slider slider = _jhuanContext.sliders.FirstOrDefault(x=>x.Id==id);
            if (slider == null) return View("Error");

            _jhuanContext.sliders.Remove(slider);
            _jhuanContext.SaveChanges();



            return Ok();
        }
        

    }
}
