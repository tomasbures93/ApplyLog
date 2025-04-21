using ApplyLog.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApplyLog.Controllers
{
    public class TodoController : Controller
    {
        private AppDbContext appDbContext = new AppDbContext();
        public IActionResult Index()
        {
            return View(appDbContext.Todos.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult View(int id)
        {
            return View(appDbContext.Todos.FirstOrDefault(i => i.ID == id));
        }

        [HttpPost]
        public IActionResult Save(TODO todo)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", todo);
            }
            if (todo != null)
            {
                todo.CreationTime = DateTime.Now;
                appDbContext.Todos.Add(todo);
                appDbContext.SaveChanges();
            }
            return View(todo);
        }
        public IActionResult Edit(int id)
        {
            return View(appDbContext.Todos.FirstOrDefault(i => i.ID == id));
        }
        public IActionResult EditSave(TODO todo)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", todo);
            }
            var todoToAdd = appDbContext.Todos.Where(t => t.ID == todo.ID).FirstOrDefault();
            if (todoToAdd != null)
            {
                todoToAdd.Titel = todo.Titel;
                todoToAdd.Describtion = todo.Describtion;
                todoToAdd.Deadline = todo.Deadline;
                todoToAdd.PriorityLevel = todo.PriorityLevel;
                appDbContext.SaveChanges();
            }
            return View(appDbContext.Todos.Where(t => t.ID == todo.ID).FirstOrDefault());
        }
        public IActionResult Delete(int id)
        {
            var todo = appDbContext.Todos.FirstOrDefault(i => i.ID == id);
            appDbContext.Todos.Remove(todo);
            appDbContext.SaveChanges();
            return View(todo);
        }

        public PartialViewResult Search(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                List<TODO> empty = new List<TODO>();
                return PartialView("_searchView",empty);
            }
            List<TODO> result = appDbContext.Todos
                .Where(t => t.Titel.ToLower().Contains(search.ToLower()))
                .ToList();

            return PartialView("_searchView", result);
        }
    }
}
