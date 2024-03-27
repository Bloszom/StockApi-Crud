using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using morningclassonapi.DTO.Account;
using morningclassonapi.Interfaces;
using morningclassonapi.Mapper;

namespace morningclassonapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IStockRepository _stockRepository;

        public CommentController(ICommentRepository CommentRepository, IStockRepository stockRepository)
        {
            _commentRepository = CommentRepository;
            _stockRepository = stockRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var comment = await _commentRepository.GetByIdAsync(id);


            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment.ToComment());
        }

        [HttpPost("{stockId:int}")]
        public async Task<IActionResult> Create([FromRoute] int stockId,[FromBody] CreateCommentDTO createCommentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //check if the stockexists
            if (!await _stockRepository.StockExist(stockId))
            {
                return BadRequest("Stock does not exist");
            }

            var commentModel = createCommentDto.ToCommentFromCreateDTO(stockId);
            await _commentRepository.CreateAsync(commentModel);

            return CreatedAtAction(nameof(GetById), new { id = commentModel.Id }, commentModel.ToComment());
        }


    }
}
