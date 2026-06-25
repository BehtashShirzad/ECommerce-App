namespace ECommerce.Application.Abstractions.Contracts;

public interface ICurrentUser
{
    string? UserId { get; }
}