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
    }
}