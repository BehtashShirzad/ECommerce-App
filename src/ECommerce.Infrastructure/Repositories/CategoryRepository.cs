using ECommerce.Domain.Aggregates.Category;
using ECommerce.Infrastructure.Persistence;

namespace ECommerce.Infrastructure.Repositories;

public class CategoryRepository(ApplicationDbContext context):ICategoryRepository
{
    readonly ApplicationDbContext _context=context;
    public Task AddCategoryAsync(Category category)
    { 
        _context.Categories.Add(category);
        return _context.SaveChangesAsync();//Todo: Unit Of work
    }
}