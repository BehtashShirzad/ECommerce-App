using ECommerce.Application.Abstractions.Contracts.Query;
using ECommerce.Application.Features.Cart.GetCart;
using ECommerce.Application.ViewModels;
using ECommerce.Domain.Aggregates.Cart;

namespace ECommerce.Infrastructure.QueryHandler.Cart;

public class GetCartQueryHandler(ICartRepository cartRepository): IQueryHandler<GetCartQuery, CartViewModel.CartDto>
{
    public  async Task<CartViewModel.CartDto> Handle(GetCartQuery request, CancellationToken cancellationToken)
    {
        var cart =await cartRepository.GetAsync(request.UserId, cancellationToken);
        if(cart == null || cart.CustomerId!= request.UserId)
        {
            throw new Exception("Cart not found");
        }

        var prodocts = cart
            .Items
            .Select(i => new ProductViewModel.ProductViewModelOutput(i.ProductId,i.Quantity,i.Price,i.ProductName))
            .ToList();
        return new CartViewModel.CartDto(prodocts, cart.TotalPrice);
    }
}