using ApplyLog.AIModels;
using ApplyLog.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApplyLog.Controllers
{
    public class AIController : Controller
    {
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
                case "email":
                    return PartialView("_email");
                case "cv":
                    return PartialView("_cv");
                case "":
                    return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public async Task<PartialViewResult> GenerateLetter(AIFormViewModel model)
        {
            AICommunication ask = new AICommunication();
            AIAnswer answer = ask.AskAI(model).Result;
            return PartialView("_letteranswer",answer);
        }
    }
}
