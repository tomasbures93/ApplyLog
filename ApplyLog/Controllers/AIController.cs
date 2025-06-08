using System.Text;
using ApplyLog.AIModels;
using ApplyLog.Models;
using Microsoft.AspNetCore.Mvc;
using Xceed.Words.NET;

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

        public async Task<PartialViewResult> GenerateLetter(AILetterViewModel model)
        {
            AICommunication ask = new AICommunication();
            var response = ask.GenerateAILetter(model).Result;
            AIAnswer answer = response.Item1;
            ViewBag.Raw = response.Item2;
            return PartialView("_letteranswer",answer);
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
    }
}
