using BallastLaneTest.BusinessLogic;
using BallastLaneTest.BusinessLogic.Interfaces;
using BallastLaneTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace BallastLaneTest.API.Controllers
{
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private ILogicBook logicInstance;

        public BooksController(ILogger<BooksController> logger)
        {
            _logger = logger;
            logicInstance = (new BLFactory()).getLogicBook();
        }


        [HttpPost("CreateBook")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult CreateBook([FromBody] Book book)
        {
            try
            {
                var result = logicInstance.CreateBook(book);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetAllBooks")]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            try
            {
                var result = logicInstance.GetAllBooks();
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("UpdateBook")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult UpdateBook([FromBody] Book book)
        {
            try
            {
                var result = logicInstance.UpdateBook(book);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                var book = logicInstance.GetBookById(id);

                if (!book.IsSuccess)
                {
                    return NotFound();
                }

                var result = logicInstance.DeleteBook(id);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}