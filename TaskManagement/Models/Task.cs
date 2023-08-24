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
        public int TaskCompletion  { get; set; }
        public Enums.Priority Priority { get; set; }
        [MaxLength(100)]
        public string AssociatedProject { get; set; }
        public Enums.Status Status { get; set; }
        public DateTime DueDate { get; set; }
        public ICollection<UserTask> UserTasks { get; set; }
        public ICollection<TaskComment> TaskComment { get; set; }
        public ICollection<ProjectTask> ProjectTasks { get; set; }


    }
}
