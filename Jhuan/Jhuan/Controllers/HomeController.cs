using Jhuan.Models;
using Microsoft.AspNetCore.Mvc;
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
            return View(_jhuanContext.sliders.ToList());
        }

        
    }
}