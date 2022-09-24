using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Pages
{
    public class ProjectModel : PageModel
    {
        private readonly ToDoList.Data.ToDoListContext _context;
        private SQLToDoRepository sQLToDoRepository;

        public IList<ToDo> ProjectTaskList { get; set; } = default!;
        public IList<Project> ProjectsList { get; set; } = default!;
        public IList<Category> CategoriesList { get; set; } = default!;

        public bool wantProjects = true;
        public bool wantCategories = false;
        public bool showDetails = false;
        public bool showProjectInfo = false;
        public int DetailsId = 0;
        public int projectId = 0;

        public ProjectModel(ToDoList.Data.ToDoListContext context)
        {
            _context = context;
            sQLToDoRepository = new SQLToDoRepository(_context);
        }

        public void OnGet(int pId, int? nav, int? id, bool? info)
        {
            if (_context.ToDo != null)
            {
                ProjectTaskList = (IList<ToDo>)sQLToDoRepository.GetOneProject(pId);
            }
            if (_context.Project != null)
            {
                ProjectsList = (IList<Project>)sQLToDoRepository.GetAllProjects();
            }

            if (_context.Category != null)
            {
                CategoriesList = (IList<Category>)sQLToDoRepository.GetAllCategories();
            }

            projectId = pId;

            if ((info != null) && (bool)info)
            {
                showProjectInfo = true;
                //showDetails = false;
            }
            else if ((id != null) && (ProjectTaskList.Select(p => p.Id).ToList().Contains((int)id)))
            {
                showDetails = true;
                DetailsId = (int)id;
                //showProjectInfo = false;
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
            return RedirectToPage("/Project", new { pid = Request.Form["pid"] });
        }

        public IActionResult OnPostUpdateDetails()
        {
            if (Request.Form["id"] != "")
            {
                sQLToDoRepository.UpdateTask(Int32.Parse(Request.Form["id"]), Request.Form["upd"]);
            }
            return RedirectToPage("/Project", new { id = Request.Form["id"], pid = Request.Form["pid"] });
        }

        public IActionResult OnPostAdd()
        {
            if (Request.Form["taskname"] != "")
            {
                var newToDo = new ToDo
                {
                    TaskName = Request.Form["taskname"],
                    Project = sQLToDoRepository.GetProjectInfo(Int32.Parse(Request.Form["pid"])),
                    IsUrgent = false
                };
                sQLToDoRepository.AddNewTask(newToDo);
            }
            return RedirectToPage("/Project", new { pid = Request.Form["pid"] });
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
            return RedirectToPage("/Project", new { pid = Request.Form["pid"], nav = 1 });
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
            return RedirectToPage("/Project", new { pid = Request.Form["pid"], nav = 2 });
        }

        public IActionResult OnPostChangeTaskName()
        {
            if (Request.Form["newtname"] != "")
            {
                sQLToDoRepository.UpdateTaskName(Int32.Parse(Request.Form["id"]), Request.Form["newtname"]);
            }
            return RedirectToPage("/Project", new { id = Request.Form["id"], pid = Request.Form["pid"] });
        }

        public IActionResult OnPostDeleteTask()
        {
            if (Request.Form["id"] != "")
            {
                sQLToDoRepository.DeleteTask(Int32.Parse(Request.Form["id"]));
            }
            return RedirectToPage("/Project", new { pid = Request.Form["pid"] });
        }

        public IActionResult OnPostDeleteProject()
        {
            if (Request.Form["pid"] != "")
            {
                sQLToDoRepository.DeleteProject(Int32.Parse(Request.Form["pid"]));
            }
            return RedirectToPage("/Index");
        }

        public IActionResult OnPostChangeProjectName()
        {
            if (Request.Form["newpname"] != "")
            {
                sQLToDoRepository.UpdateProjectName(Int32.Parse(Request.Form["pid"]), Request.Form["newpname"]);
            }
            return RedirectToPage("/Project", new { pid = Request.Form["pid"], info = true });
        }
    }
}
