namespace ECommerce.Domain.Aggregates.Category;

public interface ICategoryRepository
{
    public Task AddCategoryAsync(Category category);
}