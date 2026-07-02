using ECommerce.Domain.Core;

namespace ECommerce.Domain.Aggregates.Cart;

public interface ICartRepository:IRepository<CartAggregate,Guid>
{
    
}