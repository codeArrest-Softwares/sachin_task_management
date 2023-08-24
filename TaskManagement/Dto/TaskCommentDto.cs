using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Dto
{
    public class TaskCommentDto
    {
        public Guid CommentsID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
       
        public string AssociatedProject { get; set; }
        public string Author { get; set; }
      
        public string Text { get; set; }
    }
}
