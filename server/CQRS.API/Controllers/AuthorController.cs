using CQRS.Domain;
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
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(ILogger<AuthorController> logger, IAuthorRepository authorRepository)
        {
            _logger = logger;
            _authorRepository = authorRepository;
        }

        [SwaggerOperation(Summary = "Get an author")]
        [SwaggerResponse(200, type: typeof(Author))]
        [HttpGet("{guid}")]
        public IActionResult GetAuthor(string guid)
        {
            try
            {
                var result = _authorRepository.GetAuthor(new Guid(guid));
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
        public IActionResult GetAuthors()
        {
            try
            {
                var result = _authorRepository.GetAuthors();
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
        public IActionResult DeleteAuthor(string guid)
        {
            try
            {
                _authorRepository.DeleteAuthor(new Guid(guid));
                return Ok();
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
        public IActionResult AddAuthor([FromBody] Author author)
        {
            try
            {
                _authorRepository.AddAuthor(author);
                return Ok();
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
        public IActionResult UpdatePost([FromBody] Author author)
        {
            try
            {
                _authorRepository.UpdateAuthor(author);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error on updating an author: {author}");
                return StatusCode(500, ex);
            }
        }
    }
}
