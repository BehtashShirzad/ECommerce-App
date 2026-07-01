using ECommerce.Application.Abstractions.Contracts;
using ECommerce.Domain.Aggregates;
using ECommerce.Shared;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Infrastructure.Services;

public class UserManagerService( IIdentityService identityService):IUserManagerService
{
    public async Task<AppUser> CreateUser(string username, string password,  string phoneNumber, string role,string? email=null)
    {
      
        var  appUser = await identityService.RegisterAsync(username, password, phoneNumber,role,email);
        return appUser;
    }
}