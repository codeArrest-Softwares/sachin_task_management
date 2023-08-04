namespace TaskManagement.Dto
{
    public class RolePermissionDto
    {
        public Guid RoleId { get; set; }
        public int PermissionId { get; set; }
        public string RoleName { get; set; }
        public string Permission { get; set; }
    }
}
