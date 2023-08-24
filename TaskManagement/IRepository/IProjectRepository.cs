using TaskManagement.Models;

namespace TaskManagement.IRepository
{
    public interface IProjectRepository
    {


        public ICollection<Project> GetProjects();

        public Project GetProjectById(Guid id);
        bool ProjectExists(Guid projectId);
       public  bool CreateProject(Project p);
        public bool UpdateProject(Guid id,Project p);
        public bool DeleteProject(Project p);



    }
}
