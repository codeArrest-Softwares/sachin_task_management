namespace TaskManagement.Models
{
    public class ProjectTask
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public Project Project { get; set; }
        public Task Task { get; set; }
    }
}
