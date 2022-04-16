using CQRS.Domain;
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
        private readonly IPostRepository _postRepository;

        public PostController(ILogger<PostController> logger, IPostRepository postRepository)
        {
            _logger = logger;
            _postRepository = postRepository;
        }

        [SwaggerOperation(Summary = "Get a post")]
        [SwaggerResponse(200, type: typeof(Post))]
        [HttpGet("{guid}")]
        public IActionResult GetPost(string guid)
        {
            try
            {
                var result = _postRepository.GetPost(new Guid(guid));
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
        public IActionResult GetPosts()
        {
            try
            {
                var result = _postRepository.GetPosts();
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
        public IActionResult DeletePost(string guid)
        {
            try
            {
                _postRepository.DeletePost(new Guid(guid));
                return Ok();
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
        public IActionResult AddPost([FromBody]Post post)
        {
            try
            {
                _postRepository.AddPost(post);
                return Ok();
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
        public IActionResult UpdatePost([FromBody]Post post)
        {
            try
            {
                _postRepository.UpdatePost(post);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error on updating a post: {post}");
                return StatusCode(500, ex);
            }
        }
    }
}
