using ApplyLog.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApplyLog.Controllers
{
    public class ApplicationController : Controller
    {
        private AppDbContext appDbContext = new AppDbContext();
        public IActionResult Index()
        {
            return View(appDbContext.Applications.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Save(Bewerbung bewerbung, Firma firma, Kontakt kontakt)
        {
            if(bewerbung != null)
            {
                firma.Kontakt = kontakt;
                bewerbung.firma = firma;
                appDbContext.Applications.Add(bewerbung);
                appDbContext.SaveChanges();
            }
            return View(bewerbung);
        }
    }
}
