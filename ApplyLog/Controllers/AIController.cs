using System.Text;
using ApplyLog.AIModels;
using ApplyLog.CVModels;
using ApplyLog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xceed.Words.NET;

namespace ApplyLog.Controllers
{
    [Authorize]
    public class AIController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppDbContext _appDbContext;

        public AIController(UserManager<IdentityUser> userManager, AppDbContext appDbContext)
        {
            _userManager = userManager;
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoadAI(string ai)
        {
            switch (ai)
            {
                case "letter":
                    return PartialView("_letter");
                case "cv":
                    IdentityUser user = _userManager.GetUserAsync(User).Result;
                    PersonalInfo info = _appDbContext.Personal.FirstOrDefault(u => u.User == user);
                    int school = _appDbContext.Educations.Where(u => u.User == user).Count();
                    int language = _appDbContext.Languages.Where(u => u.User == user).Count();
                    int jobs = _appDbContext.Works.Where(u => u.User == user).Count();
                    ViewBag.Missing = "";
                    if(info == null)
                    {
                        ViewBag.Missing += "You don't have Personal info! \n";
                    }
                    if(school == 0)
                    {
                        ViewBag.Missing += "You don't have any Education info! \n";
                    }
                    if(jobs == 0)
                    {
                        ViewBag.Missing += "You don't have any Work Experience info! \n";
                    }
                    if(language == 0)
                    {
                        ViewBag.Missing += "You don't have any Language info! ";
                    }
                    return PartialView("_cv");
                case "":
                    return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public async Task<PartialViewResult> GenerateLetter(AILetterViewModel model)
        {
            AICommunication ask = new AICommunication();
            var response = ask.GenerateAILetter(model).Result;
            AIAnswer answer = response.Item1;
            ViewBag.Raw = response.Item2;
            return PartialView("_letteranswer",answer);
        }

        public async Task<PartialViewResult> GenerateCV()
        {
            IdentityUser user = _userManager.GetUserAsync(User).Result;
            AICommunication ask = new AICommunication();
            PersonalInfo personal = _appDbContext.Personal.FirstOrDefault(u => u.User == user);
            List<WorkEntry> jobs = _appDbContext.Works.Where(u => u.User == user).ToList();
            List<EducationEntry> schools = _appDbContext.Educations.Where(u => u.User == user).ToList();
            List<LanguageEntry> languages = _appDbContext.Languages.Where(u => u.User == user).ToList();
            if(personal == null || jobs == null || schools == null || languages == null)
            {
                return PartialView("_error");
            }
            var response = ask.GenerateCV(personal, jobs, schools, languages).Result;
            AIAnswer answer = response.Item1;
            ViewBag.Raw = response.Item2;
            return PartialView("_cvanswer", answer);
        }

        public FileResult DownloadLetter(string letter)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (var doc = DocX.Create(stream))
                {
                    doc.InsertParagraph(letter);
                    doc.Save();
                }
                stream.Position = 0;
                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "CoverLetter.docx");
            }
        }

        public FileResult DownloadCV(string cv)
        {
            using(MemoryStream stream = new MemoryStream())
            {
                using(var doc = DocX.Create(stream))
                {
                    doc.InsertParagraph(cv);
                    doc.Save();
                }
                stream.Position = 0;
                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "CV.docx");
            }
        }
    }
}
