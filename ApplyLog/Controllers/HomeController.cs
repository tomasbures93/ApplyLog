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

        public PartialViewResult Search(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                //Tuple<List<TODO>, List<Bewerbung>> data = new Tuple<List<TODO>, List<Bewerbung>>(null, null);
                return PartialView("_formSearch", null);
            }
            List<TODO> todoList = appDbContext.Todos.Where(s => s.Titel.ToLower().Contains(search.ToLower())).ToList();
            List<Bewerbung> applicationsList = appDbContext.Applications.Where(c => c.firma.CompanyName.ToLower().Contains(search.ToLower())).ToList();
            var data = new Tuple<List<TODO>, List<Bewerbung>>(todoList, applicationsList);
            return PartialView("_formSearch", data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
