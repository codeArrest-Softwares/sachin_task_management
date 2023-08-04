namespace TaskManagement.Models
{
    public class Role
    {
         public Guid RoleId { get; set; }
        public string RoleName { get; set; }
   //     public bool IsActive { get; set; }
        public  DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set;}
        public ICollection<RolePermission> RolePermissions{ get; set; } 
        public ICollection<UserRole>UserRoles{ get; set; }



        




    }
}
