using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.Dto;
using TaskManagement.IRepository;
using TaskManagement.Models;
using Task = TaskManagement.Models.Task;


namespace TaskManagement.Repository
{
    public class ProjectTaskRepository:IProjetTaskRepository
    {
        private readonly DataContext _dataContext;

        public ProjectTaskRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool CreateProjectTask(Guid id, Task t)
        {
            var p=_dataContext.Project.Where(X=>X.Id == id).FirstOrDefault();
            if (p == null) return false;
            var projectTask = new ProjectTask()
            {
                Id = id,
                Project = p,
                Task = t
            };
            _dataContext.Task.Add(t);
            _dataContext.ProjectTask.Add(projectTask);
            return Save();
        }

        public bool DeleteProjectTask(Guid id)
        {
           var p=_dataContext.ProjectTask.Where(x=>x.Id == id).FirstOrDefault();
            if (p == null) return false;
            _dataContext.ProjectTask.Remove(p);
            return Save();
        }

        public bool GetProjectTaskById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProjectTask(Guid id, TaskDto ptdto)
        {
           var task=_dataContext.Task.Where(x=>x.TaskId==id).FirstOrDefault();      
            
            if(task== null) return false;
            task.Title = ptdto.Title;
            task.Description = ptdto.Description;
            task.Status = ptdto.Status;
            task.AssociatedProject= ptdto.AssociatedProject;
            task.Priority = ptdto.Priority;
            task.TaskCompletion= ptdto.TaskCompletion;
            task.DueDate=ptdto.DueDate;
            return Save();
            
        }
        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public ICollection <ProjectTaskDto> GetProjectTask()
        {
            var projectTasks = (from pt in _dataContext.ProjectTask
                             join project in _dataContext.Project on pt.Id equals project.Id
                             join task in _dataContext.Task on pt.TaskId equals task.TaskId
                             select new ProjectTaskDto
                             {
                                 Id = project.Id,
                                 ProjectName=project.ProjectName,
                                 Taskid=task.TaskId,
                                 TaskTitle=task.Title,
                                 TaskCompletion=task.TaskCompletion,
                                 Description=task.Description,
                                 Status=task.Status,
                                 Priority=task.Priority,
                                 AssociatedProject=task.AssociatedProject,
                                 DueDate=task.DueDate,
                                 
                                 
                             }).ToList();



            return projectTasks;
        }
    }
}
