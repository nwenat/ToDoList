using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class Task
    {
        public int Id { get; set; }

        [Required]
        public string TaskName { get; set; }

        public DateTime When { get; set; }

        public Project Project { get; set; }

        [Required]
        public bool IsUrgent { get; set; }
    }
}
