using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }

        public string CategoryColour { get; set; }
        public ICollection<ToDo>? ToDos { get; set; }
    }
}
