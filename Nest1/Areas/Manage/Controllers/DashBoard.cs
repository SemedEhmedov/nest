using Microsoft.AspNetCore.Mvc;

namespace Nest1.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DashBoard : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
