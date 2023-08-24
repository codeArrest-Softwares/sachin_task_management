namespace TaskManagement.Dto
{
    public class ProjectTaskDto
    {   
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public Guid Taskid { get; set; }
        public string TaskTitle { get; set; }
        public string Description { get; set; }
        public Enums.Priority Priority { get; set; }
        public string AssociatedProject { get; set; }
        public int TaskCompletion { get; set; }
        public Enums.Status Status { get; set; }
        public DateTime DueDate { get; set; }

    }
}
