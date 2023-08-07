using TaskManagement.Dto;
using TaskManagement.Models;

namespace TaskManagement.IServices
{
    public interface IRolePermissionService
    {
        RolePermissionDto GetRolePermissionById(Guid RoleId);
        bool RolePermissionExist(Guid id);
        public bool CreateRolePermission(RolePermissionDto rolepermission);
        public bool UpdateRolePermission(Guid id, RolePermissionDto rolepermissionDto);
        public bool DeleteRolePermission(Guid id);
    }
}
