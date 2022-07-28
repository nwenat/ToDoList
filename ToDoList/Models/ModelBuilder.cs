namespace ToDoList.Models
{
    public class ModelBuilder
    {
        public void Seed()
        {
            List<Project> projects = new List<Project>();

            projects.Add(new Project() {ProjectName = "Work" });
            projects.Add(new Project() {ProjectName = "Home" });
            projects.Add(new Project() {ProjectName = "Car" });

        }
    }
}
