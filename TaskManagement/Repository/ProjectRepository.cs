using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TaskManagement.Data;
using TaskManagement.IRepository;
using TaskManagement.Models;

namespace TaskManagement.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DataContext _dataContext;

        public ProjectRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool CreateProject(Project p)
        {
           _dataContext.Project.Add(p);
            return Save();
        }

        public bool DeleteProject(Project p)
        {
           _dataContext.Remove(p);
            return Save();
        }

        public Project GetProjectById(Guid id)
        {
           var x=_dataContext.Project.Where(x=>x.Id == id).FirstOrDefault();
            
            return x;
        }

        public ICollection< Project> GetProjects()

        {
           return _dataContext.Project.ToList();
        }

        public bool ProjectExists(Guid projectId)
        {
           return _dataContext.Project.Any(x=>x.Id == projectId);
        }

        public bool UpdateProject(Guid id, Project p)
        {
            var project=_dataContext.Project.Where(x=>x.Id==id).FirstOrDefault();

            project.ProjectName = p.ProjectName;
            project.Status=p.Status;

            return Save();
        }
        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
