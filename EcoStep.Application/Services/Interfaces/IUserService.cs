using EcoStep.Shared.DTOs.Request.User;
using EcoStep.Shared.DTOs.Response.User;

namespace EcoStep.Application.Services.Interfaces;

public interface IUserService
{
    Task<UserUpdateResponseDto> UpdateUserAsync(UserUpdateRequestDto userUpdateRequestDto, CancellationToken cancellationToken);
    Task<UserCreateResponseDto> CreateUserAsync(UserCreateRequestDto userCreateRequestDto, CancellationToken cancellationToken);
    Task<UserGetResponseDto> GetUserAsync(string firebaseId);

}