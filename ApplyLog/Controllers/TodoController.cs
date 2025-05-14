using ApplyLog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplyLog.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        private AppDbContext appDbContext;
        private readonly UserManager<IdentityUser> userManager;

        public TodoController(AppDbContext appDbContext, UserManager<IdentityUser> userManager)
        {
            this.appDbContext = appDbContext;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;

            int count = await appDbContext.Todos.Where(i => i.User == user).CountAsync();
            int maxItemsPerPage = 10;
            int pages = (int)Math.Ceiling((double)count / maxItemsPerPage);

            if(page == null || page < 1)
            {
                page = 1;
            }

            List<TODO> todos = appDbContext.Todos
                .Skip((page - 1) * maxItemsPerPage)
                .Where(i => i.User == user)
                .Take(maxItemsPerPage)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.MaxPages = pages;

            return View(todos);
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult View(int id)
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            TODO todo = appDbContext.Todos.Where(i => i.User == user).FirstOrDefault(i => i.ID == id);
            if(todo == null)
            {
                return NotFound("Something went wrong!");
            }
            return View(todo);
        }

        [HttpPost]
        public IActionResult Save(TODO todo)
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            todo.User = user;
            if (!ModelState.IsValid)
            {
                return View("Create", todo);
            }
            if (todo != null)
            {
                appDbContext.Todos.Add(todo);
                appDbContext.SaveChanges();
            }
            return View(todo);
        }
        public IActionResult Edit(int id)
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            TODO todo = appDbContext.Todos.Where(i => i.User == user).FirstOrDefault(i => i.ID == id);
            if(todo == null)
            {
                return NotFound("Something went wrong!");
            }
            return View(todo);
        }
        public IActionResult EditSave(TODO todo)
        {
            if(todo.Titel == null && todo.User == null)
            {
                return NotFound("Something went wrong");
            }
            if (!ModelState.IsValid)
            {
                return View("Edit", todo);
            }
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            var todoToAdd = appDbContext.Todos.Where(t => t.ID == todo.ID && t.User == user).FirstOrDefault();
            if (todoToAdd != null)
            {
                todoToAdd.Titel = todo.Titel;
                todoToAdd.Describtion = todo.Describtion;
                todoToAdd.Deadline = todo.Deadline;
                todoToAdd.PriorityLevel = todo.PriorityLevel;
                appDbContext.SaveChanges();
            }
            return View(appDbContext.Todos.Where(t => t.ID == todo.ID && t.User == user).FirstOrDefault());
        }
        public IActionResult Delete(int id)
        {
            if(id == 0)
            {
                return NotFound("Something went wrong");
            }
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            var todo = appDbContext.Todos.Where(i => i.User == user).FirstOrDefault(i => i.ID == id);
            if(todo != null)
            {
                appDbContext.Todos.Remove(todo);
                appDbContext.SaveChanges();
                return View(todo);
            } else
            {
                return NotFound("Something went wrong");
            }
        }

        public PartialViewResult Search(string search)
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            if (string.IsNullOrEmpty(search))
            {
                List<TODO> empty = new List<TODO>();
                return PartialView("_searchView",empty);
            }
            List<TODO> result = appDbContext.Todos
                .Where(t => t.Titel.ToLower().Contains(search.ToLower()) && t.User == user)
                .ToList();

            return PartialView("_searchView", result);
        }
    }
}
