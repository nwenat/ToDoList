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
            return _context.ToDo.Where(e => ((e.Project == null) && (e.IsDone == false)) || ((e.Project == null) && (e.IsDone == true) && (e.WhenDone == DateTime.Today))).OrderBy(e => e.IsDone).ToList();
        }

        public IEnumerable<ToDo> GetPriority()
        {
            return _context.ToDo.Where(e => ((e.IsUrgent == true) && (e.IsDone == false)) || ((e.IsDone == true) && (e.WhenDone == DateTime.Today))).OrderBy(e => e.IsDone).ToList();
        }

        public IEnumerable<ToDo> GetOneCategory(int cid)
        {
            return _context.ToDo.Where(e => ((e.Project.Id == cid) && (e.IsDone == false)) || ((e.Project.Id == cid) && (e.WhenDone == DateTime.Today))).OrderBy(e => e.IsDone).ToList();
        }

        public IEnumerable<ToDo> GetOneProject(int pid)
        {
            return _context.ToDo.Where(e => ((e.Project.Id == pid) && (e.IsDone == false)) || ((e.Project.Id == pid) && (e.WhenDone == DateTime.Today))).OrderBy(e => e.IsDone).ToList();
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

        public void AddNewCategory(Category newCategory)
        {
            _context.Category.Add(newCategory);
            _context.SaveChanges();
        }

        public void AddNewProject(Project newProject)
        {
            _context.Project.Add(newProject);
            _context.SaveChanges();
        }

        public void UpdateTaskName(int id, string newName)
        {
            ToDo toUpd = _context.ToDo.Find(id);
            toUpd.TaskName = newName;
            
            _context.SaveChanges();
        }
        
        public void DeleteTask(int id)
        {
            ToDo toDelete = _context.ToDo.Find(id);

            if (toDelete.Project != null)
            {
                toDelete.Project = null;
            }
            if (toDelete.Categories != null)
            {
                toDelete.Categories = null;
            }
            _context.ToDo.Remove(toDelete);

            _context.SaveChanges();
        }

        public void UpdateProjectName(int id, string newName)
        {
            Project toUpd = _context.Project.Find(id);
            toUpd.ProjectName = newName;

            _context.SaveChanges();
        }

        public void DeleteProject(int id)
        {
            Project toDelete = _context.Project.Find(id);

            foreach(ToDo taskInProject in _context.ToDo.Where(t => t.Project == toDelete).ToList())
            {
                _context.ToDo.Remove(taskInProject);
            }
            _context.Project.Remove(toDelete);

            _context.SaveChanges();
        }
    }
}
