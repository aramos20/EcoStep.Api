namespace EcoStep.Shared.DTOs.Response.User;

public class UserUpdateResponseDto
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
    public string? ImageProfileUrl { get; set; }
}
