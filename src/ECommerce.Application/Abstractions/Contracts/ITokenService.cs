using ECommerce.Application.Features.User;
using ECommerce.Application.Features.User.Login;
using ECommerce.Domain.Aggregates;

namespace ECommerce.Application.Abstractions.Contracts;

public interface ITokenService
{
    Task<TokenPair> GenerateTokensAsync(AppUser user);

    Task<TokenPair> RefreshAsync(string refreshToken);

    Task RevokeRefreshTokenAsync(string refreshToken);

    Task RevokeAllRefreshTokensAsync(Guid userId);
    Task<bool> ValidateRefreshTokenAsync(string refreshToken);

    Task<Guid?> GetUserIdFromRefreshTokenAsync(string refreshToken);
 
}