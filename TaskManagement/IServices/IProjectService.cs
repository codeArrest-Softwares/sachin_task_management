using TaskManagement.Models;

namespace TaskManagement.IServices
{
    public interface IProjectService
    {
        public ICollection< Project> GetProjects();
       public   Project GetProjectById(Guid id);
        bool ProjectExists(Guid projectId);
        bool CreateProject(Project p);
        public bool UpdateProject(Guid id,Project p);
        public bool DeleteProject(Project p);
    }
}
