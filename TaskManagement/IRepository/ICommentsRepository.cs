using Microsoft.AspNetCore.Mvc;
using TaskManagement.Dto;
using TaskManagement.Models;

namespace TaskManagement.IRepository
{
    public interface ICommentsRepository
    {
        public ICollection<Comments> GetAllComments();
        public Comments  GetCommentsByID(Guid id);

        bool CommentsExists(Guid CommentsId);
       
        bool CreateComments(Comments comments);
        bool UpdateComments(Guid CommentsId, CommentsDto commentsdto);
        bool DeleteComments(Comments comment);

    }
}
