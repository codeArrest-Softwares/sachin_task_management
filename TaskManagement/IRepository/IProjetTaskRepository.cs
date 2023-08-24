using TaskManagement.Dto;
using Task = TaskManagement.Models.Task;
namespace TaskManagement.IRepository
{
    public interface IProjetTaskRepository
    {
        public ICollection <ProjectTaskDto> GetProjectTask();
         public bool GetProjectTaskById(Guid Id);
        public bool CreateProjectTask(Guid id, Task t);
        public bool UpdateProjectTask(Guid id,TaskDto t);
        public bool DeleteProjectTask(Guid id);

    }
}
