using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Models
{
    public class Comments
    {
        public Guid CommentsID { get; set; }
        [MaxLength(30)]
        public string Author { get; set; }
        [MaxLength(500)]
        public string Text { get; set; }
         public DateTime TimeStamp { get; set; }

        public ICollection<TaskComment> TaskComment { get; set; }

    }
}
