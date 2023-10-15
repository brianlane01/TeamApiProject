using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Reflection;
using TeamApiProject.Models.Like;
using TeamApiProject.Data.Entities.Enums;
using TeamApiProject.Services.Likes;
using TeamApiProject.Models.User;
using TeamApiProject.Models.Posts;
using TeamApiProject.Models.Responses;
using TeamApiProject.Services.Posts;
using TeamApiProject.Services.User;

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
            public async Task<IActionResult> CreateLike([FromBody] LikeCreate request)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var response = await _likesService.CreateLikeAsync(request);
                if (response is not null)
                    return Ok(response);

                return BadRequest(new TextResponse("Could not create Comment, Please Try Again."));

                // {
                //     if (likeRequest == null)
                //     {
                //         return BadRequest("Invalid request.");
                //     }

                //     // Use the LikeService to create a like.
                //     bool created = await _likesService.LikePostAsync(likeRequest.PostId, likeRequest.UserId, likeRequest.Action);

                //     if (created)
                //     {
                //         return Ok("Like created successfully.");
                //     }
                //     else
                //     {
                //         return BadRequest("Unable to create the like.");
                //     }



                // [HttpPost]
                // [Route("like")]
                // public IActionResult LikePost([FromBody] LikeRequest request)
                // {
                //     _likesService.AddLike(request.UserId, request.PostId);
                //     return Ok();
                // }


            }

        
            //     [HttpGet]
            //     [Route("likes/{postId}")]
            //     public IActionResult GetLikesCount(int postId)
            //     {
            //         int likesCount = _likesService.GetLikesCount(postId);
            //         return Ok(likesCount);
            //     }

            //     [HttpGet]
            //     [Route("hasliked")]
            //     public IActionResult HasLiked(int userId, int postId)
            //     {
            //         bool hasLiked = _likesService.HasLiked(userId, postId);
            //         return Ok(hasLiked);
            //     }
            // }

            // public class LikeRequest
            // {
            //     public int UserId { get; set; }
            //     public int PostId { get; set; }
            // }
        }
    }
}