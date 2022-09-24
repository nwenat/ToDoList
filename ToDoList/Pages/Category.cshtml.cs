using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Pages
{
    public class CategoryModel : PageModel
    {
        private readonly ToDoList.Data.ToDoListContext _context;
        private SQLToDoRepository sQLToDoRepository;

        public IList<ToDo> CategoryTaskList { get; set; } = default!;
        public IList<Project> ProjectsList { get; set; } = default!;
        public IList<Category> CategoriesList { get; set; } = default!;

        public bool wantProjects = false;
        public bool wantCategories = true;
        public bool showDetails = false;
        public bool showCategoryInfo = false;
        public int DetailsId = 0;
        public int categoryId = 0;

        public CategoryModel(ToDoList.Data.ToDoListContext context)
        {
            _context = context;
            sQLToDoRepository = new SQLToDoRepository(_context);
        }
        public void OnGet(int cId, int? nav, int? id, bool? info)
        {
            if (_context.ToDo != null)
            {
                CategoryTaskList = (IList<ToDo>)sQLToDoRepository.GetOneCategory(cId);
            }
            if (_context.Project != null)
            {
                ProjectsList = (IList<Project>)sQLToDoRepository.GetAllProjects();
            }

            if (_context.Category != null)
            {
                CategoriesList = (IList<Category>)sQLToDoRepository.GetAllCategories();
            }

            categoryId = cId;

            if ((info != null) && (bool)info)
            {
                showCategoryInfo = true;
            }
            else if ((id != null) && (CategoryTaskList.Select(p => p.Id).ToList().Contains((int)id)))
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
            return RedirectToPage("/Category", new { cid = Request.Form["cid"] });
        }

        public IActionResult OnPostUpdateDetails()
        {
            if (Request.Form["id"] != "")
            {
                sQLToDoRepository.UpdateTask(Int32.Parse(Request.Form["id"]), Request.Form["upd"]);
            }
            return RedirectToPage("/Category", new { id = Request.Form["id"], cid = Request.Form["cid"] });
        }

        public IActionResult OnPostAdd()
        {
            if (Request.Form["taskname"] != "")
            {
                var newToDo = new ToDo
                {
                    TaskName = Request.Form["taskname"],
                    Categories = new List<Category> { sQLToDoRepository.GetCategoryInfo(Int32.Parse(Request.Form["cid"])) },
                    IsUrgent = false
                };
                sQLToDoRepository.AddNewTask(newToDo);
            }
            return RedirectToPage("/Category", new { cid = Request.Form["cid"] });
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
            return RedirectToPage("/Category", new { cid = Request.Form["cid"], nav = 1 });
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
            return RedirectToPage("/Category", new { cid = Request.Form["cid"], nav = 2 });
        }

        public IActionResult OnPostChangeTaskName()
        {
            if (Request.Form["newtname"] != "")
            {
                sQLToDoRepository.UpdateTaskName(Int32.Parse(Request.Form["id"]), Request.Form["newtname"]);
            }
            return RedirectToPage("/Category", new { id = Request.Form["id"], cid = Request.Form["cid"] });
        }

        public IActionResult OnPostDeleteTask()
        {
            if (Request.Form["id"] != "")
            {
                sQLToDoRepository.DeleteTask(Int32.Parse(Request.Form["id"]));
            }
            return RedirectToPage("/Category", new { cid = Request.Form["cid"] });
        }

        public IActionResult OnPostDeleteCategory()
        {
            if (Request.Form["cid"] != "")
            {
                sQLToDoRepository.DeleteCategory(Int32.Parse(Request.Form["cid"]));
            }
            return RedirectToPage("/Index");
        }

        public IActionResult OnPostChangeCategoryName()
        {
            if (Request.Form["newcname"] != "")
            {
                sQLToDoRepository.UpdateCategoryName(Int32.Parse(Request.Form["cid"]), Request.Form["newcname"]);
            }
            return RedirectToPage("/Category", new { cid = Request.Form["cid"], info = true });
        }
    }
}
