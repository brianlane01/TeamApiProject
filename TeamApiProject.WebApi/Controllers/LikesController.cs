using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamApiProject.Data;
using TeamApiProject.Services.Likes;
namespace TeamApiProject.WebApi.Controllers
{
    namespace TeamApiProject.WebApi.Controllerss
    {
        [ApiController]
        [Route("api/[controller]")]
        public class LikesController : ControllerBase
        {
            private readonly ILikesService _likesService;

            public LikesController(ILikesService likesService)
            {
                _likesService = likesService;
            }

            [HttpPost]
            [Route("like")]
            public IActionResult LikePost([FromBody] LikeRequest request)
            {
                _likesService.AddLike(request.UserId, request.PostId);
                return Ok();
            }

            [HttpGet]
            [Route("likes/{postId}")]
            public IActionResult GetLikesCount(int postId)
            {
                int likesCount = _likesService.GetLikesCount(postId);
                return Ok(likesCount);
            }

            [HttpGet]
            [Route("hasliked")]
            public IActionResult HasLiked(int userId, int postId)
            {
                bool hasLiked = _likesService.HasLiked(userId, postId);
                return Ok(hasLiked);
            }
        }

        public class LikeRequest
        {
            public int UserId { get; set; }
            public int PostId { get; set; }
        }
    }
}