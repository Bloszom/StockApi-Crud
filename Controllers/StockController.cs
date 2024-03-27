using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using morningclassonapi.DTO.Account;
using morningclassonapi.Helper;
using morningclassonapi.Interfaces;
using morningclassonapi.Mapper;

namespace morningclassonapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockRepository _stockRepository;

        public StockController(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }


        [HttpGet("{id:int}")]
       

        public async Task<IActionResult> GetbyId([FromRoute] int id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stock = await _stockRepository.GetByIdAsync(id);

            
            if (stock == null)
            {
                return NotFound();
            }
            
            return Ok(stock.ToStock());

        }

        [HttpPost("create-stock")]
       

        public async Task<IActionResult> Create([FromBody] CreateStockDTO createStockDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stockModel = createStockDto.ToStockFromCreateDTO();
            await _stockRepository.CreateAsync(stockModel);

            return CreatedAtAction(nameof(GetbyId), new { id = stockModel.Id }, stockModel.ToStock());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateStockRequestDto updateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // check if stock firet exist, before updating
            var stockModel = await _stockRepository.UpdateAsync(id, updateDto);

            // check iif stockmodel is null
            if (stockModel == null)
            {
                return NotFound();
            }
            return Ok(stockModel.ToStock());
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var stocks = await _stockRepository.GetAllAsync(query);

            return Ok(stocks);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var stocks = await _stockRepository.DeleteAsync(id);
            // check iif stocks is null
            if (stocks == null)
            {
                return NotFound();
            }
            return NoContent();

        }


    }
}
