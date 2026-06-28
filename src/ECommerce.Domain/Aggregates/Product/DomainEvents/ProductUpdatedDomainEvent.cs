using ECommerce.Domain.Aggregates.Product.ValueObjects;
using ECommerce.Domain.Core;

namespace ECommerce.Domain.Aggregates.Product.DomainEvents;

public class ProductUpdatedDomainEvent(ProductId productId) : IDomainEvent
{
    public DateTime OccurredOn { get; init; } = DateTime.UtcNow;
    public ProductId ProductId { get; init;} = productId;
}