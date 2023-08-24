using TaskManagement.Dto;
using TaskManagement.Models;
using Task = TaskManagement.Models.Task;

namespace TaskManagement.IServices
{
    public interface IProjectTaskService
    {
        public ICollection<ProjectTaskDto> GetProjectTask();


        public bool GetProjectTaskById(Guid Id);
        public bool CreateProjectTask(Guid id, TaskDto t);
        public bool UpdateProjectTask(Guid id, TaskDto t);
        public bool DeleteProjectTask(Guid id);
    }
}
