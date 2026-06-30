using ECommerce.Application.Abstractions.Contracts;
using ECommerce.Domain.Aggregates;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Infrastructure.Services;

public class UserManagerService(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager):IUserManagerService
{
    public async Task<AppUser> CreateUser(string username, string password, string email, string phoneNumber)
    {
        var appUser = new AppUser()
        {
            PhoneNumber = phoneNumber,
            UserName = username,
            Email = email

        };
     var identityResult = await  userManager.CreateAsync(appUser, password);
     if (!identityResult.Succeeded)
         throw new ValidationException(
             identityResult.Errors.Select(e =>
                 new ValidationFailure(e.Code, e.Description)));
     return appUser;
    }
}