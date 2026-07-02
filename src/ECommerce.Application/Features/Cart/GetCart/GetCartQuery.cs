using System.Text.Json.Serialization;
using ECommerce.Application.Abstractions.Contracts.Query;
using ECommerce.Application.ViewModels;

namespace ECommerce.Application.Features.Cart.GetCart;

public record GetCartQuery : IQuery<CartViewModel.CartDto>
{
    [JsonIgnore]
    public Guid UserId { get; set; }
}
