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
            List<TODO> todoList = appDbContext.Todos.OrderBy(d => d.Deadline).Take(5).ToList();
            List<Bewerbung> applicationsList = appDbContext.Applications.OrderBy(d => d.whenapplied).Take(5).ToList();
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
                return PartialView("_formSearch", null);
            }
            List<TODO> todoList = appDbContext.Todos.Where(s => s.Titel.ToLower().Contains(search.ToLower())).ToList();
            List<Bewerbung> applicationsList = appDbContext.Applications.Where(c => c.firma.CompanyName.ToLower().Contains(search.ToLower())).ToList();
            var data = new Tuple<List<TODO>, List<Bewerbung>>(todoList, applicationsList);
            return PartialView("_formSearch", data);
        }

        public PartialViewResult TodoData()
        {
            var dataForChart = new[]
            {
                new { Label = "Low", Count =  appDbContext.Todos.Where(p => p.PriorityLevel == PriorityLevel.Low).Count() },
                new { Label = "Medium", Count = appDbContext.Todos.Where(p => p.PriorityLevel == PriorityLevel.Medium).Count() },
                new { Label = "High", Count = appDbContext.Todos.Where(p => p.PriorityLevel == PriorityLevel.High).Count() }
            };
            return PartialView("_chartTodo", dataForChart);
        }

        public PartialViewResult GeoChart()
        {
            List<string> cities = appDbContext.Applications.Select(c => c.jobort).Distinct().ToList();
            return PartialView("_geoChart", cities);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
