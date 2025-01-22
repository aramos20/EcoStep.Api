using EcoStep.Application.Services.Interfaces;
using EcoStep.Shared.DTOs.Request.User;
using EcoStep.Shared.DTOs.Response.User;
using Microsoft.AspNetCore.Mvc;

namespace EcoStep.Api.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController
    (
        IUserService userService
    )
    {
        _userService = userService;
    }
    [HttpPost]
    [Route("create-user")]
    public async Task<IActionResult> CreateUser([FromBody] UserCreateRequestDto userCreateRequest, CancellationToken cancellationToken)
    {
        UserCreateResponseDto userCreateResponse = await _userService.CreateUserAsync(userCreateRequest, cancellationToken);
        return Ok(userCreateResponse);
    }
    [HttpGet]
    [Route("get-user")]
    public async Task<IActionResult> GetUser([FromQuery]  string firebaseId)
    {
        UserGetResponseDto userGetResponse = await _userService.GetUserAsync(firebaseId);
        return Ok(userGetResponse);
    }
    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] UserUpdateRequestDto userUpdateRequestDto, CancellationToken cancellationToken)
    {
        await _userService.UpdateUserAsync(userUpdateRequestDto, cancellationToken);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUser([FromBody] UserUpdateRequestDto userUpdateRequestDto, CancellationToken cancellationToken)
    {
        await _userService.UpdateUserAsync(userUpdateRequestDto, cancellationToken);
        return Ok();
    }
}