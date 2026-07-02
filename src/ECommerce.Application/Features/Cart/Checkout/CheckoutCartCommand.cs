using System.Text.Json.Serialization;
using ECommerce.Application.Abstractions.Contracts.Command;
using ECommerce.Domain.Aggregates.Cart;
using ECommerce.Domain.Aggregates.Product;
using ECommerce.Domain.Aggregates.Product.ValueObjects;

namespace ECommerce.Application.Features.Cart.Checkout;

public record CheckoutCartCommand(Guid CartId): ICommand<Guid>
{
    [JsonIgnore]
    public Guid UserId { get; set; }
}
    public class CheckoutCartCommandHandler(ICartRepository repository,
        IProductRepository productRepository) : ICommandHandler<CheckoutCartCommand,Guid>
    {
        public async Task<Guid> Handle(CheckoutCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await repository.GetAsync(request.UserId,cancellationToken);
                 if(cart is null)
            throw new Exception("Cart not found");
            if(cart.CustomerId!= request.UserId)
                throw new Exception("Cart not found");
            foreach(var item  in cart.Items)
            {
                var product =await productRepository.GetAsync(new ProductId(item.ProductId),cancellationToken);
                if(product is null)
                 throw new Exception($"Product with id {item.ProductId} Not Found");
                 
            }
       
         
            cart.Checkout();
            await repository.AddAsync(cart,cancellationToken);
          
            return cart.Id;
        }
    }