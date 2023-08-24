using TaskManagement.Dto;
using TaskManagement.Models;
using Task = TaskManagement.Models.Task;

namespace TaskManagement.IServices
{
    public interface IUserTaskService
    {

        UserTaskDto GetTaskByUserId(Guid UserId);
        bool UserTaskExist(Guid id);
        public bool AssignTask( UserTaskDto task);
        public bool UpdateUserTask(Guid id, UserTaskDto userTaskdto);

        public bool DeleteUserTask(Guid UserId);

    }
}
