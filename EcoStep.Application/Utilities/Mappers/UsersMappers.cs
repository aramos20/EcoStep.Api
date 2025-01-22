using EcoStep.Domain.Models;
using EcoStep.Shared.DTOs.Request.User;
using EcoStep.Shared.DTOs.Response.User;

namespace EcoStep.Application.Utilities.Mappers;

public static class UsersMappers
{

    public static User ToModel(this UserCreateRequestDto userCreateRequestDto)
    {
        return new User
        {
            FirebaseId = userCreateRequestDto.FirebaseId,
            Name = userCreateRequestDto.Name,
            LastName = userCreateRequestDto.LastName,
            Email = userCreateRequestDto.Email
        };
    }
    public static UserCreateResponseDto ToResponse (this User user)
    {
        return new UserCreateResponseDto
        {
            Id = user.Id,
            Name = user.Name,
            LastName = user.LastName,
            Email = user.Email,
        };
    }

    public static UserGetResponseDto ToGetResponse(this User user)
    {
        return new UserGetResponseDto
        {
            Id = user.Id,
            FirebaseId = user.FirebaseId,
            Name = user.Name,
            LastName = user.LastName,
            Email = user.Email,
            Address = user.Address,
            BirthDateTime = user.BirthDateTime,
            CountryName = user.Country?.CountryName,
            ProvinceName = user.Province?.ProvinceName,
            GenderName = user.Gender?.GenderName,


        };
    }


}