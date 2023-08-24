namespace TaskManagement.Models
{
    public class Project
    {
        public Guid Id { get; set; }             
        public string ProjectName { get; set; }
        public Enums.Status Status { get; set; }

        public ICollection<ProjectTask> ProjectTasks{ get; set; }




    }
}
