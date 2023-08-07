using TaskManagement.Models;

namespace TaskManagement.IRepository
{
    public interface IPermissionRepository
    {
        ICollection<Permission> GetAllPermissions();
        Permission GetPermissionbyId(int id);

        bool PermissionExists(int userId);
        //  UserDto GetUserTrimToUpper(User userCreate);
        bool CreatePermission(Permission permissionDto);
        bool UpdatePermission(int id, Permission permissionDto);
        bool DeletePermission(Permission permission);

    }
}
