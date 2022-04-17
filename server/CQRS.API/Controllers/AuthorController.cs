using CQRS.Domain.Models;
using CQRS.Infrastructure.Commands.AuthorCommands;
using CQRS.Infrastructure.Queries.AuthorQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CQRS.API.Controllers
{
    [SwaggerTag("This is a controller to Author")]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {
        private readonly ILogger<AuthorController> _logger;
        private readonly IMediator _authorMediator;

        public AuthorController(ILogger<AuthorController> logger, IMediator authorMediator)
        {
            _logger = logger;
            _authorMediator = authorMediator;
        }

        [SwaggerOperation(Summary = "Get an author")]
        [SwaggerResponse(200, type: typeof(Author))]
        [HttpGet("{guid}")]
        public async Task<IActionResult> GetAuthor(string guid)
        {
            try
            {
                var result = await _authorMediator.Send(new GetAuthorByIdQuery(new Guid(guid)));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error on getting an author with guid: {guid}");
                return StatusCode(500, ex);
            }
        }

        [SwaggerOperation(Summary = "Get every author")]
        [SwaggerResponse(200, type: typeof(List<Author>))]
        [HttpGet("authors")]
        public async Task<IActionResult> GetAuthors()
        {
            try
            {
                var result = await _authorMediator.Send(new GetAuthorListQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error on getting authors");
                return StatusCode(500, ex);
            }
        }

        [SwaggerOperation(Summary = "Delete an author")]
        [SwaggerResponse(200, type: typeof(List<Author>))]
        [HttpDelete("delete/{guid}")]
        public async Task<IActionResult> DeleteAuthor(string guid)
        {
            try
            {
                var result = await _authorMediator.Send(new DeleteAuthorCommand(new Guid(guid)));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error on deleting an author with guid: {guid}");
                return StatusCode(500, ex);
            }
        }

        [SwaggerOperation(Summary = "Add an author")]
        [SwaggerResponse(200, type: typeof(List<Author>))]
        [HttpPost("add")]
        public async Task<IActionResult> AddAuthor([FromBody] Author author)
        {
            try
            {
                var result = await _authorMediator.Send(new AddAuthorCommand(author));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error on adding an author: {author}");
                return StatusCode(500, ex);
            }
        }

        [SwaggerOperation(Summary = "Update an author")]
        [SwaggerResponse(200, type: typeof(List<Author>))]
        [HttpPut("update")]
        public async Task<IActionResult> UpdatePost([FromBody] Author author)
        {
            try
            {
                var result = await _authorMediator.Send(new UpdateAuthorCommand(author));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error on updating an author: {author}");
                return StatusCode(500, ex);
            }
        }
    }
}
