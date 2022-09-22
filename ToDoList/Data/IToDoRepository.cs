using ToDoList.Models;

namespace ToDoList.Data
{
    public interface IToDoRepository
    {
        IEnumerable<ToDo> GetAllTasks();
        IEnumerable<Project> GetAllProjects();
        IEnumerable<Category> GetAllCategories();
        IEnumerable<ToDo> GetOneCategory(int cid);
        IEnumerable<ToDo> GetOneProject(int pid);
        IEnumerable<ToDo> GetPriority();
        IEnumerable<ToDo> GetInbox();
        ToDo GetTaskInfo(int IdToDo);
        Project GetProjectInfo(int IdProject);
        void UpdateTask(int id, string upd);
        void AddNewTask(ToDo newToDo);
        void AddNewCategory(Category newCategory);
        void AddNewProject(Project newProject);
        void UpdateTaskName(int id, string newName);
        void DeleteTask(int id);
        void DeleteProject(int id);
        void UpdateProjectName(int id, string newName);
    }
}
