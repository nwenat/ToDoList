using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ToDoList.Data.ToDoListContext _context;
        private SQLToDoRepository sQLToDoRepository;

        public IList<ToDo> PriorityList { get; set; } = default!;
        public IList<Project> ProjectsList { get; set; } = default!;
        public IList<Category> CategoriesList { get; set; } = default!;

        public bool wantProjects = false;
        public bool wantCategories = false;
        public ToDo details = null;

        public bool hasData = false;
        public string taskName = "";



        public IndexModel(ToDoList.Data.ToDoListContext context)
        {
            _context = context;
            sQLToDoRepository = new SQLToDoRepository(_context);
        }




        public void OnGet(int? nav, int? id)
        {
            if (_context.ToDo != null)
            {
                PriorityList = (IList<ToDo>)sQLToDoRepository.GetPriority();
            }

            if (_context.Project != null)
            {
                ProjectsList = (IList<Project>)sQLToDoRepository.GetAllProjects();
            }

            if (_context.Category != null)
            {
                CategoriesList = (IList<Category>)sQLToDoRepository.GetAllCategories();
            }

            if (id != null)
            {
                details = PriorityList.Where(t => t.Id == id).First();
            }

            if(nav != null)
            {
                if(nav==1)
                { 
                    wantProjects = true;
                    wantCategories = false;
                }else
                {
                    wantProjects = false;
                    wantCategories = true;
                }
            }
        }

        public IActionResult OnPostUpdate()
        {
            if (Request.Form["id"] != "")
            {
                sQLToDoRepository.UpdateTask(Int32.Parse(Request.Form["id"]), Request.Form["upd"]);
            }

            return RedirectToPage("/Index");
        }

        public IActionResult OnPostAdd()
        {
            if (Request.Form["taskname"] != "")
            {
                var newToDo = new ToDo
                {
                    TaskName = Request.Form["taskname"],
                    IsUrgent = true
                };
                sQLToDoRepository.AddNewTask(newToDo);
            }

            return RedirectToPage("/Index");
        }
    }
}
