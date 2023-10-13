using Microsoft.AspNetCore.Mvc;
using TeamApiProject.Services.Posts;

namespace TeamApiProject.WebApi.Controllers
{
    [Route("api[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _postService.GetAllPostsAsync();
            return Ok(posts);
        }
        // Post
        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] PostCreate request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _postService.CreatePostAsync(request);
            if (response is not null)
                return Ok(response);
            
            return BadRequest(new TextResponse("Could not create new post."));
        }
    }

}