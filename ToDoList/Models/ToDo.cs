using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class ToDo
    {
        public int Id { get; set; }

        [Required]
        public string TaskName { get; set; }

        public DateTime? WhenToDo { get; set; }

        public Project? Project { get; set; }
        public ICollection<Category>? Categories { get; set; }
        public bool IsUrgent { get; set; }

        public bool IsDone { get; set; }
    }
}
