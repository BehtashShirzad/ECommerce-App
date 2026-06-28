using ECommerce.Domain.Aggregates.Product.ValueObjects;

namespace ECommerce.Domain.Aggregates.Product;

public interface IProductRepository
{
    public Task AddProductAsync(Product product,CancellationToken cancellationToken);
    public void DeleteProductAsync(Product product);
    public Task<Product?> GetProductAsync(ProductId id);
}