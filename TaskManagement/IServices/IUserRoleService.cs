using TaskManagement.Dto;

namespace TaskManagement.IServices
{
    public interface IUserRoleService
    {
        UserRoleDto GetUserRolebyId(Guid id);
        bool UserRoleExist(Guid id);
        public bool CreateUserRole(UserRoleDto userRoleDto);
        public bool UpdateUserRole(Guid id, UserRoleDto userroleDto);
        public bool DeleteUserRole(Guid id);
    }
}
