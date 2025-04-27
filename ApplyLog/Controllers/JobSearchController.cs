using ApplyLog.ApiModels;
using ApplyLog.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApplyLog.Controllers
{
    public class JobSearchController : Controller
    {

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
                return View(jobs.Result.Item1);
            }
        }

    }
}
