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
            if (_context.ToDo != null)
            {
                return _context.ToDo.ToList();
            }
            return null;
        }



        public IEnumerable<ToDo> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ToDo> GetAllProjects()
        {
            throw new NotImplementedException();
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
