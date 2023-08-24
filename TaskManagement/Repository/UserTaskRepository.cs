using Microsoft.EntityFrameworkCore;
using System.Data;
using TaskManagement.Data;
using TaskManagement.Dto;
using TaskManagement.IRepository;
using TaskManagement.Models;
using TaskManagement.Enums;
using Task = TaskManagement.Models.Task;

namespace TaskManagement.Repository
{
    public class UserTaskRepository:IUserTaskRepository
    {
        private readonly DataContext _context;

        public UserTaskRepository(DataContext context)
        {
            _context = context;
        }

        public bool AssignTask(User user, Models.Task task)
        {
            if (_context.UserTask.Any(rp => rp.User.Username == user.Username && rp.Task.Title == task.Title))
            {
                return false;
            }

            var x = new UserTask()
            {
                Task = task,
                User = user
            };
            _context.Task.Add(task);
            _context.User.Add(user);
            _context.UserTask.Add(x);
            return Save();
        }

        public bool DeleteUserTask(Guid UserId)
        {
            var user = _context.User.Where(x => x.Id == UserId).FirstOrDefault();
            var tid = _context.UserTask.Where(p => p.Id == UserId).Select(x => x.TaskId).FirstOrDefault();
            var task = _context.Task.Where(x => x.TaskId == tid).FirstOrDefault();
        if(task.Status==Enums.Status.Completed)
            {
                return false;
            }

            _context.Remove(task);
            return Save();
        }

        public UserTaskDto GetTaskByUserId(Guid UserId)
        {
            var user = _context.User.Where(x => x.Id == UserId).FirstOrDefault();

            var tasid = _context.UserTask.Where(p => p.Id == UserId).Select(x => x.TaskId).FirstOrDefault();
            var task = _context.Task.Where(x => x.TaskId == tasid).FirstOrDefault();


            var res = new UserTask()
            {
                Task = task,
                User = user
            };
            var k = new UserTaskDto()
            {
                UserId = user.Id,
                TaskId = tasid,
                Username = user.Username,
                TaskTitle=task.Title,
                AssociatedProject=task.AssociatedProject,
                Status=task.Status


            };
            return (k);
        }

        public bool UpdateUserTask(Guid id, UserTaskDto userTaskDto)
        {
            var user = _context.User.Where(x => x.Id == id).FirstOrDefault();

            var tasid = _context.UserTask.Where(p => p.Id == id).Select(x => x.TaskId).FirstOrDefault();
            var task = _context.Task.Where(x => x.TaskId == tasid).FirstOrDefault();
            var rid = _context.UserRole.Where(x => x.Id == id).Select(x=>x.RoleId).FirstOrDefault();
            var role = _context.Role.Where(x => x.RoleId == rid).FirstOrDefault();

            if (role.RoleName == "TeamMember")
            {
                task.Title = userTaskDto.TaskTitle;
                user.Username = userTaskDto.Username;

                task.Status = userTaskDto.Status;
                task.AssociatedProject = userTaskDto.AssociatedProject;
            }
            return Save();
        }

        public bool UserTaskExist(Guid id)
        {
            return _context.UserTask.Any(X=>X.Id==id);
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
