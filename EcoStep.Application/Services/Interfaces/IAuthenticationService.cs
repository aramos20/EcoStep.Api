namespace EcoStep.Application.Services.Interfaces;

public interface IAuthenticationService
{
    Task<string?> VerifyTokenAsync(string token);
}