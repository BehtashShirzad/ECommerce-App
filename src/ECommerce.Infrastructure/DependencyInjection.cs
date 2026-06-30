using ECommerce.Application.Abstractions.Contracts;
using ECommerce.Domain.Aggregates;
using ECommerce.Domain.Aggregates.Category;
using ECommerce.Domain.Aggregates.Customer;
using ECommerce.Domain.Aggregates.Product;
using ECommerce.Infrastructure.Persistence;
using ECommerce.Infrastructure.Repositories;
using ECommerce.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Infrastructure;

public static class  DependencyInjection
{
    public static void AddInfrastructureServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {

        AddDbContexts(serviceCollection,configuration);
        serviceCollection
            .AddIdentity<AppUser,IdentityRole<Guid>>(options =>
            {
                options.Password.RequireDigit = true;
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
            .AddRoles<IdentityRole<Guid>>() 
            .AddSignInManager()
            .AddEntityFrameworkStores<ApplicationDbContext>();
        
            
        serviceCollection.AddScoped<ICurrentUser, CurrentUser>();
         
        AddRepositories(serviceCollection);
        serviceCollection.AddScoped<IUserManagerService, UserManagerService>();
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        serviceCollection.AddScoped<ITransactionManager, TransactionManager>();
    }

    static  void AddRepositories(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();
        serviceCollection.AddScoped<IProductRepository, ProductRepository>();
        serviceCollection.AddScoped<ICustomerRepository, CustomerRepository>();
    }

    static void AddDbContexts(IServiceCollection serviceCollection,IConfiguration configuration)
    {
          
        serviceCollection.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ApplicationConnection")) );
       

    }
}