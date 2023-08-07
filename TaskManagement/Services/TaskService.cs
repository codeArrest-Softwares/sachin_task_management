using TaskManagement.Dto;
using TaskManagement.IRepository;
using TaskManagement.IServices;
using Task = TaskManagement.Models.Task;

namespace TaskManagement.Services
{
    public class TaskService:ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public bool CreateTask(Task task)
        {
            var p = new Task()
            {
                Title = task.Title,
                Description = task.Description,
                AssociatedProject = task.AssociatedProject,
                //  DueDate = DateTime.Now,
                DueDate = task.DueDate,
                Priority = task.Priority,

            };

            return _taskRepository.CreateTask(p);
        }

        public bool DeleteTask(Task task)
        {
            return _taskRepository.DeleteTask(task);

        }

        public ICollection<Task> GetAllTasks()
        {
            return _taskRepository.GetAllTasks();
        }

        public Task GetTaskById(Guid id)
        {
            return _taskRepository.GetTaskById(id);
        }

        public bool TaskExists(Guid id)
        {
            return _taskRepository.TaskExists(id);
        }

        public bool UpdateTask(Guid id, TaskDto taskdto)
        {
            return _taskRepository.UpdateTask(id, taskdto);
        }
    }
}
