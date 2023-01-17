using Jhuan.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jhuan.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DashboardController : Controller
    {
        private readonly JhuanContext _jhuanContext;

        public DashboardController(JhuanContext jhuanContext)
        {
            _jhuanContext = jhuanContext;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
