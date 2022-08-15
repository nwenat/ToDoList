using ToDoList.Models;

namespace ToDoList.Data
{
    public interface IToDoRepository
    {
        IEnumerable<ToDo> GetAllTasks();
        IEnumerable<ToDo> GetAllProjects();
        IEnumerable<ToDo> GetAllCategories();
        IEnumerable<ToDo> GetOneCategory();
        IEnumerable<ToDo> GetOneProject();
        IEnumerable<ToDo> GetPriority();
        IEnumerable<ToDo> GetInbox();
        IEnumerable<ToDo> GetTaskInfo();
        IEnumerable<ToDo> GetProjectInfo();
        IEnumerable<ToDo> GetCategoryInfo();
    }
}
