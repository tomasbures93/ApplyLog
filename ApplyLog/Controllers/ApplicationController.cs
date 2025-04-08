using Microsoft.AspNetCore.Mvc;

namespace ApplyLog.Controllers
{
    public class ApplicationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
