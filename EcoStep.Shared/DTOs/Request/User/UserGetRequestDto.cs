using Microsoft.AspNetCore.Http;

namespace EcoStep.Shared.DTOs.Request.User;

public class UserGetRequestDto
{
    public string FirebaseId { get; set; } = default!;
    
}