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

        public InboxModel(ToDoList.Data.ToDoListContext context)
        {
            _context = context;
            sQLToDoRepository = new SQLToDoRepository(_context);
        }
        public void OnGet()
        {
            if (_context.ToDo != null)
            {
                InboxList = (IList<ToDo>)sQLToDoRepository.GetInbox();
            }
        }
    }
}
