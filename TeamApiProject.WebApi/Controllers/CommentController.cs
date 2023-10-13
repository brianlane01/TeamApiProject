using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamApiProject.Models.User;
using TeamApiProject.Models.Post;
using TeamApiProject.Models.Comment;
using TeamApiProject.Models.Responses;
using TeamApiProject.Services.Post;
using TeamApiProject.Services.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TeamApiProject.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateComment([FromBody] NoteCreate request)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = await _commentService.CreateCommentAsync(request);
        if (response is not null)
            return Ok(response);

        return BadRequest(new TextResponse("Could not create Comment, Please Try Again."));
        
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CommentListItem>), 200)]
    public  async Task<IActionResult> GetAllComments()
    {
        var comments = await _commentService.GetAllCommentsAsync();
        return Ok(comments);
    }

    [HttpGet("{postId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCommentByPostId([FromRoute] int postId)
    {
        CommentDetail? detail = await _commentService.GetCommentByPostIdAsync(postId);
        
        return detail is not null 
            ? Ok(detail)
            : NotFound();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateCommentById([FromBody] CommentUpdate request)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        return await _commentService.UpdateCommentAsync(request)
            ? Ok("The Comment was updated successfully.")
            : BadRequest("The Comment was not updated, please try again.")
    }

    [HttpDelete("{commentId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteComment([FromRoute] int commentId)
    {
        return await _commentService.DeleteCommentAsync(commentId)
            ? Ok($" The Comment with Id: {commentId} was deleted successfully.")
            : BadRequest($" The Comment with ID: {commentId} was not able to be deleted.");
    }
}

