using System.Diagnostics;
using ApplyLog.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApplyLog.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext appDbContext = new AppDbContext();

        public IActionResult Index()
        {
            List<TODO> todoList = appDbContext.Todos.ToList();
            List<Bewerbung> applicationsList = appDbContext.Applications.ToList();
            var obj = new 
            {
                todo = todoList,
                application = applicationsList,
            };
            return View(obj);
        }

        public IActionResult Privacy()
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
