using ECommerce.Domain.Core;

namespace ECommerce.Domain.Aggregates.Category;

public static class CategoryErrors
{
    public static DomainError InvalidCategoryName = new DomainError(-1,nameof(InvalidCategoryName),"Invalid category name");
    
}