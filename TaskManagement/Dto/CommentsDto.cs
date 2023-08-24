using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Dto
{
    public class CommentsDto
    {
      
        [MaxLength(30)]
        public string Author { get; set; }
        [MaxLength(500)]
        public string Text { get; set; }
        public DateTime TimeStamp { get; set; }

    }
}
