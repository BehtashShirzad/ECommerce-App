using ECommerce.Domain.Aggregates.Order;
using FluentAssertions;

namespace ECommerceApp.UnitTest.OrderTests;

public class OrderItemTests
{
    private readonly OrderFixture _fixture = new();

    [Fact]
    public void Create_Should_Create_OrderItem()
    {
        var quantity = _fixture.Quantity;
        var unitPrice = _fixture.UnitPrice;
        var item = OrderItem.Create(
            _fixture.ProductId,
            quantity,
            unitPrice);

        item.Should().NotBeNull();
        item.Quantity.Should().Be(quantity);
        item.UnitPrice.Should().Be(unitPrice);
    }

    [Fact]
    public void AddQuantity_Should_Increase_Quantity()
    {
        var item = OrderItem.Create(_fixture.ProductId, 2, 100);

        item.AddQuantity(3);

        item.Quantity.Should().Be(5);
    }

    [Fact]
    public void RemoveQuantity_Should_Decrease_Quantity()
    {
        var item = OrderItem.Create(_fixture.ProductId, 5, 100);

        item.RemoveQuantity(2);

        item.Quantity.Should().Be(3);
    }

    [Fact]
    public void TotalPrice_Should_Be_Quantity_Multiply_UnitPrice()
    {
        var item = OrderItem.Create(_fixture.ProductId, 5, 200);

        item.TotalPrice.Should().Be(1000);
    }
}