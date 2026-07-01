namespace ECommerce.Application.Features.User.Login;

public sealed record LoginResult(
    Guid UserId,
    string UserName,
    TokenPair Tokens);