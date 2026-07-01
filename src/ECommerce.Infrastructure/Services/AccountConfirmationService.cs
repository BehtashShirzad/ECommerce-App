using ECommerce.Application.Abstractions.Contracts;

namespace ECommerce.Infrastructure.Services;

public class AccountConfirmationService:IAccountConfirmationService
{
    public Task<string> GenerateEmailConfirmationTokenAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task ConfirmEmailAsync(Guid userId, string token)
    {
        throw new NotImplementedException();
    }

    public Task ResendConfirmationEmailAsync(Guid userId)
    {
        throw new NotImplementedException();
    }
}