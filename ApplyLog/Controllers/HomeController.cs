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
            var data = new Tuple<List<TODO>,  List<Bewerbung>>(todoList, applicationsList);
            return View(data);
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
