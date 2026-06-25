using ECommerce.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class CategoryController(ISender sender) : Controller
{
    private readonly ISender _sender = sender;
    [HttpPost]
    public async Task<ActionResult> AddCategoryAsync([FromBody]CreateCategoryDto dto )
    {
          await _sender.Send(dto);
        return Ok( );
    }
}