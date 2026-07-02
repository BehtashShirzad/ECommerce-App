using System.Text.Json.Serialization;
using ECommerce.Application.Abstractions.Contracts.Command;
using ECommerce.Application.ViewModels;
using ECommerce.Domain.Aggregates.Cart;
using ECommerce.Domain.Aggregates.Product;
using ECommerce.Domain.Aggregates.Product.ValueObjects;
 

namespace ECommerce.Application.Features.Cart.AddProductToCart;

public record AddProductToCartCommand : ICommandVoid
{
    [JsonIgnore]
    public Guid UserId{get;set;}
   
    public ProductViewModel.ProductViewModelInput ProductDto{get;set;}=null!;
}
public class AddProductToCartCommandHandler(ICartRepository repository,IProductRepository productRepository) : ICommandHandler<AddProductToCartCommand>
{
    public async Task Handle(AddProductToCartCommand request, CancellationToken cancellationToken)
    {
           
              
        var cart = await repository.GetAsync(request.UserId,cancellationToken);
        if(cart is null)
            throw new Exception("Cart not found");
        if(cart.CustomerId!= request.UserId)
            throw new Exception("Cart not found");
        var product =await productRepository.GetAsync(new ProductId(request.ProductDto.ProductId),cancellationToken);
        if(product is null)
            throw new Exception("Product Not Found");
        cart.AddItem(request.ProductDto.ProductId,
            request.ProductDto.ProductName,
            request.ProductDto.Price,
            request.ProductDto.Quantity);


        await repository.AddAsync(cart,cancellationToken);

     

    }
}