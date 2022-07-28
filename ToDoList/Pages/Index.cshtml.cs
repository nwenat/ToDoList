using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ToDoList.Pages
{
    public class ListModel : PageModel
    {
        public bool hasData = false;
        public string taskName = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            hasData = true;
            taskName = Request.Form["taskname"];
        }
    }
}
