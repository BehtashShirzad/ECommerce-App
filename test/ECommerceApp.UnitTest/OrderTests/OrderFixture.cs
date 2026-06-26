using Bogus;
using ECommerce.Domain.Aggregates.Customer.ValueObjects;
using ECommerce.Domain.Aggregates.Order;
using ECommerce.Domain.Aggregates.Product.ValueObjects;
using ECommerce.Shared;
using ECommerceApp.UnitTest.ProductTests;

namespace ECommerceApp.UnitTest.OrderTests;

public class OrderFixture
{
    private readonly Faker _faker = new();

    public CustomerId CustomerId => new(_faker.Random.Guid());

    public ProductId ProductId => new (IdGenerator.New());

    public int Quantity => _faker.Random.Int(1, 10);

    public decimal UnitPrice => _faker.Random.Decimal(10, 1000);

    public OrderItem OrderItem =>
        OrderItem.Create(ProductId, Quantity, UnitPrice);
}