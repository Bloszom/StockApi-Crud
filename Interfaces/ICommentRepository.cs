using morningclassonapi.Model;

namespace morningclassonapi.Interfaces
{
    public interface ICommentRepository
    {
        Task<Comment> CreateAsync(Comment CommentModel);

        Task<Comment> GetByIdAsync(int id);

    }
}
