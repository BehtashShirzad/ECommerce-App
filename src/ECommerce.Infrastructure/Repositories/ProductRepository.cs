using ECommerce.Domain.Aggregates.Category;
using ECommerce.Domain.Aggregates.Product;
using ECommerce.Domain.Aggregates.Product.ValueObjects;
using ECommerce.Infrastructure.Persistence;

namespace ECommerce.Infrastructure.Repositories;

public class ProductRepository(ApplicationDbContext context):IProductRepository
{
    readonly ApplicationDbContext _context=context;
    public async Task AddProductAsync(Product product,CancellationToken cancellationToken = default)
    { 
        await   _context.Products.AddAsync(product,cancellationToken);
       
    }

    public   void DeleteProductAsync(Product product)
    {
        _context.Products.Remove( product);
      
    }

  
    public async Task<Product?> GetProductAsync(ProductId id)
    {
        return await _context.Products.FindAsync(id);
    }

   
}