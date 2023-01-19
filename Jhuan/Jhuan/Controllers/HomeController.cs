using Jhuan.Models;
using Jhuan.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Jhuan.Controllers
{
    public class HomeController : Controller
    {
        private readonly JhuanContext _jhuanContext;

        public HomeController(JhuanContext jhuanContext)
        {
            _jhuanContext = jhuanContext;
        }
       
        public IActionResult Index()
        {
            HomeViewModel homeVM = new HomeViewModel
            {
                sliders = _jhuanContext.sliders.ToList(),
                products = _jhuanContext.Products.Include(x=>x.color).Include(x => x.category).Include(x => x.size).ToList(),
            };


            return View(homeVM);
        }

        
    }
}