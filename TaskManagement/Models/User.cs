namespace TaskManagement.Models
{
    public class User
    {
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsActive {  get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }
    }
}
