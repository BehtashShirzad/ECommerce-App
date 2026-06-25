using ECommerce.Domain.Aggregates.Category;
using ECommerce.Domain.Aggregates.Product;
using ECommerce.Infrastructure.Persistence;

namespace ECommerce.Infrastructure.Repositories;

public class CategoryRepository(ApplicationDbContext context):ICategoryRepository
{
    readonly ApplicationDbContext _context=context;
    public Task AddCategoryAsync(Product category)
    { 
        _context.Products.Add(category);
        return _context.SaveChangesAsync();//Todo: Unit Of work
    }
}