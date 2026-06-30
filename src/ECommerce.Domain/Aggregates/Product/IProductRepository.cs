using ECommerce.Domain.Aggregates.Product.ValueObjects;
using ECommerce.Domain.Core;

namespace ECommerce.Domain.Aggregates.Product;

public interface IProductRepository:IRepository<Product,ProductId>
{
     
}