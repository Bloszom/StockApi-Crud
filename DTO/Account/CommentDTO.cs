using morningclassonapi.Model;

namespace morningclassonapi.DTO.Account
{
    public class CommentDTO
    {

        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public int? StockId { get; set; }

    

    }
}
