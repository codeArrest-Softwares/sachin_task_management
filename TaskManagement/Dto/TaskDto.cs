namespace TaskManagement.Dto
{
    public class TaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Enums.Priority Priority { get; set; }
        public string AssociatedProject { get; set; }
        public int TaskCompletion { get; set; }
        public Enums.Status Status { get; set; }
        public DateTime DueDate { get; set; }

    }
}
