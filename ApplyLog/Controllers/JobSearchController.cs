using ApplyLog.ApiModels;
using ApplyLog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ApplyLog.Controllers
{
    public class JobSearchController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppDbContext _appDbContext;
        public JobSearchController(UserManager<IdentityUser> userManager, AppDbContext appDbContext) 
        {
            _userManager = userManager;
            _appDbContext = appDbContext; 
        }

        public IActionResult Index(string jobTitel, string Ort, int radius = 10, int page = 1)
        {
            bool fehler = false;
            if(Request.Method == "POST")
            {
                if (string.IsNullOrEmpty(jobTitel))
                {
                    fehler = true;
                    ViewBag.Problem = "Please enter Job Titel! ";
                }
                if (string.IsNullOrEmpty(Ort))
                {
                    fehler = true;
                    ViewBag.Problem = ViewBag.Problem + "Please enter City !";
                }
                if (radius == null)
                {
                    fehler = true;
                    ViewBag.Problem = ViewBag.Problem + "Please enter Radius !";
                }
            }

            if (fehler == true)
            {
                List<Stellenangebote> list = new List<Stellenangebote>();
                return View(list);
            }
            else
            {
                ArbeitAgenturAPI arbeitAgentur = new ArbeitAgenturAPI();
                var jobs = arbeitAgentur.Jobs(jobTitel, Ort, radius, page);
                Task.WaitAll(jobs);
                ViewBag.MaxPages = jobs.Result.Item2;
                ViewBag.jobTitel = jobTitel;
                ViewBag.Ort = Ort;
                ViewBag.Radius = radius;
                ViewBag.CurrentPage = page;
                IdentityUser user = _userManager.GetUserAsync(User).Result;
                if (user != null)
                {
                    List<string> list = new List<string>();
                    list = _appDbContext.Favorites.Where(u => u.User == user).Select(d => d.Refnr).ToList();
                    ViewBag.Favorites = list;
                }
                return View(jobs.Result.Item1);
            }
        }

        [Authorize]
        public IActionResult FavoriteSave(string Refnr, string Beruf, string Titel, string Firma)
        {
            IdentityUser user = _userManager.GetUserAsync(User).Result;
            if(user == null)
            {
                return BadRequest("Something went wrong");
            }
            if (string.IsNullOrEmpty(Refnr))
            {
                return BadRequest("Something went wrong");
            }

            Favorite? exists = _appDbContext.Favorites.Where(u => u.User == user && u.Refnr == Refnr).FirstOrDefault();

            if(exists == null)
            {
                Favorite favorite = new Favorite();
                favorite.Refnr = Refnr;
                favorite.Beruf = Beruf;
                favorite.Firma = Firma;
                favorite.Titel = Titel;
                favorite.User = user;
                if (favorite != null)
                {
                    _appDbContext.Favorites.Add(favorite);
                }
            } else
            {
                _appDbContext.Favorites.Remove(exists);
            }
            _appDbContext.SaveChanges();
            return NoContent();
        }

        [Authorize]
        public IActionResult Favorites()
        {
            IdentityUser user = _userManager?.GetUserAsync(User).Result;
            List<Favorite> favorites = _appDbContext.Favorites.Where(u => u.User == user).ToList();
            return View(favorites);
        }

        [Authorize]
        public IActionResult Delete(string Refnr)
        {
            IdentityUser user = _userManager.GetUserAsync(User).Result;
            Favorite favorite = _appDbContext.Favorites.Where(u => u.User == user && u.Refnr == Refnr).FirstOrDefault();
            if (favorite != null)
            {
                _appDbContext.Remove(favorite);
                _appDbContext.SaveChanges();
            }
            return RedirectToAction("Favorites");
        }
    }
}
