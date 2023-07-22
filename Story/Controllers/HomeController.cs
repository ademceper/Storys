using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Story.Data;
using Story.Models;
using System.Diagnostics;

namespace Story.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext context;

        public HomeController(ILogger<HomeController> logger,AppDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            ViewBag.MostViews = context.Tales.OrderByDescending(p => p.Date).ToList();
            return View();
        }
        public async Task<IActionResult> Tale(Guid id)
        {
            var product = await context.Tales.SingleOrDefaultAsync(p => p.Id == id);


            return View(product);

        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Cause()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}