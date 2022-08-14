using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Pages.Projects
{
    public class IndexModel : PageModel
    {
        private readonly ToDoList.Data.ToDoListContext _context;

        public IndexModel(ToDoList.Data.ToDoListContext context)
        {
            _context = context;
        }

        public IList<Project> Project { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Project != null)
            {
                Project = await _context.Project.ToListAsync();
            }
        }
    }
}
