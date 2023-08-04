using TaskManagement.Models;

namespace TaskManagement.IRepository
{
    public interface IRoleRepository
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
