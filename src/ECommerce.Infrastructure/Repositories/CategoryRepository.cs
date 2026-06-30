using ECommerce.Domain.Aggregates.Category;
using ECommerce.Domain.Aggregates.Product;
using ECommerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Repositories;

public class CategoryRepository(ApplicationDbContext context):BaseRepository<Category,CategoryId>(context),ICategoryRepository
{
    
 
}