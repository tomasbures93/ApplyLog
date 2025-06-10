using ApplyLog.CVModels;
using ApplyLog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ApplyLog.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppDbContext _appDbContext;

        public ProfileController(UserManager<IdentityUser> userManager, AppDbContext appDbContext)
        {
            _userManager = userManager;
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            IdentityUser user = _userManager.GetUserAsync(User).Result;
            if(user == null)
            {
                return View("Error");
            }
            ViewBag.User = user.UserName;
            return View();
        }

        // Account  ( Password etc)
        public IActionResult ManageProfile()
        {
            return View();
        }


        // curriculum vitae 
        public IActionResult ManageCV()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Personal()
        {
            IdentityUser user = _userManager.GetUserAsync(User).Result;
            PersonalInfo personalInfo = _appDbContext.Personal.FirstOrDefault(u => u.User == user);
            return View(personalInfo);
        }

        [HttpPost]
        public IActionResult Personal(PersonalInfo info)
        {
            IdentityUser user = _userManager.GetUserAsync(User).Result;
            if (info == null)
            {
                ViewBag.Status = "Something went wrong!";
                return View("Personal");
            }
            info.User = user;
            ViewBag.Status = "Succesfully Saved";
            _appDbContext.Personal.Update(info);
            _appDbContext.SaveChanges();
            return View("Personal");
        }

        public IActionResult EducationIndex()
        {
            IdentityUser user = _userManager.GetUserAsync(User).Result;
            List<EducationEntry> education = _appDbContext.Educations.Where(u => u.User == user).ToList();
            if (TempData["Status"] != null)
            {
                ViewBag.Status = TempData["Status"];
            }
            return View(education);
        }

        [HttpGet]
        public IActionResult AddSchool()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSchool(EducationEntry school)
        {
            IdentityUser user = _userManager.GetUserAsync(User).Result;
            if (school == null)
            {
                TempData["Status"] = "Something went wrong";
                return RedirectToAction("EducationIndex");
            }
            school.User = user;
            TempData["Status"] = "Succesfully Saved";
            _appDbContext.Educations.Add(school);
            _appDbContext.SaveChanges();
            return RedirectToAction("EducationIndex");
        }

        public IActionResult DeleteSchool(int id)
        {
            IdentityUser user = _userManager.GetUserAsync(User).Result;
            EducationEntry school = _appDbContext.Educations.Where(u => u.Id == id && u.User == user).FirstOrDefault();
            if (school == null)
            {
                TempData["Status"] = "Something went wrong";
                return RedirectToAction("EducationIndex");
            }
            TempData["Status"] = "Succesfully Deleted";
            _appDbContext.Educations.Remove(school);
            _appDbContext.SaveChanges();
            return RedirectToAction("EducationIndex");
        }

        [HttpGet]
        public IActionResult EditSchool(int id)
        {
            IdentityUser user = _userManager.GetUserAsync(User).Result;
            EducationEntry school = _appDbContext.Educations.Where(u => u.Id == id && u.User == user).FirstOrDefault();
            if(school == null)
            {
                return Content("Something went wrong");
            }
            return View(school);
        }

        [HttpPost]
        public IActionResult EditSchool(EducationEntry school)
        {
            IdentityUser user = _userManager.GetUserAsync(User).Result;
            if (school == null)
            {
                TempData["Status"] = "Something went wrong";
                return RedirectToAction("EducationIndex");
            }
            school.User = user;
            _appDbContext.Educations.Update(school);
            _appDbContext.SaveChanges();
            TempData["Status"] = "Succesfully Saved";
            return RedirectToAction("EducationIndex");
        }

        public IActionResult WorkIndex()
        {
            IdentityUser user = _userManager.GetUserAsync(User).Result;
            List<WorkEntry> jobs = _appDbContext.Works.Where(u => u.User == user).ToList();
            if (TempData["Status"] != null)
            {
                ViewBag.Status = TempData["Status"];
            }
            return View(jobs);
        }

        [HttpGet]
        public IActionResult AddWork()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddWork(WorkEntry work)
        {
            IdentityUser user = _userManager.GetUserAsync(User).Result;
            if (work == null)
            {
                TempData["Status"] = "Something went wrong";
                return RedirectToAction("WorkIndex");
            }
            work.User = user;
            TempData["Status"] = "Succesfully Saved";
            _appDbContext.Works.Add(work);
            _appDbContext.SaveChanges();
            return RedirectToAction("WorkIndex");
        }

        public IActionResult DeleteWork(int id)
        {
            IdentityUser user = _userManager.GetUserAsync(User).Result;
            WorkEntry job = _appDbContext.Works.Where(u => u.Id == id &&  u.User == user).FirstOrDefault();
            if(job == null)
            {
                TempData["Status"] = "Something went wrong";
                return RedirectToAction("WorkIndex");
            }
            TempData["Status"] = "Job Description successfully deleted";
            _appDbContext.Works.Remove(job);
            _appDbContext.SaveChanges();
            return RedirectToAction("WorkIndex");
        }

        [HttpGet]
        public IActionResult EditWork(int id)
        {
            IdentityUser user = _userManager.GetUserAsync(User).Result;
            WorkEntry job = _appDbContext.Works.Where(u => u.User == user &&  u.Id == id).FirstOrDefault();
            if(job == null)
            {
                TempData["Status"] = "Something went wrong";
                return RedirectToAction("WorkIndex");
            }
            return View(job);
        }

        [HttpPost]
        public IActionResult EditWork(WorkEntry work)
        {
            IdentityUser user = _userManager.GetUserAsync(User).Result;
            if (work == null)
            {
                TempData["Status"] = "Something went wrong";
                return RedirectToAction("WorkIndex");
            }
            TempData["Status"] = "Job Description successfully updated";
            work.User = user;
            _appDbContext.Works.Update(work);
            _appDbContext.SaveChanges();
            return RedirectToAction("WorkIndex");
        }

        public IActionResult LanguageIndex()
        {
            IdentityUser user = _userManager.GetUserAsync(User).Result;
            List<LanguageEntry> languages = _appDbContext.Languages.Where(u => u.User == user).ToList();
            if (TempData["Status"] != null)
            {
                ViewBag.Status = TempData["Status"];
            }
            return View(languages);
        }
        [HttpGet]
        public IActionResult AddLanguage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddLanguage(LanguageEntry language)
        {
            IdentityUser user = _userManager.GetUserAsync(User).Result;
            if(language == null)
            {
                TempData["Status"] = "Something went wrong";
                return RedirectToAction("LanguageIndex");
            }
            language.User = user;
            TempData["Status"] = "Succesfully Saved";
            _appDbContext.Languages.Add(language);
            _appDbContext.SaveChanges();
            return RedirectToAction("LanguageIndex");
        }

        public IActionResult DeleteLanguage(int id)
        {
            IdentityUser user = _userManager.GetUserAsync(User).Result;
            LanguageEntry language = _appDbContext.Languages.Where(u => u.User == user && u.Id == id).FirstOrDefault();
            if(language == null)
            {
                TempData["Status"] = "Something went wrong";
                return RedirectToAction("LanguageIndex");
            }
            TempData["Status"] = "Succefully deleted";
            _appDbContext.Languages.Remove(language);
            _appDbContext.SaveChanges();
            return RedirectToAction("LanguageIndex");
        }

        [HttpGet]
        public IActionResult EditLanguage(int id)
        {
            IdentityUser user = _userManager.GetUserAsync(User).Result;
            LanguageEntry language = _appDbContext.Languages.Where(u => u.User == user && u.Id == id).FirstOrDefault();
            if(language == null)
            {
                TempData["Status"] = "Something went wrong";
                return RedirectToAction("LanguageIndex");
            }
            return View(language);
        }

        [HttpPost]
        public IActionResult EditLanguage(LanguageEntry language)
        {
            IdentityUser user = _userManager.GetUserAsync(User).Result;
            if(language == null)
            {
                TempData["Status"] = "Something went wrong";
                return RedirectToAction("LanguageIndex");
            }
            language.User = user;
            _appDbContext.Languages.Update(language);
            _appDbContext.SaveChanges();
            TempData["Status"] = "Succefully saved";
            return RedirectToAction("LanguageIndex");
        }
    }
}
