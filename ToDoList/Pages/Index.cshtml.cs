using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
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
        public bool showDetails = false;
        public int DetailsId = 0;

        //public int nextId = 0;
        //public int previousId = 0;

        //public bool hasData = false;
        //public string taskName = "";

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

            if ((id != null) && (PriorityList.Select(p => p.Id).ToList().Contains((int)id)))
            {
                showDetails = true;
                DetailsId = (int)id;
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

        public IActionResult OnPostUpdateDetails()
        {
            if (Request.Form["id"] != "")
            {
                sQLToDoRepository.UpdateTask(Int32.Parse(Request.Form["id"]), Request.Form["upd"]);
            }
            return RedirectToPage("/Index", new { id = Request.Form["id"] });
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

        public IActionResult OnPostAddProject()
        {
            if (Request.Form["pname"] != "")
            {
                var newProject = new Project
                {
                    ProjectName = Request.Form["pname"],
                    ProjectColour = "#e2e2e2;"

                };
                sQLToDoRepository.AddNewProject(newProject);
            }
            return RedirectToPage("/Index", new { nav = 1 });
        }

        public IActionResult OnPostAddCategory()
        {
            if (Request.Form["cname"] != "")
            {
                var newCategory = new Category
                {
                    CategoryName = Request.Form["cname"],
                    CategoryColour = "#e2e2e2;"
                };
                sQLToDoRepository.AddNewCategory(newCategory);
            }
            return RedirectToPage("/Index", new { nav = 2 });
        }

        public IActionResult OnPostChangeTaskName()
        {
            if (Request.Form["nwetname"] != "")
            {
                sQLToDoRepository.UpdateTaskName(Int32.Parse(Request.Form["id"]), Request.Form["nwetname"]);
            }
            return RedirectToPage("/Index", new {id = Request.Form["id"]});
        }

        
        public IActionResult OnPostDeleteTask()
        {
            if (Request.Form["id"] != "")
            {
                sQLToDoRepository.DeleteTask(Int32.Parse(Request.Form["id"]));
            }
            return RedirectToPage("/Index");
        }
    }
}
