using Application.Commands.Books;
using Application.Queries.Books;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_Layer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var query = new GetAllBooksQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/Books/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var query = new GetBookByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // POST: api/Books
        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookCommand command)
        {
            var bookId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetBookById), new { id = bookId }, bookId);
        }

        // PUT: api/Books/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookCommand command)
        {
            if (id != command.Id)
                return BadRequest("Book ID mismatch.");

            var success = await _mediator.Send(command);
            if (!success)
                return NotFound();
            return NoContent();
        }

        // DELETE: api/Books/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var command = new DeleteBookCommand { Id = id };
            var success = await _mediator.Send(command);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }

    internal class GetAllBooksQuery : IRequest<object>
    {
    }

    internal class GetBookByIdQuery : IRequest<object>
    {
        public int Id { get; set; }
    }
}
