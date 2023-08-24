using TaskManagement.Data;
using TaskManagement.Dto;
using TaskManagement.IRepository;
using TaskManagement.Models;

namespace TaskManagement.Repository
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly DataContext _Context;

        public CommentsRepository(DataContext Context)
        {
            _Context = Context;
        }
        public bool CommentsExists(Guid CommentsId)
        {
            return _Context.Comments.Any(x=>x.CommentsID == CommentsId);
        }

        public bool CreateComments(Comments comments)
        {
            if (_Context.Comments.Any(x => x.Author == comments.Author && x.Text == comments.Text))
                return false;

            _Context.Comments.Add(comments);
            return Save();

           
                
        }

        public bool DeleteComments(Comments comment)
        {
            _Context.Remove(comment);
            return Save();

        }

        public ICollection<Comments> GetAllComments()
        {
            return _Context.Comments.ToList();
        }

        public Comments GetCommentsByID(Guid id)
        {
            return _Context.Comments.Where(x => x.CommentsID == id).FirstOrDefault();
        }

        public bool UpdateComments(Guid CommentsId, CommentsDto commentsdto)
        {
            var comment = _Context.Comments.Where(x => x.CommentsID == CommentsId).FirstOrDefault();

            comment.Text= commentsdto.Text;
            comment.Author= commentsdto.Author;
            comment.TimeStamp= commentsdto.TimeStamp;

            return Save();

        }

        public bool Save()
        {
            var saved = _Context.SaveChanges();
            return saved > 0 ? true : false;
        }

    }
}
