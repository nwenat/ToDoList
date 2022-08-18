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
        IEnumerable<ToDo> GetTaskInfo();
        IEnumerable<ToDo> GetProjectInfo();
        IEnumerable<ToDo> GetCategoryInfo();
    }
}
