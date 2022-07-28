using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        public string ProjectName { get; set; }
    }
}
