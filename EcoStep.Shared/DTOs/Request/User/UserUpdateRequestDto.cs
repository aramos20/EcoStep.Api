using Microsoft.AspNetCore.Http;

namespace EcoStep.Shared.DTOs.Request.User;

public class UserUpdateRequestDto
{
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? BirthDateTime { get; set; }
    public int? CountryId { get; set; }
    public int? ProvinceId { get; set; }
    public int? GenderId { get; set; }
    //public IFormFile? ImageId { get; set; }
}