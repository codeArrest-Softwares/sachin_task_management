using TaskManagement.Dto;
using TaskManagement.Models;

namespace TaskManagement.IRepository
{
    public interface IUserRoleRepository
    {
        UserRoleDto GetUserRolebyId(Guid id);
        bool UserRoleExist(Guid id);
        public bool CreateUserRole(User user, Role role);
        public bool UpdateUserRole(Guid id, UserRoleDto userroleDto);
        public bool DeleteUserRole(Guid id);

    }
}
