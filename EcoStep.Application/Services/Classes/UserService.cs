using EcoStep.Application.Services.Interfaces;
using EcoStep.Application.Utilities.Mappers;
using EcoStep.Domain.Models;
using EcoStep.Infrastructure.Extensions.Claims.ServiceWrapper;
using EcoStep.Infrastructure.UnitOfWork;
using EcoStep.Shared.DTOs.Request.User;
using EcoStep.Shared.DTOs.Response.User;


namespace EcoStep.Application.Services.Classes;
public class UserService : IUserService 
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserContext _userContext;

    public UserService
    (
        IUnitOfWork unitOfWork,
        IUserContext userContext
    )
    {
        _unitOfWork = unitOfWork;
        _userContext = userContext;
    }

    public async Task<UserCreateResponseDto> CreateUserAsync(UserCreateRequestDto userCreateRequestDto, CancellationToken cancellationToken)
    {
        User userToRegister =   await _unitOfWork.UserRepository.Create(userCreateRequestDto.ToModel(), cancellationToken);

        await _unitOfWork.Complete(cancellationToken);

        UserCreateResponseDto userCreateResponseDto = userToRegister.ToResponse();

        return userCreateResponseDto;
    }

    public async Task<UserGetResponseDto> GetUserAsync(string firebaseId)
    {
        User? userInDb = await _unitOfWork.UserRepository.getUserByFirebaseId(firebaseId);

        UserGetResponseDto userGetResponseDto = userInDb.ToGetResponse();

        return userGetResponseDto;
    }

    public async Task<UserUpdateResponseDto> UpdateUserAsync(UserUpdateRequestDto userUpdateRequestDto,
        CancellationToken cancellationToken)
    {
        int userId = _userContext.GetUserId();

        return new UserUpdateResponseDto
        {
            Email = "test"
        };
    }
}
  