using CQRS.Domain.Models;
using CQRS.Infrastructure.Commands.PostCommands;
using CQRS.Infrastructure.Queries.PostQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CQRS.API.Controllers
{
    [SwaggerTag("This is a controller to Post")]
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly IMediator _postMediator;

        public PostController(ILogger<PostController> logger, IMediator postMediator)
        {
            _logger = logger;
            _postMediator = postMediator;
        }

        [SwaggerOperation(Summary = "Get a post")]
        [SwaggerResponse(200, type: typeof(Post))]
        [HttpGet("{guid}")]
        public async Task<IActionResult> GetPost(string guid)
        {
            try
            {
                var result = await _postMediator.Send(new GetPostByIdQuery(new Guid(guid)));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error on getting a post with guid: {guid}");
                return StatusCode(500, ex);
            }
        }

        [SwaggerOperation(Summary = "Get every post")]
        [SwaggerResponse(200, type: typeof(List<Post>))]
        [HttpGet("posts")]
        public async Task<IActionResult> GetPosts()
        {
            try
            {
                var result = await _postMediator.Send(new GetPostListQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error on getting posts");
                return StatusCode(500, ex);
            }
        }
        
        [SwaggerOperation(Summary = "Delete a post")]
        [SwaggerResponse(200, type: typeof(List<Post>))]
        [HttpDelete("delete/{guid}")]
        public async Task<IActionResult> DeletePost(string guid)
        {
            try
            {
                var result = await _postMediator.Send(new DeletePostCommand(new Guid(guid)));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error on deleting a post with guid: {guid}");
                return StatusCode(500, ex);
            }
        }
        
        [SwaggerOperation(Summary = "Add a post")]
        [SwaggerResponse(200, type: typeof(List<Post>))]
        [HttpPost("add")]
        public async Task<IActionResult> AddPost([FromBody]Post post)
        {
            try
            {
                var result = await _postMediator.Send(new AddPostCommand(post));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error on adding a post: {post}");
                return StatusCode(500, ex);
            }
        }
        
        [SwaggerOperation(Summary = "Update a post")]
        [SwaggerResponse(200, type: typeof(List<Post>))]
        [HttpPut("update")]
        public async Task<IActionResult> UpdatePost([FromBody]Post post)
        {
            try
            {
                var result = await _postMediator.Send(new UpdatePostCommand(post));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error on updating a post: {post}");
                return StatusCode(500, ex);
            }
        }
    }
}
