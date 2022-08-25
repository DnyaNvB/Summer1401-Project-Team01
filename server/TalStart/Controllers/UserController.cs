﻿using Microsoft.AspNetCore.Mvc;
using TalStart.IServices;
using HostingEnvironmentExtensions = Microsoft.AspNetCore.Hosting.HostingEnvironmentExtensions;

namespace TalStart.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddUser([FromForm] string firstName, [FromForm] string lastName, [FromForm] string username, [FromForm] string email, [FromForm] string password)
    {
        if(_userService.CreateUser(firstName, lastName, username, email, password))
            return new OkResult();
        return new BadRequestResult();
    }

    [HttpDelete("/user/{name}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RemoveUser([FromRoute] string name)
    {
        await Task.Delay(3);
        return new BadRequestResult();
    }

    [HttpPut("/user")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateUser([FromForm] Object user)
    {
        await Task.Delay(3);
        return new BadRequestResult();
    }
}