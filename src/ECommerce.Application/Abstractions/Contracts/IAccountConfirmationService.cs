namespace ECommerce.Application.Abstractions.Contracts;

public interface IAccountConfirmationService
{
    Task<string> GenerateEmailConfirmationTokenAsync(Guid userId);

    Task ConfirmEmailAsync(Guid userId,string token);
    Task ResendConfirmationEmailAsync(Guid userId);
}