using ECommerce.Domain.Aggregates.Order;
using ECommerce.Domain.Aggregates.Order.Enumeration;
using ECommerce.Domain.Aggregates.Product.ValueObjects;
using ECommerce.Domain.Core;
using FluentAssertions;

namespace ECommerceApp.UnitTest.OrderTests;

public class OrderTests
{
    private readonly OrderFixture _fixture = new();

    [Fact]
    public void Create_Should_Create_Order()
    {
        var customerId = _fixture.CustomerId;
        // Act
        var order = Order.Create(customerId);

        // Assert
        order.Should().NotBeNull();
        order.Id.Value.Should().NotBe(Guid.Empty);
        order.CustomerId.Should().Be(customerId);
        order.OrderStatus.Should().Be(OrderStatus.Created);
    }

    [Fact]
    public void Create_Should_Throw_DomainException_When_Customer_Is_Null()
    {
        Action action = () => Order.Create(null!);

        action.Should().Throw<DomainException>();
    }

    [Fact]
    public void Create_Should_Add_Domain_Event()
    {
        var order = Order.Create(_fixture.CustomerId);

        order.DomainEvents.Should().HaveCount(1);
    }

    [Fact]
    public void AddItem_Should_Add_New_Item()
    {
        var order = Order.Create(_fixture.CustomerId);

        var item = _fixture.OrderItem;

        order.AddItem(item);

        order.OrderItems.Should().ContainSingle();
    }

    [Fact]
    public void AddItem_Should_Increase_Quantity_When_Product_Already_Exists()
    {
        var order = Order.Create(_fixture.CustomerId);

        var productId = _fixture.ProductId;

        var first = OrderItem.Create(productId, 2, 100);
        var second = OrderItem.Create(productId, 3, 100);

        order.AddItem(first);
        order.AddItem(second);

        order.OrderItems.Should().ContainSingle();

        order.OrderItems.First().Quantity.Should().Be(5);
    }

    [Fact]
    public void AddItem_Should_Throw_DomainException_When_Item_Is_Null()
    {
        var order = Order.Create(_fixture.CustomerId);

        Action action = () => order.AddItem(null!);

        action.Should().Throw<DomainException>();
    }

    [Fact]
    public void TotalPrice_Should_Be_Sum_Of_Items()
    {
        var order = Order.Create(_fixture.CustomerId);

        order.AddItem(OrderItem.Create(_fixture.ProductId, 2, 100));

        order.AddItem(OrderItem.Create(new ProductId(Guid.NewGuid()), 3, 200));

        order.TotalPrice.Should().Be(800);
    }

    [Fact]
    public void MarkAsPaid_Should_Change_Status_To_Paid()
    {
        var order = Order.Create(_fixture.CustomerId);

        order.AddItem(_fixture.OrderItem);

        order.MarkAsPaid();

        order.OrderStatus.Should().Be(OrderStatus.Paid);
    }

    [Fact]
    public void MarkAsPaid_Should_Throw_DomainException_When_Order_Is_Empty()
    {
        var order = Order.Create(_fixture.CustomerId);

        Action action = () => order.MarkAsPaid();

        action.Should().Throw<DomainException>();
    }

    [Fact]
    public void MarkAsPaid_Should_Throw_DomainException_When_Status_Is_Invalid()
    {
        var order = Order.Create(_fixture.CustomerId);

        order.AddItem(_fixture.OrderItem);

        order.MarkAsPaid();

        Action action = () => order.MarkAsPaid();

        action.Should().Throw<DomainException>();
    }
}