using ECommerce.Domain.Aggregates;

namespace ECommerce.Application.Abstractions.Contracts;

public interface IUserManagerService
{
    public Task<AppUser> CreateUser(string username, string password, string phoneNumber,string role, string? email=null);
    
}