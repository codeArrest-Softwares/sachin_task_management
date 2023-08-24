namespace TaskManagement.Dto
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public Enums.Status Status { get; set; }
    }
}
