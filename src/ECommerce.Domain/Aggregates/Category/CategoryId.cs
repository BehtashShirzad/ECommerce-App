using Ardalis.GuardClauses;
using ECommerce.Domain.Core;
using ECommerce.Domain.Exceptions;
using ECommerce.Domain.GuardExtensions;

namespace ECommerce.Domain.Aggregates.Category;

public class CategoryId:ValueObject
{
    public CategoryId(Guid value)
    {
        Guard.Against.EmptyGuid(value,GeneralErrors.InvalidId);
        Value = value;
    }
    public Guid Value { get; } 
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}