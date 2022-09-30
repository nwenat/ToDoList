using Microsoft.EntityFrameworkCore;
using ToDoList.Data;

namespace ToDoList.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ToDoListContext(
                serviceProvider.GetRequiredService<DbContextOptions<ToDoListContext>>()))
            {
                if (context == null || context.ToDo == null || context.Project == null || context.Category == null)
                {
                    throw new ArgumentNullException("Null ToDoListContext");
                }

                if (context.ToDo.Any() || context.Project.Any() || context.Category.Any())
                {
                    return;
                }

                Project p1 = new Project() { ProjectName = "Work", ProjectColour = "#e2e2e2;" };
                Project p2 = new Project() { ProjectName = "Home", ProjectColour = "#e2e2e2;" };
                Project p3 = new Project() { ProjectName = "Garden", ProjectColour = "#e2e2e2;" };

                context.Project.AddRange(p1, p2, p3);

                Category c1 = new Category() { CategoryName = "computer", CategoryColour = "#e2e2e2;" };
                Category c2 = new Category() { CategoryName = "in home", CategoryColour = "#e2e2e2;" };
                Category c3 = new Category() { CategoryName = "errands", CategoryColour = "#e2e2e2;" };

                context.Category.AddRange(c1, c2, c3);

                context.ToDo.AddRange(
                    new ToDo
                    {
                        TaskName = "Find intresting companies",
                        Project = p1,
                        Categories = new[] { c1 },
                        IsUrgent = false,
                    },
                    new ToDo
                    {
                        TaskName = "Prepare your CV",
                        Project = p1,
                        Categories = new[] { c1 },
                        IsUrgent = true
                    },
                    new ToDo
                    {
                        TaskName = "New TV",
                        Project = p2,
                        Categories = new[] { c3 },
                        IsUrgent = false
                    },
                    new ToDo
                    {
                        TaskName = "Find inspiration, sample photos",
                        Project = p3,
                        Categories = new[] { c1 },
                        IsUrgent = false
                    },
                    new ToDo
                    {
                        TaskName = "Meeting with friends",
                        WhenToDo = new DateTime(2022, 10, 04),
                        IsUrgent = false
                    }
                    );
                context.SaveChanges();
            }
        }

    }
}
