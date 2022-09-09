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

        public bool hasData = false;
        public string taskName = "";



        public IndexModel(ToDoList.Data.ToDoListContext context)
        {
            _context = context;
            sQLToDoRepository = new SQLToDoRepository(_context);
        }




        public void OnGet(int? nav, int? id, string? upd)
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

            if(nav != null)
            {
                if((int)nav==1)
                { 
                    wantProjects = true;
                    wantCategories = false;
                }else
                {
                    wantProjects = false;
                    wantCategories = true;
                }
            }

            //if (upd != null)
            //{
            //    int Id = id ?? 0;
            //    sQLToDoRepository.UpdateTask(Id, upd);
            //}

        }

        public IActionResult OnPost(int id, string upd)
        {

            if (upd != null)
            {
                //int Id = id ?? 0;
                sQLToDoRepository.UpdateTask(id, upd);
            }
            //hasData = true;
            //taskName = Request.Form["taskname"];
            return RedirectToPage("/Index");
        }
    }
}
