namespace TaskManagement.Models
{
    public class Permission
    {
        public int PermissionId { get; set; } 
        public string PermissionName { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ICollection<RolePermission> RolePermissions { get; set; }
        






    }
}
