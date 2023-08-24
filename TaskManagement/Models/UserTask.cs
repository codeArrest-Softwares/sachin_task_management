namespace TaskManagement.Models
{
    public class UserTask
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }

        public User User { get; set; }
        public Task Task { get; set; }
      
    }
}
