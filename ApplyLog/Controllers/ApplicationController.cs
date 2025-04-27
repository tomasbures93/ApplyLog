using ApplyLog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplyLog.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly AppDbContext appDbContext;

        public ApplicationController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            int count = await appDbContext.Applications.CountAsync();
            int maxItemsPerPage = 10;
            int pages = (int)Math.Ceiling((double)count / maxItemsPerPage);

            if(page == null || page < 1)
            {
                page = 1;
            }

            List<Bewerbung> applications = appDbContext.Applications
                .Skip((page - 1) * maxItemsPerPage)
                .Take(maxItemsPerPage)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.MaxPages = pages;

            return View(applications);
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult View(int id)
        {
            return View(appDbContext.Applications.FirstOrDefault(i => i.id == id));
        }
        public IActionResult Save(Bewerbung bewerbung)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", bewerbung);
            }
            if(bewerbung != null)
            {
                appDbContext.Applications.Add(bewerbung);
                appDbContext.SaveChanges();
            }
            return View(bewerbung);
        }
        public IActionResult Edit(int id)
        {
            return View(appDbContext.Applications.FirstOrDefault(i => i.id == id));
        }
        public IActionResult EditSave(Bewerbung bewerbung, int companyID, int kontaktID)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", bewerbung);
            }
            var applicationToEdit = appDbContext.Applications.Where(i => i.id == bewerbung.id).FirstOrDefault();
            if(applicationToEdit != null)
            {
                applicationToEdit.position = bewerbung.position;
                applicationToEdit.jobort = bewerbung.jobort;
                applicationToEdit.gehalt = bewerbung.gehalt;
                applicationToEdit.positionComment = bewerbung.positionComment;
                applicationToEdit.homeoffice = bewerbung.homeoffice;
                applicationToEdit.applicationlink = bewerbung.applicationlink;
                applicationToEdit.result = bewerbung.result;
                applicationToEdit.firma.CompanyName = bewerbung.firma.CompanyName;
                applicationToEdit.firma.Ort = bewerbung.firma.Ort;
                applicationToEdit.firma.Kontakt.number = bewerbung.firma.Kontakt.number;
                applicationToEdit.firma.Kontakt.email = bewerbung.firma.Kontakt.email;
                applicationToEdit.firma.Kontakt.website = bewerbung.firma.Kontakt.website;
                appDbContext.SaveChanges();
            }
            return View(applicationToEdit);
        }

        public IActionResult Delete(int id)
        {
            var bewerbung = appDbContext.Applications.FirstOrDefault(i => i.id == id);
            var viewData = appDbContext.Applications.Include(f => f.firma).Include(k => k.firma.Kontakt).FirstOrDefault(i => i.id == id);
            appDbContext.Applications.Remove(bewerbung);
            appDbContext.SaveChanges();
            return View(viewData);
        }

        public PartialViewResult Search(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                List<Bewerbung> empty = new List<Bewerbung>();
                return PartialView("_searchView", empty);
            }
            List<Bewerbung> applications = appDbContext.Applications
                .Where(t => t.firma.CompanyName.ToLower().Contains(search.ToLower()))
                .ToList();
            return PartialView("_searchView", applications);
        }
    }
}
