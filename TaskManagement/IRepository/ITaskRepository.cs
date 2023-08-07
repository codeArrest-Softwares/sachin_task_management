using TaskManagement.Dto;
using Task = TaskManagement.Models.Task;
namespace TaskManagement.IRepository
{
    public interface ITaskRepository
    {
        ICollection<Task> GetAllTasks();
        Task GetTaskById(Guid id);
        bool TaskExists(Guid id);      
        bool CreateTask(Task task);
        bool UpdateTask(Guid id, TaskDto task);
        bool DeleteTask(Task task);

    }
}
