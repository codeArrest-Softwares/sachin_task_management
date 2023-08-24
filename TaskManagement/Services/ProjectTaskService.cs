using TaskManagement.Dto;
using TaskManagement.IRepository;
using TaskManagement.IServices;
using TaskManagement.Models;
using Task = TaskManagement.Models.Task;

namespace TaskManagement.Services
{
    public class ProjectTaskService : IProjectTaskService
    {
     
        private readonly IProjetTaskRepository _projetTaskRepository;

        public ProjectTaskService(IProjetTaskRepository projetTaskRepository)
        {
           
            _projetTaskRepository = projetTaskRepository;
        }
        public bool CreateProjectTask(Guid id,TaskDto t)
        {
            var k = new Task
            {
               Title=t.Title,
               Description=t.Description,
               Priority=t.Priority,
               AssociatedProject=t.AssociatedProject,
               TaskCompletion=t.TaskCompletion,
               Status=t.Status,
               DueDate=t.DueDate,


            };
            return _projetTaskRepository.CreateProjectTask(id, k);
           
        }

        public bool DeleteProjectTask(Guid id)
        {
            return _projetTaskRepository.DeleteProjectTask(id);
        }

        public ICollection < ProjectTaskDto> GetProjectTask()
        {
            return _projetTaskRepository.GetProjectTask();  
        }

        public bool GetProjectTaskById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProjectTask(Guid id, TaskDto t)
        {
            return _projetTaskRepository.UpdateProjectTask(id, t);
        }
    }
}
