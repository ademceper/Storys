using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Story.Data;

namespace Story.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Administrators")]
    public class DashboardController : Controller
    {
        private readonly AppDbContext context;

        public DashboardController(AppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            ViewBag.user= context.Users.Count();
            
            return View();
        }
    }
}
