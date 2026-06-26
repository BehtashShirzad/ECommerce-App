using Bogus;
using ECommerce.Domain.Aggregates.Category;
using ECommerce.Domain.Aggregates.Product.ValueObjects;
using ECommerce.Shared;
using ECommerceApp.UnitTest.CategoryTests;

namespace ECommerceApp.UnitTest.ProductTests;

public class ProductFixture
{
    private readonly Faker _faker = new();

    public CategoryId CategoryId => new (CategoryFaker.CategoryId());

    public string Name => _faker.Commerce.ProductName();

    public decimal Price => _faker.Random.Decimal(1, 100_000);

    public string Description => _faker.Commerce.ProductDescription();

    public string Slug => _faker.Lorem.Slug();

    public string? ImageUrl => _faker.Image.PicsumUrl();
    public  Guid ProductId =>  IdGenerator.New()  ;
}