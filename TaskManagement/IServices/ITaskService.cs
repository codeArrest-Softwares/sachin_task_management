using TaskManagement.Dto;
using Task = TaskManagement.Models.Task;
namespace TaskManagement.IServices
{
    public interface ITaskService
    {
        ICollection<Task> GetAllTasks();
        ICollection<Task> GetAllTasksByDeadlines();
        Task GetTaskById(Guid id);
        bool TaskExists(Guid id);       
        bool CreateTask(Task task);
        bool UpdateTask(Guid id, TaskDto task);
        bool DeleteTask(Task task);
    }
}
