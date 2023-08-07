using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Models
{
    public class Permission
    {
        public int PermissionId { get; set; }

        [MaxLength(255)]
        public string PermissionName { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ICollection<RolePermission> RolePermissions { get; set; }
        






    }
}
