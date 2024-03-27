using morningclassonapi.Model;
using System.ComponentModel.DataAnnotations;

namespace morningclassonapi.DTO.Account
{
    public class CreateCommentDTO
    {
       
        [Required]
        [MinLength(10, ErrorMessage = "Title can be more than 10 characters")]
        [MaxLength(280, ErrorMessage = "Title can nto be more than 500 characters")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(10, ErrorMessage = "Content can be more than 280 characters")]
        [MaxLength(280, ErrorMessage = "comment can nto be more than 500 characters")]
        public string Content { get; set; } = string.Empty;

     /*   public DateTime CreatedOn { get; set; } = DateTime.Now;

        public int? StockId { get; set; }

        public Stock? Stock { get; set; }*/

    }
}
