using TaskManagement.Dto;
using TaskManagement.Models;

namespace TaskManagement.IRepository
{
    public interface IRolePermissionRepository
    {
        RolePermissionDto GetRolePermissionById(Guid RoleId);
        bool RolePermissionExist(Guid id);
        public bool CreateRolePermission(Role role ,Permission permission);
        public bool UpdateRolePermission(Guid id, RolePermissionDto rolepermissionDto);
        public bool DeleteRolePermission(Guid id);
    }
}
