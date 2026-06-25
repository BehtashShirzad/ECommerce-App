namespace ECommerce.Domain.Aggregates.Category;

public interface ICategoryRepository
{
    public Task AddCategoryAsync(Product.Product category);
}