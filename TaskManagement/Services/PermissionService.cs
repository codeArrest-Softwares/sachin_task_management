using System.Security;
using TaskManagement.Dto;
using TaskManagement.IRepository;
using TaskManagement.IServices;
using TaskManagement.Models;
using TaskManagement.Repository;

namespace TaskManagement.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionService(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public bool CreatePermission(Permission permissionDto)
        {
            var permission = new Permission
            {

                PermissionName = permissionDto.PermissionName,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                //  IsActive = true
            };
            return _permissionRepository.CreatePermission(permission);
        }

        public bool DeletePermission(Permission permission)
        {
            return _permissionRepository.DeletePermission(permission);
        }

        public ICollection<Permission> GetAllPermissions()
        {
            return _permissionRepository.GetAllPermissions();
        }

        public Permission GetPermissionbyId(int id)
        {
            return _permissionRepository.GetPermissionbyId(id);
        }

        public bool PermissionExists(int userId)
        {
            return _permissionRepository.PermissionExists(userId);
        }

        public bool UpdatePermission(int id, Permission permissionDto)
        {
            return _permissionRepository.UpdatePermission(id, permissionDto);
        }
    }
}
