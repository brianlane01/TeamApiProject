using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamApiProject.Models.User;
using TeamApiProject.Services.User;
using TeamApiProject.Models.Post;
using TeamApiProject.Models.Comment;
using TeamApiProject.Models.Responses;
using TeamApiProject.Services.Post;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace TeamApiProject.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("Register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterUser([FromBody] UserRegister model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var registerResult = await _userService.RegisterUserAsync(model);
        if (registerResult)
        {
            TextResponse response = new("User was registered.");
            return Ok(response);
        }

        return BadRequest(new TextResponse("User could not be registered."));
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<UserListItem>), 200)]
    public  async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("{userId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetById([FromRoute] int userId)
    {
        UserDetail? detail = await _userService.GetUserByIdAsync(userId);

        if (detail is null)
        {
            return NotFound();
        }

        return Ok(detail);
    }
}