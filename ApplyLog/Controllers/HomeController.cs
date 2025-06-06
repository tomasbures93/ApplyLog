using System.Diagnostics;
using ApplyLog.GermanCityModels;
using ApplyLog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ApplyLog.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext appDbContext; 
        private readonly UserManager<IdentityUser> userManager;

        public HomeController(AppDbContext appDbContext, UserManager<IdentityUser> userManager)
        {
            this.appDbContext = appDbContext;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            IdentityUser user = userManager.GetUserAsync(User).Result;
            List<TODO> todoList = appDbContext.Todos.Where(u => u.User == user && u.Status == Status.Open)
                                                    .OrderBy(d => d.Deadline).Take(5).ToList();
            List<Bewerbung> applicationsList = appDbContext.Applications.Where(u => u.User == user)
                                                                        .OrderBy(d => d.WhenApplied).Take(5).ToList();
            var data = new Tuple<List<TODO>,  List<Bewerbung>>(todoList, applicationsList);
            ViewBag.Applications = appDbContext.Applications.Where(u => u.User == user).Count();
            ViewBag.TODOs = appDbContext.Todos.Where(u => u.User == user && u.Status == Status.Open).Count();
            return View(data);
        }

        public PartialViewResult Search(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return PartialView("_formSearch", null);
            }
            IdentityUser user = userManager.GetUserAsync(User).Result;
            List<TODO> todoList = appDbContext.Todos
                                .Where(s => s.Titel.ToLower().Contains(search.ToLower()) && s.User == user).ToList();
            List<Bewerbung> applicationsList = appDbContext.Applications
                                .Where(c => c.Firma.CompanyName.ToLower().Contains(search.ToLower()) && c.User == user).ToList();
            var data = new Tuple<List<TODO>, List<Bewerbung>>(todoList, applicationsList);
            return PartialView("_formSearch", data);
        }

        public PartialViewResult TodoData()
        {
            IdentityUser user = userManager.GetUserAsync(User).Result;
            var dataForChart = new[]
            {
                new { Label = "Low", Count =  appDbContext.Todos
                                              .Where(p => p.PriorityLevel == PriorityLevel.Low && p.User == user && p.Status == Status.Open).Count() },
                new { Label = "Medium", Count = appDbContext.Todos
                                                .Where(p => p.PriorityLevel == PriorityLevel.Medium && p.User == user && p.Status == Status.Open).Count() },
                new { Label = "High", Count = appDbContext.Todos
                                              .Where(p => p.PriorityLevel == PriorityLevel.High && p.User == user && p.Status == Status.Open).Count() }
            };
            return PartialView("_chartTodo", dataForChart);
        }

        public PartialViewResult GeoChart()
        {
            IdentityUser user = userManager.GetUserAsync(User).Result;
            List<string> cities = appDbContext.Applications.Where(u => u.User == user).Select(c => c.JobOrt).Distinct().ToList();
            GermanCityCoords coords = new GermanCityCoords();
            List<City> view = new List<City>();
            foreach(var c in cities)
            {
                City city = coords.GetCityGeo(c);
                if(city != null)
                {
                    view.Add(city);
                }
            }
            return PartialView("_geoChart", view);
        }

        //Something to do with that ?
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
