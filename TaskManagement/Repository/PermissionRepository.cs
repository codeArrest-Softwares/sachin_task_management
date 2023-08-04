using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security;
using TaskManagement.Data;
using TaskManagement.Dto;
using TaskManagement.IRepository;
using TaskManagement.Models;

namespace TaskManagement.Repository
{
    public class PermissionRepository : IPermissionRepository

    {
        private readonly DataContext _Context;

        public PermissionRepository(DataContext Context)
        {
            _Context = Context;
        }
        public bool CreatePermission(Permission permission)
        {
            _Context.Permission.Add(permission);
            return Save();
        }

        public bool DeletePermission(Permission permission)
        {
            _Context.Permission.Remove(permission);
            return Save();
        }

        public ICollection<Permission> GetAllPermissions()
        {
            return _Context.Permission.ToList();
        }

        public Permission GetPermissionbyId(int id)
        {
           return _Context.Permission.Where(p => p.PermissionId == id).FirstOrDefault();
        }

        public bool PermissionExists(int userId)
        {
            return _Context.Permission.Any(p => p.PermissionId == userId);
        }

        public bool UpdatePermission(int id, Permission permissionDto)
        {
            _Context.Update(permissionDto);
            return Save();
        }
        public bool Save()
        {
            var saved = _Context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
