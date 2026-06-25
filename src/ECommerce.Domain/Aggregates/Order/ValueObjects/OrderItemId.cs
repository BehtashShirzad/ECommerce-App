using ECommerce.Domain.Core;

namespace ECommerce.Domain.Aggregates.Order.ValueObjects;

public class OrderItemId(Guid value):ValueObject
{
   public Guid Value { get; } = value; 
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}