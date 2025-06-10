using ApplyLog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplyLog.Controllers
{
    [Authorize]     // still need to fully test it
    public class ApplicationController : Controller
    {
        private readonly AppDbContext appDbContext;
        private readonly UserManager<IdentityUser> userManager;

        public ApplicationController(AppDbContext appDbContext, UserManager<IdentityUser> userManager)
        {
            this.appDbContext = appDbContext;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            IdentityUser user = userManager.GetUserAsync(HttpContext.User).Result;
            int count = await appDbContext.Applications.Where(i => i.User == user).CountAsync();
            int maxItemsPerPage = 10;
            int pages = (int)Math.Ceiling((double)count / maxItemsPerPage);

            if(page == null || page < 1)
            {
                page = 1;
            }

            List<Bewerbung> applications = appDbContext.Applications
                .Where(i => i.User == user)
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
            IdentityUser user = userManager.GetUserAsync(HttpContext.User).Result;
            Bewerbung application = appDbContext.Applications.Where(i => i.User == user).FirstOrDefault(i => i.Id == id);
            if(application == null)
            {
                return NotFound("Something went wrong!");
            }
            return View(application);
        }
        public IActionResult Save(Bewerbung bewerbung)
        {
            IdentityUser user = userManager.GetUserAsync(HttpContext.User).Result;
            bewerbung.User = user;
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
            IdentityUser user = userManager.GetUserAsync(HttpContext.User).Result;
            Bewerbung application = appDbContext.Applications.FirstOrDefault(i => i.Id == id && i.User == user);
            if(application == null)
            {
                return NotFound("Something went wrong");
            }
            return View(application);
        }

        public IActionResult EditSave(Bewerbung bewerbung, int companyID, int kontaktID)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", bewerbung);
            }
            Bewerbung applicationToEdit = appDbContext.Applications.Where(i => i.Id == bewerbung.Id).FirstOrDefault();
            if(applicationToEdit != null)
            {
                applicationToEdit.Position = bewerbung.Position;
                applicationToEdit.JobOrt = bewerbung.JobOrt;
                applicationToEdit.Gehalt = bewerbung.Gehalt;
                applicationToEdit.PositionComment = bewerbung.PositionComment;
                applicationToEdit.HomeOffice = bewerbung.HomeOffice;
                applicationToEdit.ApplicationLink = bewerbung.ApplicationLink;
                applicationToEdit.Result = bewerbung.Result;
                applicationToEdit.InterviewDate = bewerbung.InterviewDate;
                applicationToEdit.JobType = bewerbung.JobType;
                applicationToEdit.LastUpdateAt= DateTime.Now;
                applicationToEdit.Firma.CompanyName = bewerbung.Firma.CompanyName;
                applicationToEdit.Firma.Ort = bewerbung.Firma.Ort;
                applicationToEdit.Firma.Kontakt.Number = bewerbung.Firma.Kontakt.Number;
                applicationToEdit.Firma.Kontakt.Email = bewerbung.Firma.Kontakt.Email;
                applicationToEdit.Firma.Kontakt.Website = bewerbung.Firma.Kontakt.Website;
                appDbContext.SaveChanges();
            }
            return View(applicationToEdit);
        }

        public IActionResult Delete(int id)
        {
            IdentityUser user = userManager.GetUserAsync(HttpContext.User).Result;
            Bewerbung bewerbung = appDbContext.Applications.FirstOrDefault(i => i.Id == id && i.User == user);
            Firma firma = bewerbung.Firma;
            Kontakt contact = bewerbung.Firma.Kontakt;
            if(bewerbung == null)
            {
                return NotFound("Something went Wrong");
            }
            Bewerbung viewData = appDbContext.Applications.Where(i => i.User == user).Include(f => f.Firma).Include(k => k.Firma.Kontakt).FirstOrDefault(i => i.Id == id);
            appDbContext.Applications.Remove(bewerbung);

            if (contact != null)
                appDbContext.Remove(contact);
            if (firma != null)
                appDbContext.Remove(firma);

            appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult Search(string search)
        {
            IdentityUser user = userManager.GetUserAsync(HttpContext.User).Result;
            if (string.IsNullOrEmpty(search))
            {
                List<Bewerbung> empty = new List<Bewerbung>();
                return PartialView("_searchView", empty);
            }
            List<Bewerbung> applications = appDbContext.Applications
                .Where(t => t.Firma.CompanyName.ToLower().Contains(search.ToLower()) && t.User == user)
                .ToList();
            return PartialView("_searchView", applications);
        }
    }
}
