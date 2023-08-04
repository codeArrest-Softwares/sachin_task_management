using TaskManagement.Models;

namespace TaskManagement.IServices
{
    public interface IRoleService
    {
        ICollection<Role> GetAllRoles();
        Role GetRolebyId(Guid id);

        bool RoleExists(Guid userId);
        //  UserDto GetUserTrimToUpper(User userCreate);
        bool CreateRole(Role roleDto);
        bool UpdateRole(Guid id, Role roleDto);
        bool DeleteRole(Role role);
    }
}
