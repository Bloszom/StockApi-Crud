using Microsoft.EntityFrameworkCore;
using morningclassonapi.Data;
using morningclassonapi.Interfaces;
using morningclassonapi.Model;

namespace morningclassonapi.Reposistory
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _context;

        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Comment> CreateAsync(Comment CommentModel)
        {
            await _context.Comments.AddAsync(CommentModel);
            await _context.SaveChangesAsync();
            return CommentModel;
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            return await _context.Comments.Include(c => c.Stock).FirstOrDefaultAsync(i => i.Id == id);
        }

    }
}
