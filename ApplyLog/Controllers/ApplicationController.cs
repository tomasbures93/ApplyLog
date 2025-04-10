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
        public IActionResult Edit(int id)
        {
            return View(appDbContext.Applications.FirstOrDefault(i => i.id == id));
        }
        public IActionResult EditSave(Bewerbung bewerbung, Firma firma, Kontakt kontakt, int companyID, int kontaktID)
        {
            var applicationToEdit = appDbContext.Applications.Where(i => i.id == bewerbung.id).FirstOrDefault();
            if(applicationToEdit != null)
            {
                applicationToEdit.jobort = bewerbung.jobort;
                applicationToEdit.position = bewerbung.position;
                applicationToEdit.result = bewerbung.result;
                applicationToEdit.gehalt = bewerbung.gehalt;
                applicationToEdit.homeoffice = bewerbung.homeoffice;
                applicationToEdit.applicationlink = bewerbung.applicationlink;
                // WORKS but if I am editing company I have to check if company with the same name already exist ... need to do taht somehow
                firma.Kontakt = kontakt;
                firma.Kontakt.id = companyID;
                applicationToEdit.firma = firma;
                applicationToEdit.firma.ID = companyID;
                appDbContext.SaveChanges();
            }
            return View(applicationToEdit);
        }
    }
}
