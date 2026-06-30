using ECommerce.Application.Abstractions.Contracts;
using ECommerce.Domain.Aggregates.Category;
using ECommerce.Domain.Aggregates.Product;
using ECommerce.Domain.Aggregates.Product.ValueObjects;
using ECommerce.Infrastructure.Persistence;

namespace ECommerce.Infrastructure.Repositories;

public class ProductRepository(ApplicationDbContext context):BaseRepository<Product,ProductId>(context),IProductRepository
{
   

   
}