using TaskManagement.Dto;
using TaskManagement.IRepository;
using TaskManagement.IServices;
using TaskManagement.Models;

namespace TaskManagement.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository _commentsRepository;

        public CommentsService(ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }
        public bool CommentsExists(Guid CommentsId)
        {
           return _commentsRepository.CommentsExists(CommentsId);
        }

        public bool CreateComments(Comments comments)
        {
            var comment = new Comments()
            {
                Author = comments.Author,
                Text = comments.Text,
                TimeStamp = DateTime.Now,

            };
            return _commentsRepository.CreateComments(comment);
        }

        public bool DeleteComments(Comments comment)
        {
           return _commentsRepository.DeleteComments(comment);
        }

        public ICollection<Comments> GetAllComments()
        {
          return _commentsRepository.GetAllComments();
        }

        public Comments GetCommentsByID(Guid id)
        {
            return _commentsRepository.GetCommentsByID(id);
        }

        public bool UpdateComments(Guid CommentsId, CommentsDto commentsdto)
        {
            return _commentsRepository.UpdateComments(CommentsId, commentsdto);
        }
    }
}
