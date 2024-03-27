using morningclassonapi.DTO.Account;
using morningclassonapi.Model;

namespace morningclassonapi.Mapper
{
    public static class CommentMapper
    {

        public static Comment ToCommentFromCreateDTO(this CreateCommentDTO commentDto, int stockId)
        {

            return new Comment
            {
                Title = commentDto.Title,
                Content = commentDto.Content,
                StockId = stockId
            };

        }

        public static CommentDTO ToComment(this Comment commentDto)
        {

            return new CommentDTO
            {
                Id = commentDto.Id,
                Title = commentDto.Title,
                Content = commentDto.Content,
                CreatedOn = commentDto.CreatedOn,
                StockId = commentDto.StockId,
            };

        }

    }
}
