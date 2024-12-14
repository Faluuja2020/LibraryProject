using Application.Commands.Authors;
using Application.Queries.Authors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_Layer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var query = new GetAllAuthorsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/Authors/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var query = new GetAuthorByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // POST: api/Authors
        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorCommand command)
        {
            var authorId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAuthorById), new { id = authorId }, authorId);
        }

        // PUT: api/Authors/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] UpdateAuthorCommand command)
        {
            if (id != command.Id)
                return BadRequest("Author ID mismatch.");

            var success = await _mediator.Send(command);
            if (!success)
                return NotFound();
            return NoContent();
        }

        // DELETE: api/Authors/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var command = new DeleteAuthorCommand { Id = id };
            var success = await _mediator.Send(command);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }

    internal class GetAllAuthorsQuery : IRequest<object>
    {
    }

    internal class GetAuthorByIdQuery : IRequest<object>
    {
        public int Id { get; set; }
    }
}
