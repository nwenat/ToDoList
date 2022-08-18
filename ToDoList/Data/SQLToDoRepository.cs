using ToDoList.Models;

namespace ToDoList.Data
{
    public class SQLToDoRepository : IToDoRepository
    {
        private readonly ToDoListContext _context;

        public SQLToDoRepository(ToDoListContext context)
        {
            _context = context;
        }

        public IEnumerable<ToDo> GetAllTasks()
        {
            return _context.ToDo.ToList();
        }

        public IEnumerable<Project> GetAllProjects()
        {
            return _context.Project.ToList();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Category.ToList();
        }



        public IEnumerable<ToDo> GetCategoryInfo()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ToDo> GetInbox()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ToDo> GetOneCategory()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ToDo> GetOneProject()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ToDo> GetPriority()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ToDo> GetProjectInfo()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ToDo> GetTaskInfo()
        {
            throw new NotImplementedException();
        }
    }
}
