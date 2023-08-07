using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Models
{
    public class Task
    {
        public Guid TaskId { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [MaxLength(50)]
        public string Priority { get; set; }
        [MaxLength(100)]
        public string AssociatedProject { get; set; }

        public DateTime DueDate { get; set; }
        public ICollection<UserTask> UserTasks { get; set; }
    }
}
