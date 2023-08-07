using TaskManagement.Data;
using TaskManagement.Dto;
using TaskManagement.IRepository;
using Task = TaskManagement.Models.Task;
namespace TaskManagement.Repository
{
    public class TaskRepository:ITaskRepository
    {
        private readonly DataContext _Context;

        public TaskRepository(DataContext Context)
        {
            _Context = Context;
        }

        public bool CreateTask(Task task)
        {
            if (_Context.Task.Any(x => x.Title == task.Title && x.AssociatedProject == task.AssociatedProject))
            {
                return false;
            }
            _Context.Task.Add(task);
            return Save();

        }

        public bool DeleteTask(Task task)
        {


            _Context.Task.Remove(task);
            return Save();


        }

        public ICollection<Task> GetAllTasks()
        {
            return _Context.Task.ToList();
        }

        public Task GetTaskById(Guid id)
        {
            return _Context.Task.Where(t => t.TaskId == id).FirstOrDefault();
        }

        public bool TaskExists(Guid id)
        {
            return _Context.Task.Any(t => t.TaskId == id);
        }

        public bool UpdateTask(Guid id, TaskDto taskdto)
        {
            var tas = _Context.Task.Where(x => x.TaskId == id).FirstOrDefault();

            tas.Title = taskdto.Title;
            tas.Description = taskdto.Description;
            tas.Priority = taskdto.Priority;
            tas.AssociatedProject = taskdto.AssociatedProject;
            tas.DueDate = tas.DueDate;
            return Save();
        }
        public bool Save()
        {
            var saved = _Context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
