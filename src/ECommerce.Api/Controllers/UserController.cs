using ECommerce.Application.Features.User.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers;

public class UserController(ISender sender) : BaseApiController
{
    [HttpPost("register")]
    public async Task<ActionResult> RegisterCustomer([FromBody] RegisterCustomerCommand dto,CancellationToken cancellationToken)
    {
        var result = await sender.Send(dto,cancellationToken);
        return Ok(result);
    }
}