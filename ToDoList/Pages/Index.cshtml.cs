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

        public IList<ToDo> TaskList { get; set; } = default!;

        public bool hasData = false;
        public string taskName = "";



        public ListModel(ToDoList.Data.ToDoListContext context)
        {
            _context = context;
            sQLToDoRepository = new SQLToDoRepository(_context);
        }




        public void OnGet()
        {
            TaskList = (IList<ToDo>)sQLToDoRepository.GetAllTasks();
        }

        public void OnPost()
        {
            hasData = true;
            taskName = Request.Form["taskname"];
        }
    }
}
