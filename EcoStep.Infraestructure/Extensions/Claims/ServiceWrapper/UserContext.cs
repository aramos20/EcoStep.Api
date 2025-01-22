using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace EcoStep.Infrastructure.Extensions.Claims.ServiceWrapper;

public class UserContext : IUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public UserContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int GetUserId()
    {
        ClaimsPrincipal user = _httpContextAccessor.HttpContext.User;
        return user.GetUserIdByClaim();
    }
}