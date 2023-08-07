namespace TaskManagement.Dto
{
    public class UserTaskDto
    {
        public Guid UserId { get; set; }
        public Guid TaskId { get; set; }
        public string Username { get; set; }
        public string TaskTitle { get; set; }
        public string AssociatedProject { get; set; }

    }
}
