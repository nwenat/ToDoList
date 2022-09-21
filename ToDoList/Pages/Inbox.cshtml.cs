using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Pages
{
    public class InboxModel : PageModel
    {
        private readonly ToDoList.Data.ToDoListContext _context;
        private SQLToDoRepository sQLToDoRepository;

        public IList<ToDo> InboxList { get; set; } = default!;
        public IList<Project> ProjectsList { get; set; } = default!;
        public IList<Category> CategoriesList { get; set; } = default!;

        public bool wantProjects = false;
        public bool wantCategories = false;
        public bool showDetails = false;
        public int DetailsId = 0;

        public InboxModel(ToDoList.Data.ToDoListContext context)
        {
            _context = context;
            sQLToDoRepository = new SQLToDoRepository(_context);
        }
        public void OnGet(int? nav, int? id)
        {
            if (_context.ToDo != null)
            {
                InboxList = (IList<ToDo>)sQLToDoRepository.GetInbox();
            }
            if (_context.Project != null)
            {
                ProjectsList = (IList<Project>)sQLToDoRepository.GetAllProjects();
            }

            if (_context.Category != null)
            {
                CategoriesList = (IList<Category>)sQLToDoRepository.GetAllCategories();
            }

            if ((id != null) && (InboxList.Select(p => p.Id).ToList().Contains((int)id)))
            {
                showDetails = true;
                DetailsId = (int)id;
            }

            if (nav != null)
            {
                if ((int)nav == 1)
                {
                    wantProjects = true;
                    wantCategories = false;
                }
                else
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
            return RedirectToPage("/Inbox");
        }

        public IActionResult OnPostUpdateDetails()
        {
            if (Request.Form["id"] != "")
            {
                sQLToDoRepository.UpdateTask(Int32.Parse(Request.Form["id"]), Request.Form["upd"]);
            }
            return RedirectToPage("/Inbox", new { id = Request.Form["id"] });
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
            return RedirectToPage("/Inbox");
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
            return RedirectToPage("/Inbox");
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
            return RedirectToPage("/Inbox");
        }

        public IActionResult OnPostChangeTaskName()
        {
            if (Request.Form["nwetname"] != "")
            {
                sQLToDoRepository.UpdateTaskName(Int32.Parse(Request.Form["id"]), Request.Form["nwetname"]);
            }
            return RedirectToPage("/Inbox", new { id = Request.Form["id"] });
        }


        public IActionResult OnPostDeleteTask()
        {
            if (Request.Form["id"] != "")
            {
                sQLToDoRepository.DeleteTask(Int32.Parse(Request.Form["id"]));
            }
            return RedirectToPage("/Inbox");
        }
    }
}
