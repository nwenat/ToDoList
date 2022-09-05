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

        public InboxModel(ToDoList.Data.ToDoListContext context)
        {
            _context = context;
            sQLToDoRepository = new SQLToDoRepository(_context);
        }
        public void OnGet(int? nav)
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
    }
}
