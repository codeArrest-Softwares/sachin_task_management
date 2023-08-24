namespace TaskManagement.Models
{
    public class TaskComment
    {
        public Guid TaskId { get; set; }
        public Guid CommentsID { get; set; }

        public Task Task { get; set; }
        public Comments Comments { get; set; }

    }
}
