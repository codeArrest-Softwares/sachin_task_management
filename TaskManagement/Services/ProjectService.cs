using TaskManagement.IRepository;
using TaskManagement.IServices;
using TaskManagement.Models;

namespace TaskManagement.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public bool CreateProject(Project p)
        {
            var x = new Project()
            {
                ProjectName = p.ProjectName,
                Status = p.Status
            };
          return  _projectRepository.CreateProject(x);
        }

        public bool DeleteProject(Project p)
        {
            return _projectRepository.DeleteProject(p); 
        }

        public Project GetProjectById(Guid id)
        {
           return   _projectRepository.GetProjectById(id);
        }

        public ICollection<Project> GetProjects()

        {
           return _projectRepository.GetProjects(); 
        }

        public bool ProjectExists(Guid projectId)
        {
           return _projectRepository.ProjectExists(projectId);
        }

        public bool UpdateProject(Guid id, Project p)
        {
            return _projectRepository.UpdateProject(id,p);
        }
    }
}
