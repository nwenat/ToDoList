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
                if (context == null || context.ToDo == null || context.Project == null)
                {
                    throw new ArgumentNullException("Null ToDoListContext");
                }

                if (context.ToDo.Any() || context.Project.Any())
                {
                    return;
                }

                Project p1 = new Project() { ProjectName = "Work" };
                Project p2 = new Project() { ProjectName = "Home" };
                Project p3 = new Project() { ProjectName = "Garden" };

                context.Project.AddRange(p1, p2, p3);

                context.ToDo.AddRange(
                    new ToDo
                    {
                        TaskName = "Find intresting companies",
                        Project = p1,
                        IsUrgent = false
                    },
                    new ToDo
                    {
                        TaskName = "Prepare your CV",
                        Project = p1,
                        IsUrgent = true
                    },
                    new ToDo
                    {
                        TaskName = "New TV",
                        Project = p2,
                        IsUrgent = false
                    },
                    new ToDo
                    {
                        TaskName = "Find inspiration, sample photos",
                        Project = p3,
                        IsUrgent = false
                    },
                    new ToDo
                    {
                        TaskName = "Meeting with friends",
                        When = new DateTime(2022, 09, 04),
                        IsUrgent = false
                    }
                    );
                context.SaveChanges();
            }
        }

    }
}
