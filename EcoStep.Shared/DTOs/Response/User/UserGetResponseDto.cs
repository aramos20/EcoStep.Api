namespace EcoStep.Shared.DTOs.Response.User;

public class UserGetResponseDto
{
    public int Id { get; set; }
    public string FirebaseId { get; set; } = default!;
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? BirthDateTime { get; set; }
    public string GenderName { get; set; }
    public string? CountryName { get; set; }
    public string? ProvinceName { get; set; }
    public string? ImageUrl { get; set; }

}
