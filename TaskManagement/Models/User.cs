using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Models
{
    public class User
    {
    public Guid Id { get; set; }
    [MaxLength(20)]
    public string Username { get; set; }
    [MaxLength(30)] 
    public string Email { get; set; }
    [MaxLength(15)]
    public string Password { get; set; }
    public bool IsActive {  get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }
    public ICollection<UserTask>UserTasks { get; set; }
    }
}
