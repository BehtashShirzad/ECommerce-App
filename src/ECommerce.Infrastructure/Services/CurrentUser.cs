using ECommerce.Application.Abstractions.Contracts;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Infrastructure.Services;

public class CurrentUser : ICurrentUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUser(IHttpContextAccessor accessor)
    {
        _httpContextAccessor = accessor;
    }

    public string? UserId =>
        _httpContextAccessor.HttpContext?.User?.FindFirst("sub")?.Value;
}