using ToDoList.Models;

namespace ToDoList.Data
{
    public interface IToDoRepository
    {
        IEnumerable<ToDo> GetAllTasks();
        IEnumerable<Project> GetAllProjects();
        IEnumerable<Category> GetAllCategories();
        IEnumerable<ToDo> GetOneCategory();
        IEnumerable<ToDo> GetOneProject();
        IEnumerable<ToDo> GetPriority();
        IEnumerable<ToDo> GetInbox();
        ToDo GetTaskInfo(int IdToDo);
        Project GetProjectInfo(int IdProject);
        void UpdateTask(int id, string upd);
    }
}
