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

        public Category GetCategoryInfo(int IdCategory)
        {
            return _context.Category.Find(IdCategory);
        }
        public Project GetProjectInfo(int IdProject)
        {
            return _context.Project.Find(IdProject);
        }

        public ToDo GetTaskInfo(int IdToDo)
        {
            return _context.ToDo.Find(IdToDo);
        }


        public IEnumerable<ToDo> GetInbox()
        {
            return _context.ToDo.Where(e => ((e.Project == null) && (e.IsDone == false)) || ((e.Project == null) && (e.IsDone == true) && (e.WhenDone == DateTime.Today))).ToList();
        }

        public IEnumerable<ToDo> GetPriority()
        {
            //var output = _context.ToDo.Where(e => e.WhenToDo <= DateTime.Today).ToList();
            //output.ForEach(e => e.IsUrgent = true);
            //zapisac do bazy
            return _context.ToDo.Where(e => ((e.IsUrgent == true) && (e.IsDone == false)) || ((e.IsDone == true) && (e.WhenDone == DateTime.Today))).ToList();
        }




        public IEnumerable<ToDo> GetOneCategory()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ToDo> GetOneProject()
        {
            throw new NotImplementedException();
        }

        public void UpdateTask(int id, string upd)
        {
            ToDo toUpd = _context.ToDo.Find(id);
            if(upd.Equals("s"))
            {
                toUpd.IsUrgent = !toUpd.IsUrgent;
            } else if(upd.Equals("d"))
            {
                toUpd.IsDone = !toUpd.IsDone;
                toUpd.WhenDone = DateTime.Today;
            }
            _context.SaveChanges();
        }

        public void AddNewTask(ToDo newToDo) 
        {
            _context.ToDo.Add(newToDo);
            _context.SaveChanges();
        }

    }
}
