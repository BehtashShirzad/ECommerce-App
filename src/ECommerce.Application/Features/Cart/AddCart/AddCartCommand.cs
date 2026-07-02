using System.Text.Json.Serialization;
using ECommerce.Application.Abstractions.Contracts.Command;
using ECommerce.Application.ViewModels;
using ECommerce.Domain.Aggregates.Cart;
using ECommerce.Domain.Aggregates.Product;
using ECommerce.Domain.Aggregates.Product.ValueObjects;

namespace ECommerce.Application.Features.Cart.AddCart;

public record AddCartCommand(List<ProductViewModel.ProductViewModelInput> Products) : ICommand<Guid>
{
    [JsonIgnore]
    public Guid UserId{get;set;}

}

public class AddCartCommandHandler (IProductRepository productRepository,ICartRepository cartRepository): ICommandHandler<AddCartCommand,Guid>
{
    public async Task<Guid> Handle(AddCartCommand request, CancellationToken cancellationToken)
    {
        var cart = CartAggregate.Create(request.UserId);
        foreach(var item in request.Products)
        {
            var product = await productRepository.GetAsync(new ProductId(item.ProductId),cancellationToken);
            if(product is null)
                throw new Exception($"Product Not Found {item.ProductId}");

            cart.AddItem(item.ProductId,item.ProductName,item.Price,item.Quantity);
        }

        await cartRepository.AddAsync(cart,cancellationToken);
        return cart.Id;       
    }
}