using ECommerce.Application.Abstractions.Contracts;
using ECommerce.Application.Features.User;
using ECommerce.Application.Features.User.Login;
using ECommerce.Domain.Aggregates;
using ECommerce.Infrastructure.Persistence;
using Microsoft.Extensions.Options;

namespace ECommerce.Infrastructure.Services;

public class TokenService :ITokenService
{
    
    private readonly ApplicationDbContext _db;
    private readonly IIdentityService _identityService;
    private readonly JwtOptions _options;

    public TokenService(
        ApplicationDbContext db,
        IIdentityService identityService,
        IOptions<JwtOptions> options)
    {
        _db = db;
        _identityService = identityService;
        _options = options.Value;
    }
    public Task<TokenPair> GenerateTokensAsync(AppUser user)
    {
        throw new NotImplementedException();
    }

    public Task<TokenPair> RefreshAsync(string refreshToken)
    {
        throw new NotImplementedException();
    }

    public Task RevokeRefreshTokenAsync(string refreshToken)
    {
        throw new NotImplementedException();
    }

    public Task RevokeAllRefreshTokensAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ValidateRefreshTokenAsync(string refreshToken)
    {
        throw new NotImplementedException();
    }

    public Task<Guid?> GetUserIdFromRefreshTokenAsync(string refreshToken)
    {
        throw new NotImplementedException();
    }
}