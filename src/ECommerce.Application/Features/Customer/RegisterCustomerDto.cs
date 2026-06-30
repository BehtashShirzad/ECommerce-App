using ECommerce.Application.Abstractions.Contracts;
using ECommerce.Domain.Aggregates;
using ECommerce.Domain.Aggregates.Customer;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Application.Features.Customer;

public record RegisterCustomerCommand(string FirstName,string LastName,string Username,string PhoneNumber,string Password,string? Email=null):ITransactionalCommand<RegisterCustomerCommandResponse>;
public record RegisterCustomerCommandResponse();

public class RegisterCustomerCommandHandler(IUserManagerService userManagerService,ICustomerRepository customerRepository):ITransactionalCommandHandler<RegisterCustomerCommand,RegisterCustomerCommandResponse>
{
    public async Task<RegisterCustomerCommandResponse> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
    {
        var user = await userManagerService.CreateUser(request.Username, request.Password, request.PhoneNumber,request.Email);
        var customer = Domain.Aggregates.Customer.Customer.Create(request.FirstName,request.LastName,request.PhoneNumber,user.Id);
        await customerRepository.AddAsync(customer,cancellationToken);
        return new RegisterCustomerCommandResponse(){};
    }
}