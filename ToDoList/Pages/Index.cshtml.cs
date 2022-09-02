using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Pages
{
    public class ListModel : PageModel
    {
        private readonly ToDoList.Data.ToDoListContext _context;
        private SQLToDoRepository sQLToDoRepository;

        public IList<ToDo> PriorityList { get; set; } = default!;
        public IList<Project> ProjectsList { get; set; } = default!;
        public IList<Category> CategoriesList { get; set; } = default!;

        public bool hasData = false;
        public string taskName = "";



        public ListModel(ToDoList.Data.ToDoListContext context)
        {
            _context = context;
            sQLToDoRepository = new SQLToDoRepository(_context);
        }




        public void OnGet()
        {
            if (_context.ToDo != null)
            {
                PriorityList = (IList<ToDo>)sQLToDoRepository.GetPriority();
                ProjectsList = (IList<Project>)sQLToDoRepository.GetAllProjects();
            }

            if (_context.Project != null)
            {
                ProjectsList = (IList<Project>)sQLToDoRepository.GetAllProjects();
            }

            if (_context.Category != null)
            {
                CategoriesList = (IList<Category>)sQLToDoRepository.GetAllCategories();
            }
        }

        public void OnPost()
        {
            hasData = true;
            taskName = Request.Form["taskname"];
        }
    }
}
